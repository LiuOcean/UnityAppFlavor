using System.IO;
using UnityEditor;

namespace UnityAppFlavor.Editor
{
    public class AppendJavaHome_GradleRebuildTask : AGradleRebuildTask
    {
        public override void Handle(ref string unity_lib_gradle, ref string launch_gradle, ref string properties_file)
        {
            var java = GetOpenJDKPath();

            properties_file = _GradleReplace(
                properties_file,
                "JAVA_HOME",
                $"org.gradle.java.home={java}",
                "#"
            );
        }

        public static string GetOpenJDKPath()
        {
            string unity_root = Path.GetDirectoryName(EditorApplication.applicationPath);
#if UNITY_EDITOR_OSX
            return Path.Combine(
                unity_root,
                "PlaybackEngines",
                "AndroidPlayer",
                "OpenJDK"
            );
#else
            return Path.Combine(unity_root, "Data", "PlaybackEngines", "AndroidPlayer", "OpenJDK");
#endif
        }
    }
}