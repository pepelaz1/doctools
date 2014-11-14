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
        //Utils.Authorize(Request);

        try
        {
                if (Request.Content.IsMimeMultipartContent())
                {
                    // Read the form data and return an async task.
                    var provider = await Request.Content.ReadAsMultipartAsync();
                    // Read the form data and return an async task.
                    var stream = await Request.Content.ReadAsStreamAsync();
                    string path = Path.GetTempPath() + Guid.NewGuid();
                    Directory.CreateDirectory(path);

                    string infile = null;


                    byte[] data1 = null;
                    string in_type = null;
                    string file_type = null;
                    string dest_type = null;
                    string output_content_type = "text/html";



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
                                //return new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(data1) };
                                return MakeResponse(file_type, data1);
                            }
                            else
                            {
                                switch (dest_type)
                                {
                                    case "html":
                                        in_type = "/M3 /C2";
                                        output_content_type = "text/html";
                                        break;
                                    case "docx":
                                        in_type = "/M3 /C3";
                                        output_content_type = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                        break;
                                }

                                infile = path + "\\in.pdf";
                            }
                            break;
                        case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                            if (dest_type == "docx")
                            {
                                //return new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(data1) };
                                return MakeResponse(file_type, data1);
                            }
                            else
                            {
                                switch (dest_type)
                                {
                                    case "html":
                                        in_type = "/M1 /C10";
                                        output_content_type = "text/html";
                                        break;
                                    case "pdf":
                                        in_type = "/M1 /C17";
                                        output_content_type = "application/pdf";
                                        break;
                                }
                            }
                            infile = path + "\\in.docx";
                            break;
                        case "text/html":
                            if (dest_type == "html")
                            {
                                //return new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(data1) };
                                return MakeResponse(file_type, data1);
                            }
                            else
                            {
                                switch (dest_type)
                                {
                                    case "pdf":
                                        in_type = "/M2 /F4 /C12";
                                        output_content_type = "application/pdf";
                                        break;
                                    case "docx":
                                        in_type = "/M2 /F4 /C13";
                                        output_content_type = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                                        break;
                                }
                            }
                            infile = path + "\\in.html";
                            break;
                    }

                    if (infile == null)
                    { throw new Exception("Unrecognized file type"); }

                    if (data1 == null)
                    { throw new Exception("No form part named 'file'"); }

                    if (dest_type == null)
                    { throw new Exception("Unrecognized output file type"); }

                    File.WriteAllBytes(infile, data1);


                    // make output filename
                    string outfilename = path + "\\output."+dest_type;
                    string logfile = path + "\\diffdoc.log";

                    // construct command line
                    string cmdline = @"/S" + infile + " /T" + outfilename + " /L" + logfile + " " + in_type;


                    var process = Process.Start(@"C:\Program Files (x86)\Softinterface, Inc\Convert Doc\ConvertDoc.EXE", cmdline);
                    process.WaitForExit();
                    Utils.WaitForFile(outfilename);
                    if (!File.Exists(outfilename))
                    {
                        throw new Exception("Unknown error. See log: \r\n" + File.ReadAllText(logfile));
                    }

                    dynamic op = new ExpandoObject();
                    byte[] output = File.ReadAllBytes(outfilename);


                    // delete temp files
                    File.Delete(infile);
                    File.Delete(logfile);
                    File.Delete(outfilename);

                    return MakeResponse(output_content_type, output);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType) { Content = new StringContent("Only multipart/form-data supported.") };
                }

               
        }
        catch (System.Exception e)
        {
            return new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = new StringContent(err_desc(e)) };

        }      
    }


    private HttpResponseMessage MakeResponse(string content_type, byte[] output)
    {
        HttpResponseMessage resp = new HttpResponseMessage();
        resp.StatusCode = HttpStatusCode.OK;
        resp.Content = new ByteArrayContent(output);
        resp.Content.Headers.ContentType = new MediaTypeHeaderValue(content_type);
        return resp;
    }


    private string err_desc(Exception e)
    {
        string tmp = "Message: " + e.Message;
        tmp += "\r\nSource: " + e.Source;
        tmp += "\r\nStackTrace: " + e.StackTrace;
        if (e.InnerException != null)
        {
            tmp += "\r\nInnerException: " + err_desc(e.InnerException);    
        }        
       return tmp;
    }
}