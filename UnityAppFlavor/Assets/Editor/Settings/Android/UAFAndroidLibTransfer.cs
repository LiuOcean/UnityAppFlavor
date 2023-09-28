using System;
using System.IO;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UnityAppFlavor.Editor
{
    [Serializable]
    public class UAFAndroidLibTransfer
    {
        [Required]
        [VerticalGroup("文件夹")]
        [HideLabel]
        public string dir_name;

        [HideLabel]
        [VerticalGroup("lib 文件名")]
        [TextArea(2, 4)]
        public string lib_files;

        public string trans_dir => is_valid ? $"src/{dir_name}/libs" : string.Empty;

        public bool is_valid => !string.IsNullOrEmpty(dir_name);

        public void Transmit(string android_project_path)
        {
            var abs_trans_dir = Path.Combine(android_project_path, trans_dir);

            if(Directory.Exists(abs_trans_dir))
            {
                Directory.Delete(abs_trans_dir, true);
            }

            // 优先保证目录存在
            Directory.CreateDirectory(abs_trans_dir);

            // 然后再检查配置是否合法
            if(!is_valid)
            {
                Debug.LogError($"UAF java setting is invalid! dirname = {dir_name}");
                return;
            }

            var files = lib_files.Split(';');

            foreach(var file in files)
            {
                // aar 文件不转移, 全部放在根目录 libs 下
                if(string.IsNullOrEmpty(file) || file.EndsWith(".aar"))
                {
                    continue;
                }

                string source_file = Path.Combine(android_project_path, "libs", file);
                string dest_file   = Path.Combine(abs_trans_dir,        file);

                if(!File.Exists(source_file))
                {
                    Debug.LogError($"file not exists in java {dir_name} of {source_file}");
                    continue;
                }

                File.Move(source_file, dest_file);
            }
        }

        public string GenAarImpl(bool with_channel = true, string tab = "\t\t\t\t")
        {
            string result = "";
            var    files  = lib_files.Split(';');

            foreach(var file in files)
            {
                if(!file.EndsWith(".aar"))
                {
                    continue;
                }

                var file_name = Path.GetFileNameWithoutExtension(file);

                if(with_channel)
                {
                    result += $"{tab}{dir_name}Implementation(name: '{file_name}', ext: 'aar')\n";
                }
                else
                {
                    result += $"{tab}implementation(name: '{file_name}', ext: 'aar')\n";
                }
            }

            return result;
        }

        public string GenLaunchImpl() { return$"\t{dir_name}Implementation project(':unityLibrary')\n"; }

        public string GenIL2CppEvaluate()
        {
            string first_letter_upper = dir_name.Substring(0, 1).ToUpper() + dir_name.Substring(1);

            string format = @"if (project(':unityLibrary').tasks.findByName('merge{0}DebugJniLibFolders'))
            project(':unityLibrary').merge{0}DebugJniLibFolders.dependsOn BuildIl2CppTask
        if (project(':unityLibrary').tasks.findByName('merge{0}ReleaseJniLibFolders'))
            project(':unityLibrary').merge{0}ReleaseJniLibFolders.dependsOn BuildIl2CppTask
        ";

            return string.Format(format, first_letter_upper);
        }

        public string GenSourceSet()
        {
            string start = $"\t\t{dir_name} " + "{\n";
            string body  = $"\t\t\tjava.srcDirs = ['src/{dir_name}/java', 'src/{dir_name}/java']\n";
            string end   = "\t\t}\n";

            return$"{start}{body}{end}";
        }
    }
}