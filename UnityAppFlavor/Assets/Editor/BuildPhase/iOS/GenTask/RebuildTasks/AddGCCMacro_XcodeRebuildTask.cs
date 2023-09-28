#if UNITY_IOS
using UnityEditor.iOS.Xcode;

namespace UnityAppFlavor.Editor
{
    public class AddGCCMacro_XcodeRebuildTask : AXcodeRebuildTask
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
                pbx_project.AddBuildProperty(guid, "GCC_PREPROCESSOR_DEFINITIONS", channel.name.ToUpper());

                guid = pbx_project.GetUnityFrameworkTargetGuid();
                pbx_project.AddBuildProperty(guid, "GCC_PREPROCESSOR_DEFINITIONS", channel.name.ToUpper());
            }
        }
    }
}

#endif