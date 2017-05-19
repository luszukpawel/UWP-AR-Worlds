using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ARWorlds.Model;
using ARWorlds.Provider;
using NUnit.Framework;

namespace ARWorlds.Handler
{
    class Model3DHandler
    {
        private static string response;
        public static async Task<List<Model3D>> getData()
        {
          Model3DHandler.response = await ApiProvider.httpRequest();
            //  var collection = JsonConvert.DeserializeObject<List<Station>>(StationHandler.response).OrderBy(x => x.StationName);
            //   List<Station> list = collection.ToList();
           List<String> namesList = response.Split(',').ToList();
            List<Model3D> modelsList = new List<Model3D>();

            foreach (string name in namesList)
            {
                modelsList.Add(new Model3D(name));
            }

            return modelsList;
        }
    }
}
