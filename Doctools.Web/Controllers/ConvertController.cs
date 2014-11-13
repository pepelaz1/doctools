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

        
        //Utils.Authorize(Request);
        
        // application/pdf
        // application/vnd.openxmlformats-officedocument.wordprocessingml.document
        // text/html 
        // multipart/form-data

        try
        {
            //object provider;
                if (Request.Content.IsMimeMultipartContent())
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
                    string file_type = null;
                    string dest_type = "2"; //HTML



                    foreach (var item in provider.Contents)
                    {
                        string name = item.Headers.ContentDisposition.Name.TrimStart("\"".ToCharArray()).TrimEnd("\"".ToCharArray()).ToLower();
                        if (name.ToUpper() == "Accept".ToUpper())
                        {
                            dest_type = item.ReadAsStringAsync().Result;
                        }

                        if (name == "file")
                        {
                            Task<byte[]> t = item.ReadAsByteArrayAsync();
                            t.Wait();
                            data1 = t.Result;
                            file_type = item.Headers.ContentType.ToString();
                        }

                    }

                    switch (file_type)
                    {
                        case "application/pdf":
                            if (dest_type == "pdf")
                            {
                                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(data1) };
                            }
                            else
                            {
                                switch (dest_type)
                                {
                                    case "html":
                                        in_type = "/M3 /C2";
                                        break;
                                    case "docx":
                                        in_type = "/M3 /C3";
                                        break;
                                }

                                infile = path + "\\in.pdf";
                            }
                            break;
                        case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                            if (dest_type == "docx")
                            {
                                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(data1) };
                            }
                            else
                            {
                                switch (dest_type)
                                {
                                    case "html":
                                        in_type = "/M1 /C10";
                                        break;
                                    case "pdf":
                                        in_type = "/M1 /C17";
                                        break;
                                }
                            }
                            infile = path + "\\in.docx";
                            break;
                        case "text/html":
                            if (dest_type == "html")
                            {
                                return new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(data1) };
                            }
                            else
                            {
                                switch (dest_type)
                                {
                                    case "pdf":
                                        in_type = "/M2 /F4 /C12";
                                        break;
                                    case "docx":
                                        in_type = "/M2 /F4 /C13";
                                        break;
                                }
                            }
                            infile = path + "\\in.html";
                            break;
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
            /*
            if (Request.Content.IsHttpRequestMessageContent())
            {
                var provider = await Request.Content.ReadAsHttpRequestMessageAsync();
                return new HttpResponseMessage(HttpStatusCode.OK);
            }*/

            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
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