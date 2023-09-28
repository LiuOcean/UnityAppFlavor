#if UNITY_IOS

using System;
using System.IO;
using UnityEditor;
using UnityEditor.iOS.Xcode;

namespace UnityAppFlavor.Editor
{
    public class CopyIL2CppGoogleHeader_XcodeRebuildTask : AXcodeRebuildTask
    {
        public override void Handle(PBXProject pbx_project, string path_to_built_project, string channel_name)
        {
            var source_dir = _GetIL2CppGooglePath();
            var dest_dir   = Path.Combine(path_to_built_project, "Libraries/external/google");

            if(Directory.Exists(dest_dir))
            {
                Directory.Delete(dest_dir, true);
            }

            _CopyDirectory(source_dir, dest_dir);
        }

        private static string _GetIL2CppGooglePath()
        {
            var unity_root = Path.GetDirectoryName(EditorApplication.applicationContentsPath);

#if UNITY_EDITOR_OSX
            unity_root = Path.Combine(unity_root, "Contents");
#endif

            return Path.Combine(unity_root, "il2cpp/external/google");
        }

        private static void _CopyDirectory(string source_dir, string dest_dir)
        {
            DirectoryInfo source = new DirectoryInfo(source_dir);
            DirectoryInfo target = new DirectoryInfo(dest_dir);

            if(target.FullName.StartsWith(source.FullName, StringComparison.CurrentCultureIgnoreCase))
            {
                throw new Exception("父目录不能拷贝到子目录！");
            }

            if(!source.Exists)
            {
                return;
            }

            if(!target.Exists)
            {
                target.Create();
            }

            var files = source.GetFiles();

            foreach(var file in files)
            {
                File.Copy(file.FullName, Path.Combine(target.FullName, file.Name), true);
            }

            DirectoryInfo[] dirs = source.GetDirectories();

            foreach(var dir in dirs)
            {
                _CopyDirectory(dir.FullName, Path.Combine(target.FullName, dir.Name));
            }
        }
    }
}
#endif