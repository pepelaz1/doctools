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
        if (!Request.Content.IsMimeMultipartContent())
        {
            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
        }

        //Utils.Authorize(Request);
        
        // application/pdf
        // application/vnd.openxmlformats-officedocument.wordprocessingml.document
        // text/html 
        // multipart/form-data

        try
        {
            // Read the form data and return an async task.
            var provider = await Request.Content.ReadAsMultipartAsync();

            // Read the form data and return an async task.
            var stream = await Request.Content.ReadAsStreamAsync();
            string path = Path.GetTempPath() + Guid.NewGuid();
            Directory.CreateDirectory(path);

            string infile = "";


            byte[] data1 = null;
            string in_type = null;
            string dest_type = "2"; //HTML



            foreach (var item in provider.Contents)
            {
                switch (item.Headers.ContentType.ToString())
                {
                    case "application/pdf":
                        in_type = "/M3 /C" + dest_type;
                        infile = path + "\\in.pdf";
                        break;
                    case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                        in_type = "/M1 /C10" ;
                        infile = path + "\\in.docx";
                        break;
                    case "text/html":
                        in_type = "/M2 /F4 /C" + dest_type;
                        infile = path + "\\in.html";
                        break;
                }
                string name = item.Headers.ContentDisposition.Name.TrimStart("\"".ToCharArray()).TrimEnd("\"".ToCharArray()).ToLower();
                
                if (name == "file")
                {
                    Task<byte[]> t = item.ReadAsByteArrayAsync();
                    t.Wait();
                    data1 = t.Result;

                }

            }

            File.WriteAllBytes(infile, data1);

                           
            // make output filename
            string outfilename = path + "\\output.html";
            string logfile = path + "\\diffdoc.log";
           
            // construct command line
            string cmdline = @"/S" + infile + " /T" + outfilename + " /L" + logfile + " " + in_type;
     

            var process = Process.Start(@"C:\Program Files (x86)\Softinterface, Inc\Convert Doc\ConvertDoc.EXE", cmdline);
            process.WaitForExit();
            Utils.WaitForFile(outfilename);

            dynamic op = new ExpandoObject();
            byte[] output = File.ReadAllBytes(outfilename);


            // delete temp files
            File.Delete(infile);
            File.Delete(logfile);
            File.Delete(outfilename);

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