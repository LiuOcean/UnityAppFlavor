using UnityEditor;
using UnityEngine;

namespace UnityAppFlavor.Editor
{
    internal class MyPluginPostProcessor : AssetPostprocessor
    {
        private static void OnPostprocessAllAssets(string[] importedAssets,
                                                   string[] deletedAssets,
                                                   string[] movedAssets,
                                                   string[] movedFromAssetPaths)
        {
            bool changed = false;

            foreach(string importedAsset in importedAssets)
            {
                if(importedAsset.EndsWith(".aar"))
                {
                    changed = true;
                }
            }

            if(changed)
            {
                goto REFRESH;
            }

            foreach(var asset in deletedAssets)
            {
                if(asset.EndsWith(".aar"))
                {
                    changed = true;
                }
            }

            if(changed)
            {
                goto REFRESH;
            }

            foreach(var asset in movedAssets)
            {
                if(asset.EndsWith(".aar"))
                {
                    changed = true;
                }
            }

            if(changed)
            {
                goto REFRESH;
            }

            foreach(var asset in movedFromAssetPaths)
            {
                if(asset.EndsWith(".aar"))
                {
                    changed = true;
                }
            }

            if(changed)
            {
                goto REFRESH;
            }

            return;

            REFRESH:
            Debug.Log("[UAF] aar file changed, refresh UAFEditorSetting");
            UAFEditorSetting.GetOrCreateSettings().ResetLibs();
            UAFEditorSetting.GetOrCreateSettings().ResetShareLibs();
        }
    }
}