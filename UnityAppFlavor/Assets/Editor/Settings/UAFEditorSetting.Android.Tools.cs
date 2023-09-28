using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;

namespace UnityAppFlavor.Editor
{
    public partial class UAFEditorSetting
    {
        #region Reset

        public void ResetJava()
        {
            Undo.RecordObject(this, "UAF/Config/JavaReset");

            java_transfers = new List<UAFAndroidJavaTransfer>(2)
            {
                new() {dir_name = "oversea", java_file = "MainActivity.java", package_name = "com.company.uaf"},
                new()
                {
                    dir_name           = "inland",
                    java_file          = "MainActivity_CN.java",
                    package_name       = "com.company.uaf",
                    java_file_new_name = "MainActivity.java"
                }
            };
        }

        public void ResetLibs()
        {
            Undo.RecordObject(this, "UAF/Config/LibsReset");

            lib_transfers = new List<UAFAndroidLibTransfer>(2)
            {
                new() {dir_name = "oversea", lib_files = _GetAllJarAndAar("oversea")},
                new() {dir_name = "inland", lib_files  = _GetAllJarAndAar("inland")}
            };
        }

        public void ResetShareLibs()
        {
            Undo.RecordObject(this, "UAF/Config/ShareLibsReset");

            var guids = AssetDatabase.FindAssets("a:all");

            HashSet<string> other_channel = new();
            foreach(var transfer in lib_transfers)
            {
                foreach(var file in transfer.lib_files.Split(';'))
                {
                    other_channel.Add(file);
                }
            }

            List<string> shared_aars = new();
            foreach(var guid in guids)
            {
                var full_path = AssetDatabase.GUIDToAssetPath(guid);
                if(!full_path.EndsWith("aar"))
                {
                    continue;
                }

                var file = Path.GetFileName(full_path);

                if(other_channel.Contains(file))
                {
                    continue;
                }

                shared_aars.Add(file);
            }

            share_lib_transfers = new List<UAFAndroidLibTransfer>
            {
                new() {dir_name = "share", lib_files = string.Join(";", shared_aars)}
            };
        }

        public void ResetApplyPlugins()
        {
            Undo.RecordObject(this, "UAF/Config/GoogleServiceReset");

            apply_plugins = new List<UAFAndroidApplyPlugin>
            {
                new() {apply_plugin = "apply plugin: 'com.google.gms.google-services'", dir_name = "oversea"}
            };
        }

        #endregion

        #region Tools

        private string _GetAllJarAndAar(string category)
        {
            string lib_files = string.Empty;

            string dir = $"Assets/Plugins/Android/libs/{category}";

            if(!Directory.Exists(dir))
            {
                return lib_files;
            }

            foreach(var file in Directory.GetFiles(dir, "*"))
            {
                if(!file.EndsWith("jar") && !file.EndsWith("aar"))
                {
                    continue;
                }

                lib_files = $"{lib_files};{Path.GetFileName(file)}";
            }

            return lib_files.TrimStart(';');
        }

        public static void AndroidTransmitAll(string                           android_project_path,
                                              Action<List<AGradleRebuildTask>> inject = null)
        {
            string launcher_path   = android_project_path.Replace("unityLibrary", "launcher");
            string properties_path = android_project_path.Replace("unityLibrary", "gradle.properties");

            var unity_lib_gradle = File.ReadAllText(Path.Combine(android_project_path, "build.gradle"));
            var launch_gradle    = File.ReadAllText(Path.Combine(launcher_path,        "build.gradle"));
            var properties_file  = File.ReadAllText(properties_path);

            List<AGradleRebuildTask> tasks = new()
            {
                // 生成 google-service.json 文件
                new GenGoogleService_GradleRebuildTask(android_project_path),
                // 按照渠道划分, 对 jar 文件进行转移
                new TransmitJar_GradleRebuildTask(android_project_path),
                // 按照渠道划分, 对 MainActivity.java 文件进行转移
                new TransmitJava_GradleRebuildTask(android_project_path),
                // 按照渠道划分, 动态生成 google_ad 替换 GoogleAD ID 的代码
                new GenGoogleAD_GradleRebuildTask(),
                // 动态生成 lib gradle 中渠道的 aar 引用
                new LibAarImpl_GradleRebuildTask(),
                // 动态生成 lib gradle 中渠道共用的 aar 引用
                new LibShareAarImpl_GradleRebuildTask(),
                // 动态生成 launch gradle 中渠道的划分
                new LaunchImpl_GradleRebuildTask(),
                // 动态生成 launch gradle 中渠道使用的 apply plugin
                new LaunchPlugin_GradleRebuildTask(),
                // 动态生成 lib gradle 中 IL2Cpp 动态编译
                new LibIL2CppEvaluate_GradleRebuildTask(),
                // 动态生成 lib gradle 中渠道引用的 java 路径
                new LibSourceSet_GradleRebuildTask(),
                // 生成当前 gradle 版本的 wrapper 文件, 方便后续项目运行 task
                new MakeWrapper_GradleRebuildTask(android_project_path),
                // 动态添加当前 unity 的 java home
                new AppendJavaHome_GradleRebuildTask()
            };

            inject?.Invoke(tasks);

            foreach(var task in tasks)
            {
                task.Handle(ref unity_lib_gradle, ref launch_gradle, ref properties_file);
            }

            File.WriteAllText(Path.Combine(android_project_path, "build.gradle"), unity_lib_gradle);
            File.WriteAllText(Path.Combine(launcher_path,        "build.gradle"), launch_gradle);
            File.WriteAllText(properties_path,                                    properties_file);
        }

        #endregion
    }
}