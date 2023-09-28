---
title: Class UAFEditorSetting
sidebar_label: UAFEditorSetting
---
# Class UAFEditorSetting


###### **Assembly**: UnityAppFlavor.Editor.dll
###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.iOS.Tools.cs#L9)
```csharp title="Declaration"
public class UAFEditorSetting : SerializedScriptableObject, ISerializationCallbackReceiver
```
## Fields
### gradle_version

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.Android.cs#L36)
```csharp title="Declaration"
[Required]
[LabelText("gradle 版本")]
[TabGroup("Split", "Android", false, 0)]
[BoxGroup("Split/Android/Base", true, false, 0, LabelText = "基础配置")]
public string gradle_version
```
### java_transfers

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.Android.cs#L58)
```csharp title="Declaration"
[TableList(ShowIndexLabels = false, AlwaysExpanded = true)]
[BoxGroup("Split/Android/Settings", true, false, 0, LabelText = "其他配置")]
[FoldoutGroup("Split/Android/Settings/Java 文件转移配置", 0)]
[HideLabel]
public List<UAFAndroidJavaTransfer> java_transfers
```
### lib_transfers

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.Android.cs#L63)
```csharp title="Declaration"
[TableList(ShowIndexLabels = false, AlwaysExpanded = true)]
[FoldoutGroup("Split/Android/Settings/Libs 文件转移配置", 0)]
[HideLabel]
public List<UAFAndroidLibTransfer> lib_transfers
```
### share_lib_transfers

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.Android.cs#L68)
```csharp title="Declaration"
[TableList(ShowIndexLabels = false, AlwaysExpanded = true)]
[FoldoutGroup("Split/Android/Settings/Share Libs 文件转移配置", 0)]
[HideLabel]
public List<UAFAndroidLibTransfer> share_lib_transfers
```
### apply_plugins

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.Android.cs#L73)
```csharp title="Declaration"
[TableList(ShowIndexLabels = false, AlwaysExpanded = true)]
[FoldoutGroup("Split/Android/Settings/Apply Plugins 配置", 0)]
[HideLabel]
public List<UAFAndroidApplyPlugin> apply_plugins
```
### android_custom_param

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.Android.cs#L77)
```csharp title="Declaration"
[FoldoutGroup("Split/Android/Settings/自定义配置", 0)]
[HideLabel]
public AUAFAndroidCustomParam android_custom_param
```
### provisions

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.iOS.cs#L46)
```csharp title="Declaration"
[BoxGroup("Split/iOS/Settings", true, false, 0, LabelText = "其他配置")]
[FoldoutGroup("Split/iOS/Settings/描述文件", 0)]
[TableList(ShowIndexLabels = false, AlwaysExpanded = true)]
[HideLabel]
public List<UAFiOSProvision> provisions
```
### pod_ios_version

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.iOS.cs#L51)
```csharp title="Declaration"
[FoldoutGroup("Split/iOS/Settings/Pod", 0)]
[LabelText("iOS 版本")]
[Required]
public string pod_ios_version
```
### pod_source

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.iOS.cs#L57)
```csharp title="Declaration"
[FoldoutGroup("Split/iOS/Settings/Pod", 0)]
[LabelText("Pod 源")]
[Required]
[TextArea(3, 5)]
public string pod_source
```
### ios_pods

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.iOS.cs#L62)
```csharp title="Declaration"
[FoldoutGroup("Split/iOS/Settings/Pod", 0)]
[TableList(ShowIndexLabels = false, AlwaysExpanded = true, ScrollViewHeight = 500)]
[HideLabel]
public List<UAFiOSPodChannel> ios_pods
```
### ios_capabilities

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.iOS.cs#L67)
```csharp title="Declaration"
[TableList(ShowIndexLabels = false, AlwaysExpanded = true)]
[FoldoutGroup("Split/iOS/Settings/能力配置", 0)]
[HideLabel]
public List<UAFiOSCapability> ios_capabilities
```
### ios_custom_param

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.iOS.cs#L71)
```csharp title="Declaration"
[FoldoutGroup("Split/iOS/Settings/自定义配置", 0)]
[HideLabel]
public AUAFiOSCustomParam ios_custom_param
```
### channels

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.cs#L17)
```csharp title="Declaration"
[TabGroup("Split", "Common", SdfIconType.Bank, false, 0)]
[TableList(AlwaysExpanded = true, ShowIndexLabels = false)]
[HideLabel]
[PropertyOrder(-1)]
public List<UAFCommonChannel> channels
```
## Methods
### ResetJava()

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.Android.Tools.cs#L12)
```csharp title="Declaration"
public void ResetJava()
```
### ResetLibs()

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.Android.Tools.cs#L29)
```csharp title="Declaration"
public void ResetLibs()
```
### ResetShareLibs()

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.Android.Tools.cs#L40)
```csharp title="Declaration"
public void ResetShareLibs()
```
### ResetApplyPlugins()

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.Android.Tools.cs#L80)
```csharp title="Declaration"
public void ResetApplyPlugins()
```
### AndroidTransmitAll(string, Action&lt;List&lt;AGradleRebuildTask&gt;&gt;)

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.Android.Tools.cs#L118)
```csharp title="Declaration"
public static void AndroidTransmitAll(string android_project_path, Action<List<AGradleRebuildTask>> inject = null)
```

##### Parameters

| Type | Name |
|:--- |:--- |
| `System.String` | *android_project_path* |
| `System.Action<System.Collections.Generic.List<UnityAppFlavor.Editor.AGradleRebuildTask>>` | *inject* |

### ResetCommon()

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.cs#L19)
```csharp title="Declaration"
[TabGroup("Split", "Common", SdfIconType.Bank, false, 0)]
[Button(ButtonSizes.Small, Name = "重置")]
[PropertyOrder(-1)]
public void ResetCommon()
```
### ResetAll()

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.cs#L38)
```csharp title="Declaration"
public void ResetAll()
```
### ResetAndroid()

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.cs#L45)
```csharp title="Declaration"
public void ResetAndroid()
```
### ResetiOS()

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.cs#L68)
```csharp title="Declaration"
public void ResetiOS()
```
### GetOrCreateSettings()

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.cs#L90)
```csharp title="Declaration"
public static UAFEditorSetting GetOrCreateSettings()
```

##### Returns

[UnityAppFlavor.Editor.UAFEditorSetting](../UnityAppFlavor.Editor/UAFEditorSetting.md)
### ResetProvision()

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.iOS.Tools.cs#L11)
```csharp title="Declaration"
public void ResetProvision()
```
### ResetPod()

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.iOS.Tools.cs#L18)
```csharp title="Declaration"
public void ResetPod()
```
### ResetiOSCapability()

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/UAFEditorSetting.iOS.Tools.cs#L47)
```csharp title="Declaration"
public void ResetiOSCapability()
```

## Implements

* `UnityEngine.ISerializationCallbackReceiver`
