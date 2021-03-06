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
            string master_name = null;
            string source_name = null;
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
                if (name == "report_type")
                {
                    report_type = await item.ReadAsStringAsync();
                }
            }
            if (master_name == null || data1 == null)
            { throw new Exception("No form part named 'original'"); }

            if (source_name == null || data2 == null)
            { throw new Exception("No form part named 'modified'"); }

          //  if (report_type == null)
          //  { throw new Exception("No form part named 'report_type'"); }

            
            // get output folder
            string path = Path.GetTempPath() + Guid.NewGuid();
            Directory.CreateDirectory(path);

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
         
            var process = Process.Start(@"C:\Program Files (x86)\Softinterface, Inc\DiffDoc\DiffDoc.EXE", cmdline);
            process.WaitForExit();
            Utils.WaitForFile(outfilename);

            cmdline = "/S" + outfilename + " /T" + outfilename2 + "  /M1 /C10";
            process = Process.Start(@"C:\Program Files (x86)\Softinterface, Inc\Convert Doc\ConvertDoc.EXE", cmdline);
            process.WaitForExit();
            Utils.WaitForFile(outfilename2);
            if (!File.Exists(outfilename))
            {
                throw new Exception("Unknown error. See log: \r\n" + File.ReadAllText(logfile));
            }

            //html converter
            //convert images
            string[] img = Directory.GetFiles(path,"output_image*");
            if (img.Length > 0)
            {
                string content = File.ReadAllText(outfilename2, Encoding.GetEncoding(1252));
                for (int i = 0; i < img.Length; i++)
                {
                    FileInfo fi = new FileInfo(img[i]);
                    content = content.Replace(String.Format("{0}", fi.Name), "data:image/gif;base64," + Convert.ToBase64String(File.ReadAllBytes(img[i])));
                    File.Delete(img[i]);
                }
                File.WriteAllText(outfilename2, content, Encoding.GetEncoding(1252));
            }
          

            dynamic op = new ExpandoObject();
            byte[] output = File.ReadAllBytes(outfilename2);


            // delete temp files
            File.Delete(filename1);
            File.Delete(filename2);
            File.Delete(outfilename);
            File.Delete(outfilename2);
            File.Delete(logfile);            

            return new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent(output) };
        }
        catch (System.Exception e)
        {
            return new HttpResponseMessage(HttpStatusCode.InternalServerError) { Content = new StringContent(err_desc(e)) };

        }      
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