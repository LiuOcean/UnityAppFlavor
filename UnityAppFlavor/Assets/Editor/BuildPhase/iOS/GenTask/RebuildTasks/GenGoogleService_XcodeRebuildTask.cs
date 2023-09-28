#if UNITY_IOS

using System.IO;
using UnityEditor.iOS.Xcode;

namespace UnityAppFlavor.Editor
{
    public class GenGoogleService_XcodeRebuildTask : AXcodeRebuildTask
    {
        public override void Handle(PBXProject pbx_project, string path_to_built_project, string channel_name)
        {
            // TODO
            // const string file_name = "GoogleService-Info.plist";
            //
            // string full_path = Path.Combine(path_to_built_project, file_name);
            //
            // if(File.Exists(full_path))
            // {
            //     return;
            // }
            //
            // foreach(var build_param_gen in _setting.ios_build_params)
            // {
            //     if(!string.Equals(channel_name, build_param_gen.channel))
            //     {
            //         continue;
            //     }
            //
            //     var plist = build_param_gen.build_param?.file?.plist;
            //
            //     if(string.IsNullOrEmpty(plist))
            //     {
            //         return;
            //     }
            //
            //     File.WriteAllText(full_path, build_param_gen.build_param.file.plist);
            //
            //     var guid = pbx_project.GetUnityMainTargetGuid();
            //
            //     pbx_project.AddFileToBuild(guid, pbx_project.AddFile(full_path, file_name));
            // }
        }
    }
}
#endif