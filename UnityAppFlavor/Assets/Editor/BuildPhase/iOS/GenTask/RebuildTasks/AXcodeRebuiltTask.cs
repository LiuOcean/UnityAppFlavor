#if UNITY_IOS

using UnityEditor.iOS.Xcode;

namespace UnityAppFlavor.Editor
{
    public abstract class AXcodeRebuildTask
    {
        protected readonly UAFEditorSetting _setting = UAFEditorSetting.GetOrCreateSettings();

        public abstract void Handle(PBXProject pbx_project, string path_to_built_project, string channel_name);
    }
}
#endif