using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace UnityAppFlavor.Editor
{
    [Serializable]
    public class UAFAndroidApplyPlugin
    {
        [HideLabel]
        [Required]
        [VerticalGroup("渠道名")]
        [UAFChannel]
        public string dir_name;

        [HideLabel]
        [VerticalGroup("Plugin 名")]
        [TextArea(4, 6)]
        public string apply_plugin;

        public string GenLaunchPlugin()
        {
            string start = $"   if (flavorType.equals('{dir_name}')) " + "{ \n";
            string body  = $"        {apply_plugin}\n";
            string end   = "   } \n";

            return$"{start}{body}{end}";
        }
    }
}