using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace Doctools.Web.Utils
{
    public class Utils
    {
        public static void Authorize(HttpRequestMessage request)
        {
            if (request.Headers.Authorization.Scheme.ToLower() != "basic")
                throw new HttpResponseException(HttpStatusCode.Unauthorized);

            string decodedAuth = Encoding.UTF8.GetString(Convert.FromBase64String(request.Headers.Authorization.Parameter));
            string[] splits = decodedAuth.Split(":".ToCharArray());
            string username = splits[0];
            string password = splits[1];

            if (username != ConfigurationManager.AppSettings["Username"].ToString() ||
                password != ConfigurationManager.AppSettings["Password"].ToString())
            {
                throw new HttpResponseException(HttpStatusCode.Unauthorized);
            }
        }


        public static bool WaitForFile(string fullPath)
        {
            int numTries = 0;
            while (true)
            {
                ++numTries;
                try
                {
                    // Attempt to open the file exclusively.
                    using (FileStream fs = new FileStream(fullPath,
                        FileMode.Open, FileAccess.ReadWrite,
                        FileShare.None, 100))
                    {
                        fs.ReadByte();

                        // If we got this far the file is ready
                        break;
                    }
                }
                catch (Exception ex)
                {
                    //Log.LogWarning(
                    //   "WaitForFile {0} failed to get an exclusive lock: {1}",
                    //    fullPath, ex.ToString());

                    if (numTries > 10)
                    {
                        //Log.LogWarning(
                        //    "WaitForFile {0} giving up after 10 tries",
                        //    fullPath);
                        return false;
                    }

                    // Wait for the lock to be released
                    System.Threading.Thread.Sleep(500);
                }
            }

            //Log.LogTrace("WaitForFile {0} returning true after {1} tries",
            //    fullPath, numTries);
            return true;
        }
    }
}