using System;
using Sirenix.OdinInspector;

namespace UnityAppFlavor.Editor
{
    [Serializable]
    public class UAFiOSProvision
    {
        [VerticalGroup("渠道名")]
        [HideLabel]
        [UAFChannel]
        [Required]
        public string channel;

        [VerticalGroup("描述文件 UUID")]
        [HorizontalGroup("描述文件 UUID/UUID")]
        [HideLabel]
        [Required]
        public string uuid;

        [HorizontalGroup("描述文件 UUID/UUID", 50)]
        [Button("获取", ButtonSizes.Small)]
        private void _Browse() { uuid = ProvisionHelper.GetUUID(); }
    }
}