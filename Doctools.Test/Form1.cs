using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
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
            try
            {
                Cursor = Cursors.WaitCursor;
                tbCompareResult.Text = "";

                byte[] input1 = File.ReadAllBytes(tbInputFile1.Text);
                byte[] input2 = File.ReadAllBytes(tbInputFile2.Text);

                dynamic o = new ExpandoObject();
                o.file1 = Convert.ToBase64String(input1);
                o.file2 = Convert.ToBase64String(input2);
                string json = JsonConvert.SerializeObject(o);

                var body = Encoding.UTF8.GetBytes(json);
                
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(tbURL.Text);
              //  req.Timeout = 600000;
              //  req.Proxy = GetProxy();
                req.Method = "POST";
                req.ContentType = "application/json";
                req.ContentLength = body.Length;

                using (Stream stream = req.GetRequestStream())
                {
                    stream.Write(body, 0, body.Length);
                    stream.Close();
                }

                using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        JObject jsonObj = JObject.Parse(reader.ReadToEnd());
                        dynamic resp = new JObject(jsonObj);
                        string output = resp.output;
                        byte[] data = Convert.FromBase64String(output);
                        string resultfile = Path.GetTempPath() + "\\" + Guid.NewGuid() + ".doc";
                        File.WriteAllBytes(resultfile, data);
                        Process.Start(resultfile);

                        tbCompareResult.Text = "ok";
                    }
                    response.Close();
                }
            }
            catch (Exception ex)
            {
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

        
    }
}
