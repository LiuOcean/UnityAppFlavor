#if UNITY_IOS
using UnityEditor.iOS.Xcode;

namespace UnityAppFlavor.Editor
{
    public class RedirectInfoPath_XcodeRebuildTask : AXcodeRebuildTask
    {
        public override void Handle(PBXProject pbx_project, string path_to_built_project, string channel_name)
        {
            foreach(var channel in _setting.channels)
            {
                if(!string.Equals(channel_name, channel.name))
                {
                    continue;
                }
                
                var guid = pbx_project.GetUnityMainTargetGuid();

                // string path = channel.IsUnityIPhoneTarget() ? "Info.plist" : $"{channel.name}-Info.plist";
                string path = "Info.plist";

                pbx_project.SetBuildProperty(guid, "INFOPLIST_FILE", path);
            }
        }
    }
}

#endif