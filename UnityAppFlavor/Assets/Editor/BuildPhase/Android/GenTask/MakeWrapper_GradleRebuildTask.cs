using System.Diagnostics;
using System.IO;
using UnityEditor;
using Debug = UnityEngine.Debug;

namespace UnityAppFlavor.Editor
{
    /// <summary>
    /// https://github.com/gilzoide/unity-gradle-wrapper
    /// </summary>
    public class MakeWrapper_GradleRebuildTask : AGradleRebuildTask
    {
        private readonly string _android_project_path;

        public MakeWrapper_GradleRebuildTask(string android_project_path) =>
            _android_project_path = android_project_path;

        public override void Handle(ref string unity_lib_gradle, ref string launch_gradle, ref string properties_file)
        {
            if(!EditorUserBuildSettings.exportAsGoogleAndroidProject)
            {
                return;
            }

            string gradle_version = UAFEditorSetting.GetOrCreateSettings().gradle_version;

            if(string.IsNullOrWhiteSpace(gradle_version))
            {
                return;
            }

            // Use project's root folder instead of /unityLibrary
            var path = Path.GetDirectoryName(_android_project_path);

            // Using an empty build script makes Gradle skip configuring the
            // whole project.
            // Useful in case the build scripts are incompatible with the
            // version of Gradle that will generate the wrapper.
            string empty_gradle_script_file = "empty.gradle";
            string empty_gradle_script_path = Path.Combine(path!, empty_gradle_script_file);
            File.WriteAllText(empty_gradle_script_path, "");

            var start_info = new ProcessStartInfo
            {
                FileName = _FindJavaExecutable(),
                Arguments =
                    $"-jar \"{_FindGradleJar()}\" wrapper --gradle-version {gradle_version} -b {empty_gradle_script_file} --no-daemon",
                RedirectStandardError = true,
                UseShellExecute       = false,
                CreateNoWindow        = true,
                WorkingDirectory      = path
            };

            Debug.Log(
                $"[{nameof(MakeWrapper_GradleRebuildTask)}] Running `\"{start_info.FileName}\" {start_info.Arguments}`"
            );

            using(var process = Process.Start(start_info))
            {
                string stderr = process!.StandardError.ReadToEnd();
                if(!string.IsNullOrWhiteSpace(stderr))
                {
                    Debug.LogError($"[{nameof(MakeWrapper_GradleRebuildTask)}] {stderr.Trim()}");
                }

                process.WaitForExit();
            }

            File.Delete(empty_gradle_script_path);
        }

        private static string _FindJavaExecutable()
        {
#if UNITY_2019_3_OR_NEWER && UNITY_ANDROID
            string java_root = !string.IsNullOrEmpty(UnityEditor.Android.AndroidExternalToolsSettings.jdkRootPath)
                ? UnityEditor.Android.AndroidExternalToolsSettings.jdkRootPath
                : Path.Combine(_GetUnityAndroidPlayerRoot(), "OpenJDK");
#else
            string java_root = Path.Combine(_GetUnityAndroidPlayerRoot(), "OpenJDK");
#endif
#if UNITY_EDITOR_WIN
            string java_exe = Path.Combine(java_root, "bin", "java.exe");
#else
            string java_exe = Path.Combine(java_root, "bin", "java");
#endif
            if(File.Exists(java_exe))
            {
                return java_exe;
            }

            Debug.LogWarning(
                $"[{nameof(MakeWrapper_GradleRebuildTask)}] Unable to find Java executable at '{java_exe}'. Falling back to system's `java` command"
            );
            return"java";
        }

        private static string _FindGradleJar()
        {
#if UNITY_2019_3_OR_NEWER && UNITY_ANDROID
            string gradle_root = !string.IsNullOrEmpty(UnityEditor.Android.AndroidExternalToolsSettings.gradlePath)
                ? UnityEditor.Android.AndroidExternalToolsSettings.gradlePath
                : Path.Combine(_GetUnityAndroidPlayerRoot(), "Tools", "gradle");
#else
            string gradle_root = Path.Combine(_GetUnityAndroidPlayerRoot(), "Tools", "gradle");
#endif
            return _FindFirstFileWithPattern(Path.Combine(gradle_root, "lib"), "gradle-launcher*.jar");
        }

        private static string _GetUnityAndroidPlayerRoot()
        {
            string unity_root = Path.GetDirectoryName(EditorApplication.applicationPath);
#if UNITY_EDITOR_OSX
            return Path.Combine(unity_root, "PlaybackEngines", "AndroidPlayer");
#else
            return Path.Combine(unity_root, "Data", "PlaybackEngines", "AndroidPlayer");
#endif
        }

        private static string _FindFirstFileWithPattern(string dir, string pattern)
        {
            string[] files = Directory.GetFiles(dir, pattern);
            if(files.Length == 0)
            {
                throw new FileNotFoundException($"Couldn't find any file with pattern '{pattern}' in '{dir}'");
            }

            return files[0];
        }
    }
}