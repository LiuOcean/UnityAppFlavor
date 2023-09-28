#if UNITY_IOS

using UnityEditor.iOS.Xcode;

namespace UnityAppFlavor.Editor
{
    public class EnsureStoreKitFramework_AXcodeRebuildTask : AXcodeRebuildTask
    {
        public override void Handle(PBXProject pbx_project, string path_to_built_project, string channel_name)
        {
            foreach(var capability in _setting.ios_capabilities)
            {
                if(!string.Equals(channel_name, capability.channel))
                {
                    continue;
                }

                if(!capability.iap)
                {
                    continue;
                }

                pbx_project.AddFrameworkToProject(
                    pbx_project.GetUnityMainTargetGuid(),
                    "StoreKit.framework",
                    false
                );

                pbx_project.AddFrameworkToProject(
                    pbx_project.GetUnityFrameworkTargetGuid(),
                    "StoreKit.framework",
                    false
                );
            }
        }
    }
}
#endif