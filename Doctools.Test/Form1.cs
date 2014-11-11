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
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Doctools.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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


        private void Compare()
        {
            HttpResponseMessage response = null; 
            try
            {
                Cursor = Cursors.WaitCursor;
                // Convert each of the three inputs into HttpContent objects

                HttpContent stringContent = new StringContent("test");
                // examples of converting both Stream and byte [] to HttpContent objects
                // representing input type file
                HttpContent master_file = new ByteArrayContent(File.ReadAllBytes(tbInputFile1.Text));
                HttpContent source_file = new ByteArrayContent(File.ReadAllBytes(tbInputFile2.Text));
                // Submit the form using HttpClient and 
                // create form data as Multipart (enctype="multipart/form-data")

                //WebProxy wp = new WebProxy("s502ss-prx01.tpce.tomsk.ru", 3128);
                //wp.Credentials = new NetworkCredential("bvv2", "`12qwerty", "tpce.tomsk.ru");

                //var httpClientHandler = new HttpClientHandler
                //        {
                //            Proxy = wp,
                //            UseProxy = true
                //        };
        
                //using (var client = new HttpClient(httpClientHandler))
                using (var client = new HttpClient())
                {
                    using (var formData = new MultipartFormDataContent())
                    {
                        // Add the HttpContent objects to the form data

                        // <input type="text" name="filename" />
                        formData.Add(stringContent, "filename", "filename");
                        // <input type="file" name="file1" />
                        formData.Add(master_file, "master", "master");
                        // <input type="file" name="file2" />
                        formData.Add(source_file, "source", "source");

                        // Actually invoke the request to the server

                        // equivalent to (action="{url}" method="post")

                        response = client.PostAsync(tbURL.Text, formData).Result;
                        byte[] data = Convert.FromBase64String(response.Content.ReadAsStringAsync().Result);
                        string resultfile = Path.GetTempPath() + "\\" + Guid.NewGuid() + ".html";
                        File.WriteAllBytes(resultfile, data);
                        Process.Start(resultfile);

                        tbCompareResult.Text = "ok";

                    }
                }

            }
            catch (Exception ex)
            {
                //tbCompareResult.Text = ex.Message;
                tbCompareResult.Text = response.ToString() + Environment.NewLine + ex.Message;
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

        
    }
}
