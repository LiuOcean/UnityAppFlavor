#if UNITY_IOS

using UnityEditor.iOS.Xcode;

namespace UnityAppFlavor.Editor
{
    public abstract class AXcodeCapabilityTask
    {
        protected readonly UAFEditorSetting _setting = UAFEditorSetting.GetOrCreateSettings();

        public abstract void Handle(string path_to_built_project, string channel_name);

        protected ProjectCapabilityManager _GetCapabilityManager(string path_to_built_project, string channel)
        {
            var pbx_project_path = PBXProject.GetPBXProjectPath(path_to_built_project);
            var pbx_project      = new PBXProject();

            pbx_project.ReadFromFile(pbx_project_path);

            var manager = new ProjectCapabilityManager(
                pbx_project_path,
                "Entitlements.entitlements",
                "Unity-iPhone",
                pbx_project.GetUnityMainTargetGuid()
            );

            return manager;
        }
    }
}
#endif