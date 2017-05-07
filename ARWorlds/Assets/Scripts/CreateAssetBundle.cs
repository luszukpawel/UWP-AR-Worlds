#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreateAssetBundle : MonoBehaviour
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles("Assets/StreamingAssets", BuildAssetBundleOptions.None,
            BuildTarget.WSAPlayer);
    }
}
#endif
