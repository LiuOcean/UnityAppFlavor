---
title: Class UAFiOSCapability
sidebar_label: UAFiOSCapability
---
# Class UAFiOSCapability


###### **Assembly**: UnityAppFlavor.Editor.dll
###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/BuildPhase/iOS/BuildParam/UAFiOSCapability.cs#L6)
```csharp title="Declaration"
[Serializable]
public class UAFiOSCapability
```
## Fields
### channel

###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/BuildPhase/iOS/BuildParam/UAFiOSCapability.cs#L13)
```csharp title="Declaration"
[VerticalGroup("基础", 0)]
[VerticalGroup("基础/配置", 0)]
[LabelText("渠道")]
public string channel
```
### iap

###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/BuildPhase/iOS/BuildParam/UAFiOSCapability.cs#L17)
```csharp title="Declaration"
[VerticalGroup("基础/配置", 0)]
[LabelText("支付")]
public bool iap
```
### sign_in_with_apple

###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/BuildPhase/iOS/BuildParam/UAFiOSCapability.cs#L21)
```csharp title="Declaration"
[VerticalGroup("基础/配置", 0)]
[LabelText("苹果登录")]
public bool sign_in_with_apple
```
### background_modes

###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/BuildPhase/iOS/BuildParam/UAFiOSCapability.cs#L27)
```csharp title="Declaration"
[VerticalGroup("后台", 0)]
[VerticalGroup("后台/background", 0)]
[LabelText("后台")]
public bool background_modes
```
### push_notifications

###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/BuildPhase/iOS/BuildParam/UAFiOSCapability.cs#L41)
```csharp title="Declaration"
[VerticalGroup("推送", 0)]
[VerticalGroup("推送/push", 0)]
[LabelText("推送")]
public bool push_notifications
```
### push_notifications_dev

###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/BuildPhase/iOS/BuildParam/UAFiOSCapability.cs#L46)
```csharp title="Declaration"
[ShowIf("@this.push_notifications", true)]
[VerticalGroup("推送/push", 0)]
[LabelText("Dev")]
public bool push_notifications_dev
```
