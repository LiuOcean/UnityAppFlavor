using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace UnityAppFlavor.Editor
{
    public partial class UAFEditorSetting
    {
        [Flags]
        private enum AndroidResetType
        {
            None = 0,

            [LabelText("Java 文件转移配置")]
            Java = 1,

            [LabelText("Libs 文件转移配置")]
            Libs = Java << 1,

            [LabelText("Share Libs 文件转移配置")]
            ShareLibs = Libs << 1,

            [LabelText("Apply Plugins 配置")]
            ApplyPlugins = ShareLibs << 1,

            [LabelText("全部")]
            All = Java | Libs | ShareLibs | ApplyPlugins
        }

        [Required]
        [LabelText("gradle 版本")]
        [TabGroup("Split", "Android")]
        [BoxGroup("Split/Android/Base", LabelText = "基础配置")]
        public string gradle_version = "6.1.1";

        [LabelText("重置类型")]
        [SerializeField]
        [TabGroup(
            "Split",
            "Android",
            SdfIconType.Google,
            TabLayouting = TabLayouting.Shrink
        )]
        [BoxGroup("Split/Android/Base", LabelText = "基础配置")]
        private AndroidResetType _android_rest_type = AndroidResetType.All;

        [BoxGroup("Split/Android/Base", LabelText = "基础配置")]
        [Button(ButtonSizes.Small, Name = "重置")]
        [PropertySpace(0, 10)]
        private void _ResetAndroidBtn() { ResetAndroid(); }

        [TableList(ShowIndexLabels = false, AlwaysExpanded = true)]
        [BoxGroup("Split/Android/Settings", LabelText = "其他配置")]
        [FoldoutGroup("Split/Android/Settings/Java 文件转移配置")]
        [HideLabel]
        public List<UAFAndroidJavaTransfer> java_transfers;

        [TableList(ShowIndexLabels = false, AlwaysExpanded = true)]
        [FoldoutGroup("Split/Android/Settings/Libs 文件转移配置")]
        [HideLabel]
        public List<UAFAndroidLibTransfer> lib_transfers;

        [TableList(ShowIndexLabels = false, AlwaysExpanded = true)]
        [FoldoutGroup("Split/Android/Settings/Share Libs 文件转移配置")]
        [HideLabel]
        public List<UAFAndroidLibTransfer> share_lib_transfers;

        [TableList(ShowIndexLabels = false, AlwaysExpanded = true)]
        [FoldoutGroup("Split/Android/Settings/Apply Plugins 配置")]
        [HideLabel]
        public List<UAFAndroidApplyPlugin> apply_plugins;

        [FoldoutGroup("Split/Android/Settings/自定义配置")]
        [HideLabel]
        public AUAFAndroidCustomParam android_custom_param;
    }
}