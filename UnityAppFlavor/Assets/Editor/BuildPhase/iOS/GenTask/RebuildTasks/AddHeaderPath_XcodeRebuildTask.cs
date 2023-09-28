#if UNITY_IOS
using UnityEditor.iOS.Xcode;

namespace UnityAppFlavor.Editor
{
    public class AddHeaderPath_XcodeRebuildTask : AXcodeRebuildTask
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

                if(string.IsNullOrEmpty(guid))
                {
                    return;
                }

                pbx_project.SetBuildProperty(guid, "HEADER_SEARCH_PATHS", "$(SRCROOT)/Libraries/libil2cpp/include");
            }
        }
    }
}
#endif