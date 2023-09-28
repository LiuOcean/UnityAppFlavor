#if UNITY_IOS
using UnityEditor.iOS.Xcode;

namespace UnityAppFlavor.Editor
{
    public class SetProvisions_XcodeRebuildTask : AXcodeRebuildTask
    {
        public override void Handle(PBXProject pbx_project, string path_to_built_project, string channel_name)
        {
            foreach(var provision in _setting.provisions)
            {
                if(!string.Equals(channel_name, provision.channel))
                {
                    continue;
                }

                var target_guid = pbx_project.GetUnityMainTargetGuid();

                if(string.IsNullOrEmpty(target_guid))
                {
                    continue;
                }

                pbx_project.SetBuildProperty(target_guid, "PROVISIONING_PROFILE_SPECIFIER", provision.uuid);
            }
        }
    }
}
#endif