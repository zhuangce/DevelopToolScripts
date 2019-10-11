using UnityEditor;
using System.IO;
using System;
using UnityEngine;

public class AssetBundle  {

    static string path = Application.streamingAssetsPath;

	[MenuItem("AssetsBundleTool/Build Bundles")]
    static void BuildAssetBundle()
    {
        DirectoryInfo info = new DirectoryInfo(path);
        FileInfo[] fi = info.GetFiles();
        if (fi.Length>0)
        {
            for (int i = 0; i < fi.Length; i++)
            {
                Debug.Log(fi[i].FullName + "..." + fi[i].Name);
                File.Delete(path + "/" + fi[i].Name);
            }
        }
       else{
            BuildPipeline.BuildAssetBundles(Application.streamingAssetsPath, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
            AssetDatabase.Refresh();
        }

       
     
       
    }
    

    [MenuItem("EditorTool/LoadPikaqiuPic")]
    static void LoadAPicFormAssetFolder()
    {
       Texture2D tex =  AssetDatabase.LoadAssetAtPath<Texture2D>("Asset/WriteAndLoadFromSA/Pic/Pikaqiu.jpg");
       
    }
}
