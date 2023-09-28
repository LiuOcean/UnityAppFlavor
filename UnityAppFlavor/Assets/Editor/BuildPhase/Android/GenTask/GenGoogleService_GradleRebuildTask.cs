using System.IO;
using UnityEditor;

namespace UnityAppFlavor.Editor
{
    public class GenGoogleService_GradleRebuildTask : AGradleRebuildTask
    {
        private readonly string _android_project_path;

        public GenGoogleService_GradleRebuildTask(string android_project_path) =>
            _android_project_path = android_project_path;

        public override void Handle(ref string unity_lib_gradle, ref string launch_gradle, ref string properties_file)
        {
            // TODO
            // var launcher_path = _android_project_path.Replace("unityLibrary", "launcher");
            //
            // foreach(var param in _setting.android_build_params)
            // {
            //     string dir = Path.Combine(launcher_path, $"src/{param.dir_name}");
            //
            //     if(!Directory.Exists(dir))
            //     {
            //         Directory.CreateDirectory(dir);
            //     }
            //
            //     var json = param.google_service;
            //
            //     if(string.IsNullOrEmpty(json))
            //     {
            //         continue;
            //     }
            //
            //     File.WriteAllText(Path.Combine(dir, "google-services.json"), json);
            // }
            //
            // AssetDatabase.Refresh();
        }
    }
}