using System.Text.RegularExpressions;

namespace UnityAppFlavor.Editor
{
    public abstract class AGradleRebuildTask
    {
        protected readonly UAFEditorSetting _setting = UAFEditorSetting.GetOrCreateSettings();

        public abstract void Handle(ref string unity_lib_gradle, ref string launch_gradle, ref string properties_file);

        protected static string _GradleReplace(string gradle, string mark, string replace, string comment = "//")
        {
            string       start = $"{comment} {mark} START";
            const string regex = "([\\s\\S]*)";
            string       end   = $"{comment} {mark} END";

            return Regex.Replace(gradle, $"{start}{regex}{end}", $"{start}\n{replace}\n{end}\n");
        }
    }
}