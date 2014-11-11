using DiffDoc;
using System;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.Web;
using System.Threading;

public class CompareController : ApiController
{
    public async Task<HttpResponseMessage> PostFile()
    {
        // Check if the request contains multipart/form-data.
        if (!Request.Content.IsMimeMultipartContent())
        {
            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        }
        //string root = HttpContext.Current.Server.MapPath("~/App_Data");
      //  var provider = new MultipartFormDataStreamProvider(root);

        try
        {
         //   StringBuilder sb = new StringBuilder(); // Holds the response body

            // Read the form data and return an async task.
           var provider =  await Request.Content.ReadAsMultipartAsync();
           byte[] data1 = null;
           byte[] data2 = null;
           foreach (var item in provider.Contents)
           {
               //if (item.Headers.ContentDisposition.Name == "master")
               //{ data1 = await item.ReadAsByteArrayAsync().Result; }
               //if (item.Headers.ContentDisposition.Name == "source")
               //{ data2 = await item.ReadAsByteArrayAsync().Result; }

               if (item.Headers.ContentDisposition.Name == "master")
               {
                   Task<byte[]> t = item.ReadAsByteArrayAsync();
                   t.Wait();
                   data1 = t.Result; 
               }
               if (item.Headers.ContentDisposition.Name == "source")
               { 
                   Task<byte[]> t = item.ReadAsByteArrayAsync();
                   t.Wait();
                   data2 = t.Result; 
               }
           }


            // write temp output files
            //string filename1 = Path.GetTempFileName();
            //string filename2 = Path.GetTempFileName();
            string filename1 = @"c:\In\Test1.txt";
            string filename2 = @"c:\In\Test2.txt";

            //string filename1 = Path.GetTempPath() + Guid.NewGuid() + ".txt";
            // string filename2 = Path.GetTempPath() + Guid.NewGuid() + ".txt";


            File.WriteAllBytes(filename1, data1);
            File.WriteAllBytes(filename2, data2);


            // make output filename
            //string outfilename = Path.GetTempPath() +  Guid.NewGuid() + ".doc";
            string outfilename = @"c:\In\output.html";
            //string logfile = Path.GetTempPath() +  @"docdiff.log";
            string logfile = @"c:\in\docdiff.log";

       
          //  clsDiffDoc dd = new clsDiffDoc();
            // construct command line
            string cmdline = @"/S" + filename1 + " /M" + filename2 + " /T" + outfilename + " /L" + logfile + " /F2 /R1 /X";



            String source = Assembly.GetExecutingAssembly().GetName().FullName;
            if (!EventLog.SourceExists(source))
                EventLog.CreateEventSource(source, "Application");

            EventLog.WriteEntry(source, cmdline, EventLogEntryType.Information);


    
            var process = Process.Start(@"C:\Program Files (x86)\Softinterface, Inc\DiffDoc\DiffDoc.EXE", cmdline);
            process.WaitForExit();
            WaitForFile(outfilename);

            // make comparsion
           // int res = dd.DoCommandLine(cmdline);

          //  return new HttpResponseMessage(HttpStatusCode.OK);

            // if (res != 0)
            //    return res;

            dynamic op = new ExpandoObject();
            byte[] output = File.ReadAllBytes(outfilename);
            

            // delete temp files
            File.Delete(filename1);
            File.Delete(filename2);
            File.Delete(outfilename);

            //return new HttpResponseMessage(HttpStatusCode.OK);

            return new HttpResponseMessage(HttpStatusCode.OK) {  Content = new StringContent(Convert.ToBase64String(output)) };


            // This illustrates how to get the file names for uploaded files.
           /* foreach (var file in provider.FileData)
            {
                FileInfo fileInfo = new FileInfo(file.LocalFileName);
                sb.Append(string.Format("Uploaded file: {0} ({1} bytes)\n", fileInfo.Name, fileInfo.Length));
            }
            return new HttpResponseMessage()
            {
                Content = new StringContent(sb.ToString())
            };*/




        }
        catch (System.Exception e)
        {
            String source = Assembly.GetExecutingAssembly().GetName().FullName;
            if (!EventLog.SourceExists(source))
                EventLog.CreateEventSource(source, "Application");

            EventLog.WriteEntry(source, e.ToString(), EventLogEntryType.Error);

            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            
        }



         
               
            }


/*


        string root = HttpContext.Current.Server.MapPath("~/App_Data");
        var provider = new MultipartFormDataStreamProvider(root);

        try
        {
            StringBuilder sb = new StringBuilder(); // Holds the response body

            // Read the form data and return an async task.
            await Request.Content.ReadAsMultipartAsync(provider);

            // This illustrates how to get the form data.
            foreach (var key in provider.FormData.AllKeys)
            {
                foreach (var val in provider.FormData.GetValues(key))
                {
                    sb.Append(string.Format("{0}: {1}\n", key, val));
                }
            }

            // This illustrates how to get the file names for uploaded files.
            foreach (var file in provider.FileData)
            {
                FileInfo fileInfo = new FileInfo(file.LocalFileName);
                sb.Append(string.Format("Uploaded file: {0} ({1} bytes)\n", fileInfo.Name, fileInfo.Length));
            }
            return new HttpResponseMessage()
            {
                Content = new StringContent(sb.ToString())
            };
        }
        catch (System.Exception e)
        {
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
        }*/


    bool WaitForFile(string fullPath)
    {
        int numTries = 0;
        while (true)
        {
            ++numTries;
            try
            {
                // Attempt to open the file exclusively.
                using (FileStream fs = new FileStream(fullPath,
                    FileMode.Open, FileAccess.ReadWrite,
                    FileShare.None, 100))
                {
                    fs.ReadByte();

                    // If we got this far the file is ready
                    break;
                }
            }
            catch (Exception ex)
            {
                //Log.LogWarning(
                //   "WaitForFile {0} failed to get an exclusive lock: {1}",
                //    fullPath, ex.ToString());

                if (numTries > 10)
                {
                    //Log.LogWarning(
                    //    "WaitForFile {0} giving up after 10 tries",
                    //    fullPath);
                    return false;
                }

                // Wait for the lock to be released
                System.Threading.Thread.Sleep(500);
            }
        }

        //Log.LogTrace("WaitForFile {0} returning true after {1} tries",
        //    fullPath, numTries);
        return true;
    }
}