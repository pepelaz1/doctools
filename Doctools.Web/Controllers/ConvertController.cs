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
using Doctools.Web.Properties;
using System.Configuration;
using Doctools.Web.Utils;
using System.Net.Http.Headers;

public class ConvertController : ApiController
{
    public async Task<HttpResponseMessage> PostFile()
    {
        //// Check if the request contains multipart/form-data.
        //if (!Request.Content.IsMimeMultipartContent())
        //{
        //    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        //}

        Utils.Authorize(Request);
        
        // application/pdf
        // application/vnd.openxmlformats-officedocument.wordprocessingml.document
        // text/html 
        // multipart/form-data

        try
        {
            // Read the form data and return an async task.
            var stream = await Request.Content.ReadAsStreamAsync();
            string outfilename = @"c:\\in\\output.docx";

            FileStream fileStream = File.Create(outfilename);
            // Initialize the bytes array with the stream length and then fill it with data
            byte[] bytesInStream = new byte[stream.Length];
            stream.Read(bytesInStream, 0, bytesInStream.Length);
            // Use write method to write to the file specified above
            fileStream.Write(bytesInStream, 0, bytesInStream.Length);
            fileStream.Close();

          /*  byte[] data1 = null;
            byte[] data2 = null;
            string master_name = "";
            string source_name = "";
            string report_type = "all-in-one";

        
            foreach (var item in provider.Contents)
            {
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
                if (item.Headers.ContentDisposition.Name == "master_name")
                {
                    master_name = await item.ReadAsStringAsync();
                }
                if (item.Headers.ContentDisposition.Name == "source_name")
                {
                    source_name = await item.ReadAsStringAsync();
                }
                if (item.Headers.ContentDisposition.Name == "report_type")
                {
                    report_type = await item.ReadAsStringAsync();
                }
            }
            
            // get output folder
            string path = Path.GetTempPath() + Guid.NewGuid();
            Directory.CreateDirectory(path);
            // string path = @"c:\In";


            string filename1 = path + "\\" + master_name;
            string filename2 = path + "\\" + source_name;
   
            File.WriteAllBytes(filename1, data1);
            File.WriteAllBytes(filename2, data2);
            
            // make output filename
            string outfilename = path + "\\output.html";
            string logfile = path + "\\diffdoc.log";


           
            // construct command line
            string cmdline = @"/S" + filename1 + " /M" + filename2 + " /T" + outfilename + " /L" + logfile + " /R1 /X";
            if (report_type == "all-in-one")
                cmdline += " /F1";
            else if (report_type == "side-by-side")
                cmdline += " /F2";
                        
            //String source = Assembly.GetExecutingAssembly().GetName().FullName;
            //if (!EventLog.SourceExists(source))
            //    EventLog.CreateEventSource(source, "Application");
            //EventLog.WriteEntry(source, cmdline, EventLogEntryType.Information);

            var process = Process.Start(@"C:\Program Files (x86)\Softinterface, Inc\DiffDoc\DiffDoc.EXE", cmdline);
            process.WaitForExit();
            Utils.WaitForFile(outfilename);

            // make comparsion ( using ActiveX )
            // clsDiffDoc dd = new clsDiffDoc();
            // dd.DoCommandLine(cmdline);

            dynamic op = new ExpandoObject();
            byte[] output = File.ReadAllBytes(outfilename);


            // delete temp files
            File.Delete(filename1);
            File.Delete(filename2);
            File.Delete(outfilename);

            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(Convert.ToBase64String(output)) };*/
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new ByteArrayContent(bytesInStream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.wordprocessingml.document");

            return response;
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
   
}