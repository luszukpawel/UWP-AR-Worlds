using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using NUnit.Framework.Constraints;
using UnityEngine;

public class LoadAssetWeb : MonoBehaviour
{
    public List<string> assetBundleName = new List<string>();

    public IEnumerator Start()
    {

        assetBundleName = AppVariables.CurrentModel.Split(',').ToList();

        foreach (string modelstring in assetBundleName)
        {
            using (WWW www = new WWW("http://arworldsmodels.herokuapp.com/Models/" + modelstring))
            {
                yield return www;

                if (www.error != null)
                    throw new Exception("WWW download had en error" + www.error);

                AssetBundle myLoadedAssetBundle = www.assetBundle;

                if (myLoadedAssetBundle == null) Debug.Log("No bundle found");

                GameObject[] assetLoadRequest = myLoadedAssetBundle.LoadAllAssets<GameObject>();
                yield return assetLoadRequest;

                foreach (GameObject g in assetLoadRequest)
                {
                  GameObject newGameObject = Instantiate(g);
                    newGameObject.gameObject.tag = "Model";
                    
                    
                   // g.AddComponent<>()
                    Debug.Log(gameObject.name + " Created");
                }
            }
        }
    }


}
