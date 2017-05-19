using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Text;
using System.Net;
using System.IO;
using WinRTLegacy;

namespace ARWorlds.Provider
{
    class ApiProvider
    {
        public static async Task<string> httpRequest()
        {

            HttpWebRequest request =
                (HttpWebRequest) WebRequest.Create("http://arworldsmodels.herokuapp.com/ModelsList.html");
            string received;

            using (var response =
                (HttpWebResponse) (await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse,
                    request.EndGetResponse, null)))
            {
                using (var responseStream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(responseStream))
                    {

                        received = await sr.ReadToEndAsync();
                    }
                }
            }

            return received;
        }

    }
}
