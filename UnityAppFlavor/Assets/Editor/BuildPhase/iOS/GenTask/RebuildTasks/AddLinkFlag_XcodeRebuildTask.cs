#if UNITY_IOS

using UnityEditor.iOS.Xcode;

namespace UnityAppFlavor.Editor
{
    public class AddLinkFlag_XcodeRebuildTask : AXcodeRebuildTask
    {
        public override void Handle(PBXProject pbx_project, string path_to_built_project, string channel_name)
        {
            const string key   = "OTHER_LDFLAGS";
            const string value = "-ObjC";

            foreach(var channel in _setting.channels)
            {
                if(!string.Equals(channel_name, channel.name))
                {
                    continue;
                }

                var guid = pbx_project.GetUnityMainTargetGuid();

                pbx_project.SetBuildProperty(guid, key, value);
            }
        }
    }
}
#endif