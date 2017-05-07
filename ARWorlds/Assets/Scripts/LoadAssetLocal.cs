using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LoadAssetLocal : MonoBehaviour
{
    public List<string> assetBundleName = new List<string>();

    IEnumerator Start()
    {

        var info = new DirectoryInfo(Application.streamingAssetsPath);
        var fileInfo = info.GetFiles();

        foreach (var file in fileInfo)
        {
            if(!(Path.GetFileNameWithoutExtension(file.ToString()).Contains(".manifest") || Path.GetFileNameWithoutExtension(file.ToString()).Contains("AssetBundles")))
            {
                Debug.Log(Path.GetFileNameWithoutExtension(file.ToString()));

                if(! assetBundleName.Contains(Path.GetFileNameWithoutExtension(file.ToString())))
                {
                    assetBundleName.Add(Path.GetFileNameWithoutExtension(file.ToString()));
                }
                
            }
           
        }

        foreach (var name in assetBundleName)
        {
            var bundleLoadRequest =
                AssetBundle.LoadFromFileAsync(Path.Combine(Application.streamingAssetsPath, name));


            yield return bundleLoadRequest;

            var myLoadAssetBundle = bundleLoadRequest.assetBundle;
            if (myLoadAssetBundle == null)
            {
                Debug.Log("Failed to load Asset Bundle !");
                yield break;
            }

            GameObject[] assetLoadRequest = myLoadAssetBundle.LoadAllAssets<GameObject>();
            yield return assetLoadRequest;

            foreach (GameObject gameObject in assetLoadRequest)
            {
                Instantiate(gameObject);
                Debug.Log(gameObject.name + " Created");
            }
        }
       

    }

}
