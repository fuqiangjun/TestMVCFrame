using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


public class CreateAssetBundles
{
    [MenuItem("AssetBundle/Build1")]
    public static void BuildAllAssetBundle()
    {
        string dir = Application .dataPath +  "/AssetBundles";

        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
    }


    [MenuItem("AssetBundle/Bulid2")]
    public static void Build ()
    {
        BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.ChunkBasedCompression,
            EditorUserBuildSettings.activeBuildTarget);
        
        AssetDatabase.Refresh();
    }
    
}
