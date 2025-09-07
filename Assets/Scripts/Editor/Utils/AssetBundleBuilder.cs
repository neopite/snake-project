using UnityEditor;
using UnityEngine;

namespace Snake.Utils
{
    public class AssetBundleBuilder
    {
        [MenuItem("Assets/Build AssetBundles")]
        static void BuildAllAssetBundles()
        {
            string outputPath = "Assets/AssetBundles";
            if (!System.IO.Directory.Exists(outputPath))
            {
                System.IO.Directory.CreateDirectory(outputPath);
            }

            BuildPipeline.BuildAssetBundles(
                outputPath,
                BuildAssetBundleOptions.None,
                BuildTarget.StandaloneOSX
            );

            Debug.Log("Asset Bundles built to " + outputPath);
        }
    }
}