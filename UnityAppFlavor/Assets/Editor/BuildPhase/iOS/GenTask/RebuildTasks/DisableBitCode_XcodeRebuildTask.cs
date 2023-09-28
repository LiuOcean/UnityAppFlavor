#if UNITY_IOS

using UnityEditor.iOS.Xcode;

namespace UnityAppFlavor.Editor
{
    public class DisableBitCode_XcodeRebuildTask : AXcodeRebuildTask
    {
        public override void Handle(PBXProject pbx_project, string path_to_built_project, string channel_name)
        {
            const string key = "ENABLE_BITCODE";

            foreach(var channel in _setting.channels)
            {
                if(!string.Equals(channel_name, channel.name))
                {
                    continue;
                }
                
                var guid = pbx_project.GetUnityMainTargetGuid();
                pbx_project.SetBuildProperty(guid, key, "NO");

                guid = pbx_project.GetUnityFrameworkTargetGuid();
                pbx_project.SetBuildProperty(guid, key, "NO");
            }
        }
    }
}
#endif