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

public class CompareController : ApiController
{
    //public HttpResponseMessage Post()
    //{
    //    return new HttpResponseMessage(HttpStatusCode.OK);
    //}


    public async Task<HttpResponseMessage> PostFile()
    {
        // Check if the request contains multipart/form-data.
        if (!Request.Content.IsMimeMultipartContent())
        {
            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        }

       // Utils.Authorize(Request);
        
        try
        {
            // Read the form data and return an async task.
            var provider = await Request.Content.ReadAsMultipartAsync();
            byte[] data1 = null;
            byte[] data2 = null;
            string master_name = "test1.txt";
            string source_name = "test2.txt";
            string report_type = "all-in-one";

        
            foreach (var item in provider.Contents)
            {
                string name = item.Headers.ContentDisposition.Name.TrimStart("\"".ToCharArray()).TrimEnd("\"".ToCharArray()).ToLower();
                if (name == "original")
                {
                    Task<byte[]> t = item.ReadAsByteArrayAsync();
                    t.Wait();
                    data1 = t.Result;

                    master_name = Path.GetFileName(item.Headers.ContentDisposition.FileName.TrimStart("\"".ToCharArray()).TrimEnd("\"".ToCharArray()).ToLower());

                }
                if (name == "modified")
                {
                    Task<byte[]> t = item.ReadAsByteArrayAsync();
                    t.Wait();
                    data2 = t.Result;

                    source_name = Path.GetFileName(item.Headers.ContentDisposition.FileName.TrimStart("\"".ToCharArray()).TrimEnd("\"".ToCharArray()).ToLower());
                }
                //if (name == "master_name")
                //{
                //    master_name = await item.ReadAsStringAsync();
                //}
                //if (name == "source_name")
                //{
                //    source_name = await item.ReadAsStringAsync();
                //}
                if (name == "report_type")
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
            string outfilename = path + "\\output.rtf";
            string outfilename2 = path + "\\output.html";
            string logfile = path + "\\diffdoc.log";


           
            // construct command line
            string cmdline = @"/S" + filename1 + " /M" + filename2 + " /T" + outfilename + " /L" + logfile + " /R4 /X";
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

            cmdline = "/S" + outfilename + " /T" + outfilename2 + "  /M1 /C10 /A1 /A9  /A10";
            process = Process.Start(@"C:\Program Files (x86)\Softinterface, Inc\Convert Doc\ConvertDoc.EXE", cmdline);
            process.WaitForExit();
            Utils.WaitForFile(outfilename2);

            

            // make comparsion ( using ActiveX )
            // clsDiffDoc dd = new clsDiffDoc();
            // dd.DoCommandLine(cmdline);

            dynamic op = new ExpandoObject();
            byte[] output = File.ReadAllBytes(outfilename2);


            // delete temp files
            File.Delete(filename1);
            File.Delete(filename2);
            File.Delete(outfilename);
            File.Delete(outfilename2);
            File.Delete(logfile);
            //HttpResponseMessage response = new HttpResponseMessage();
            //response.Content = new ByteArrayContent(bytesInStream);
            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.wordprocessingml.document");

            //return response;

            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(output) };
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