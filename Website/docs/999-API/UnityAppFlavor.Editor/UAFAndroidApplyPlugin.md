---
title: Class UAFAndroidApplyPlugin
sidebar_label: UAFAndroidApplyPlugin
---
# Class UAFAndroidApplyPlugin


###### **Assembly**: UnityAppFlavor.Editor.dll
###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidApplyPlugin.cs#L8)
```csharp title="Declaration"
[Serializable]
public class UAFAndroidApplyPlugin
```
## Fields
### dir_name

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidApplyPlugin.cs#L15)
```csharp title="Declaration"
[HideLabel]
[Required]
[VerticalGroup("渠道名", 0)]
public string dir_name
```
### apply_plugin

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidApplyPlugin.cs#L20)
```csharp title="Declaration"
[HideLabel]
[VerticalGroup("Plugin 名", 0)]
[TextArea(4, 6)]
public string apply_plugin
```
## Methods
### GenLaunchPlugin()

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidApplyPlugin.cs#L22)
```csharp title="Declaration"
public string GenLaunchPlugin()
```

##### Returns

`System.String`
