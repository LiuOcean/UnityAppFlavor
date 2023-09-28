using System;
using System.IO;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UnityAppFlavor.Editor
{
    [Serializable]
    public class UAFAndroidJavaTransfer
    {
        [Required]
        [VerticalGroup("基础配置")]
        [LabelText("渠道名")]
        [UAFChannel]
        public string dir_name;

        [Required]
        [VerticalGroup("基础配置")]
        [LabelText("包名")]
        public string package_name;

        [Required]
        [VerticalGroup("Java 配置")]
        [LabelText("旧名")]
        public string java_file;

        [VerticalGroup("Java 配置")]
        [LabelText("新名")]
        public string java_file_new_name;

        public string package_dir
        {
            get
            {
                var splits = package_name.Split('.');
                return string.Join("/", splits);
            }
        }

        public string trans_dir => is_valid ? Path.Combine($"src/{dir_name}/java", package_dir) : string.Empty;

        public string final_file_name
        {
            get
            {
                if(!is_valid)
                {
                    return string.Empty;
                }

                return string.IsNullOrEmpty(java_file_new_name) ? java_file : java_file_new_name;
            }
        }

        public bool is_valid =>
            !string.IsNullOrEmpty(dir_name)     &&
            !string.IsNullOrEmpty(package_name) &&
            !string.IsNullOrEmpty(java_file)    &&
            java_file.EndsWith("java");

        public void Transmit(string android_project_path)
        {
            if(!is_valid)
            {
                Debug.LogError($"UAF java setting is invalid! dirname = {dir_name}");
                return;
            }

            var abs_trans_dir = Path.Combine(android_project_path, trans_dir);

            if(Directory.Exists(abs_trans_dir))
            {
                Directory.Delete(abs_trans_dir, true);
            }

            Directory.CreateDirectory(abs_trans_dir);

            string source_file = Path.Combine(
                android_project_path,
                "src/main/java",
                package_dir,
                java_file
            );

            string dest_file = Path.Combine(abs_trans_dir, final_file_name);

            if(!File.Exists(source_file))
            {
                Debug.LogError($"file not exists in java {dir_name} of {source_file}");
                return;
            }

            File.Move(source_file, dest_file);
        }
    }
}