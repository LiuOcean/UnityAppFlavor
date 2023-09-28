using Sirenix.OdinInspector.Editor;
using UnityEditor;

namespace UnityAppFlavor.Editor
{
    public static class UAFEditorSettingHelper
    {
        private static PropertyTree _PROPERTY;

        [SettingsProvider]
        public static SettingsProvider Create()
        {
            var provider = new SettingsProvider("Project/UAF", SettingsScope.Project)
            {
                label = "UAF SDK",
                guiHandler = _ =>
                {
                    if(_PROPERTY is null)
                    {
                        var settings = UAFEditorSetting.GetOrCreateSettings();
                        var so       = new SerializedObject(settings);
                        _PROPERTY = PropertyTree.Create(so);
                    }

                    _PROPERTY.Draw();
                }
            };

            return provider;
        }

    }
}