using DiffDoc;
using Doctools.Web.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Web.Http;

namespace Doctools.Web.Controllers
{
    public class CompareController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [LearningAuthorizeAttribute]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public dynamic Post(JObject jsonData)
        {
            try
            {
                dynamic o = jsonData;
                string input1 = o.file1;
                string input2 = o.file2;
                byte[] data1 = Convert.FromBase64String(input1);
                byte[] data2 = Convert.FromBase64String(input2);

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
                string outfilename = @"c:\In\output.doc";
               //string logfile = Path.GetTempPath() +  @"docdiff.log";
                string logfile = @"c:\in\docdiff.log";

                clsDiffDoc dd = new clsDiffDoc();
                // construct command line
                string cmdline = @"/S" + filename1 + " /M" + filename2 + " /T" + outfilename + "/L" + logfile + "/F1 /R4 /X";


                //var process = Process.Start(@"C:\Program Files (x86)\Softinterface, Inc\DiffDoc\DiffDoc.EXE", cmdline);
                //process.WaitForExit();

                // make comparsion
                int res = dd.DoCommandLine(cmdline);
       
               // if (res != 0)
                //    return res;

                dynamic op = new ExpandoObject();
                byte[] output = File.ReadAllBytes(outfilename);
                op.output = Convert.ToBase64String(output);


                // delete temp files
                File.Delete(filename1);
                File.Delete(filename2);
                File.Delete(outfilename);

                return op;
            }
            catch (Exception ex)
            {
                String source = Assembly.GetExecutingAssembly().GetName().FullName;
                if (!EventLog.SourceExists(source))
                    EventLog.CreateEventSource(source, "Application");

                EventLog.WriteEntry(source, ex.ToString(), EventLogEntryType.Error);

                return ex;
            }
        }

        private void dd_OnError()
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}