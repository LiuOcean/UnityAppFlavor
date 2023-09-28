---
title: Class UAFiOSPodChannel
sidebar_label: UAFiOSPodChannel
---
# Class UAFiOSPodChannel


###### **Assembly**: UnityAppFlavor.Editor.dll
###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/iOS/UAFiOSPod.cs#L9)
```csharp title="Declaration"
[Serializable]
public class UAFiOSPodChannel
```
## Fields
### channel

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/iOS/UAFiOSPod.cs#L17)
```csharp title="Declaration"
[FormerlySerializedAs("name")]
[VerticalGroup("基础配置", 0)]
[LabelText("渠道名")]
[Required]
public string channel
```
### pods

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/iOS/UAFiOSPod.cs#L23)
```csharp title="Declaration"
[VerticalGroup("Pod", 0)]
[HideLabel]
[Required]
[TableList(AlwaysExpanded = true)]
public List<UAFiOSPod> pods
```
## Methods
### Pods2String()

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/iOS/UAFiOSPod.cs#L25)
```csharp title="Declaration"
public string Pods2String()
```

##### Returns

`System.String`
