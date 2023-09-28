using System;
using Sirenix.OdinInspector;

namespace UnityAppFlavor.Editor
{
    [Serializable]
    public class UAFCommonChannel
    {
        [Required]
        [VerticalGroup("基础配置")]
        [LabelText("别名")]
        public string alias;

        [Required]
        [VerticalGroup("基础配置")]
        [LabelText("渠道名")]
        public string name;

        [Required]
        [VerticalGroup("其他配置")]
        [LabelText("包名")]
        public string bundle_name;

        public UAFCommonChannel() { }

        public UAFCommonChannel(string alias,
                               string name,
                               string bundle_name)
        {
            this.alias         = alias;
            this.name          = name;
            this.bundle_name   = bundle_name;
        }
    }
}