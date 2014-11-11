using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Doctools.Test
{
    public class DocContentType
    {
        public static string Docx = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        public static string Pdf = "application/pdf";
        public static string Html = "text/html";
        
    };

    public partial class Form1 : Form
    {
        Dictionary<string, string> _doc_types = new Dictionary<string, string>();
        
        public Form1()
        {
            InitializeComponent();
            _doc_types.Add("docx", DocContentType.Docx);
            _doc_types.Add("pdf", DocContentType.Pdf);
            _doc_types.Add("html", DocContentType.Html);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Compare();
        }

        public static WebProxy GetProxy()
        {
            #region With proxy
            Debug.WriteLine("Working through proxy");
            WebProxy wp = new WebProxy("s502ss-prx01.tpce.tomsk.ru", 3128);
            wp.Credentials = new NetworkCredential("bvv2", "`12qwerty", "tpce.tomsk.ru");
            return wp;
            #endregion

            //#region Without proxy
            //return null;
            //#endregion
        }

        public AuthenticationHeaderValue CreateBasicHeader(string username, string password)
        {
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(username + ":" + password);
        //    System.Diagnostics.Debug.WriteLine("AuthenticationHeaderValue" + new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray)));
            return new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }


        private void Compare()
        {
            HttpResponseMessage response = null; 
            try
            {
                Cursor = Cursors.WaitCursor;
                HttpContent master_name = new StringContent(Path.GetFileName(tbInputFile1.Text));
                HttpContent source_name = new StringContent(Path.GetFileName(tbInputFile2.Text));
                HttpContent master_file = new ByteArrayContent(File.ReadAllBytes(tbInputFile1.Text));
                HttpContent source_file = new ByteArrayContent(File.ReadAllBytes(tbInputFile2.Text));
                HttpContent report_type = new StringContent(Path.GetFileName(cmbReportType.Text));
                
                // Submit the form using HttpClient and 
                // create form data as Multipart (enctype="multipart/form-data")

                WebProxy wp = new WebProxy("s502ss-prx01.tpce.tomsk.ru", 3128);
                wp.Credentials = new NetworkCredential("bvv2", "`12qwerty", "tpce.tomsk.ru");

                var httpClientHandler = new HttpClientHandler
                        {
                            Proxy = wp,
                            UseProxy = true
                        };

                using (var client = new HttpClient(httpClientHandler))
                //using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = CreateBasicHeader(tbUsernameCompare.Text, tbPasswordCompare.Text);

                    using (var formData = new MultipartFormDataContent())
                    {
                        formData.Add(master_name, "master_name" );
                        formData.Add(source_name, "source_name");
                        formData.Add(master_file, "master", "master");
                        formData.Add(source_file, "source", "source");
                        formData.Add(report_type, "report_type");

                        // Actually invoke the request to the server

                        // equivalent to (action="{url}" method="post")
                        response = client.PostAsync(tbUrlCompare.Text, formData).Result;
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            tbCompareResult.Text = response.ToString();
                        }
                        else
                        {
                            byte[] data = Convert.FromBase64String(response.Content.ReadAsStringAsync().Result);
                            string resultfile = Path.GetTempPath() + "\\" + Guid.NewGuid() + ".html";
                            File.WriteAllBytes(resultfile, data);
                            Process.Start(resultfile);

                            tbCompareResult.Text = "ok";
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                //tbCompareResult.Text = ex.Message;
                if (response != null)
                    tbCompareResult.Text = response.ToString() + Environment.NewLine + ex.Message;
                else
                    tbCompareResult.Text = ex.Message;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                tbInputFile1.Text = openFileDialog1.FileName;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                tbInputFile2.Text = openFileDialog1.FileName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbReportType.SelectedIndex = 0;
            cmbOuputFormat.SelectedIndex = 0;
          //  tbUrlCompare.Text = "http://localhost:58484/api/compare";
            tbUrlConvert.Text = "http://localhost:58484/api/convert";
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            HttpWebResponse response = null;
              try
              {
                  Cursor = Cursors.WaitCursor;
                  HttpWebRequest request=(HttpWebRequest)WebRequest.Create(tbUrlConvert.Text);
                  request.ContentType = DocContentType.Docx;
                  request.Accept= "application/pdf";
                  request.Method = "POST";
                  request.Headers.Add("Authorization",CreateBasicHeader(tbUsernameConvert.Text, tbPasswordConvert.Text).ToString());
                  byte[] data = File.ReadAllBytes(tbFileToConvert.Text);
                  request.GetRequestStream().Write(data, 0, data.Length);

                  response = (HttpWebResponse)request.GetResponse();


                  int t = 4;

              }
              finally
              {
                  Cursor = Cursors.Default;

              }
        }

        
    }
}
