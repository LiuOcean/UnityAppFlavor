using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace UnityAppFlavor.Editor
{
    public partial class UAFEditorSetting
    {
        [Flags]
        private enum iOSResetType
        {
            None = 0,

            [LabelText("描述文件")]
            Provision = 1,
            Pod = Provision << 1,

            [LabelText("iOS 能力")]
            Capability = Provision << 1,

            [LabelText("全部")]
            All = Provision | Pod |  Capability
        }

        [LabelText("重置类型")]
        [SerializeField]
        [TabGroup(
            "Split",
            "iOS",
            SdfIconType.Apple,
            TabLayouting = TabLayouting.Shrink
        )]
        [BoxGroup("Split/iOS/Base", LabelText = "基础配置")]
        private iOSResetType _ios_rest_type = iOSResetType.All;

        [BoxGroup("Split/iOS/Base", LabelText = "基础配置")]
        [Button(ButtonSizes.Small, Name = "重置")]
        [PropertySpace(0, 10)]
        private void _ResetiOSBtn() { ResetiOS(); }

        [BoxGroup("Split/iOS/Settings", LabelText = "其他配置")]
        [FoldoutGroup("Split/iOS/Settings/描述文件")]
        [TableList(ShowIndexLabels = false, AlwaysExpanded = true)]
        [HideLabel]
        public List<UAFiOSProvision> provisions;

        [FoldoutGroup("Split/iOS/Settings/Pod")]
        [LabelText("iOS 版本")]
        [Required]
        public string pod_ios_version;

        [FoldoutGroup("Split/iOS/Settings/Pod")]
        [LabelText("Pod 源")]
        [Required]
        [TextArea(3, 5)]
        public string pod_source;

        [FoldoutGroup("Split/iOS/Settings/Pod")]
        [TableList(ShowIndexLabels = false, AlwaysExpanded = true, ScrollViewHeight = 500)]
        [HideLabel]
        public List<UAFiOSPodChannel> ios_pods;

        [TableList(ShowIndexLabels = false, AlwaysExpanded = true)]
        [FoldoutGroup("Split/iOS/Settings/能力配置")]
        [HideLabel]
        public List<UAFiOSCapability> ios_capabilities;

        [FoldoutGroup("Split/iOS/Settings/自定义配置")]
        [HideLabel]
        public AUAFiOSCustomParam ios_custom_param;
    }
}