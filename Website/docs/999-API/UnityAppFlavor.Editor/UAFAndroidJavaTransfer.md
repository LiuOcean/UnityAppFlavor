---
title: Class UAFAndroidJavaTransfer
sidebar_label: UAFAndroidJavaTransfer
---
# Class UAFAndroidJavaTransfer


###### **Assembly**: UnityAppFlavor.Editor.dll
###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidJavaTransfer.cs#L8)
```csharp title="Declaration"
[Serializable]
public class UAFAndroidJavaTransfer
```
## Properties
### package_dir

###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidJavaTransfer.cs#L31)
```csharp title="Declaration"
public string package_dir { get; }
```
### trans_dir

###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidJavaTransfer.cs#L40)
```csharp title="Declaration"
public string trans_dir { get; }
```
### final_file_name

###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidJavaTransfer.cs#L42)
```csharp title="Declaration"
public string final_file_name { get; }
```
### is_valid

###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidJavaTransfer.cs#L55)
```csharp title="Declaration"
public bool is_valid { get; }
```
## Fields
### dir_name

###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidJavaTransfer.cs#L15)
```csharp title="Declaration"
[Required]
[VerticalGroup("基础配置", 0)]
[LabelText("渠道名")]
public string dir_name
```
### package_name

###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidJavaTransfer.cs#L20)
```csharp title="Declaration"
[Required]
[VerticalGroup("基础配置", 0)]
[LabelText("包名")]
public string package_name
```
### java_file

###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidJavaTransfer.cs#L25)
```csharp title="Declaration"
[Required]
[VerticalGroup("Java 配置", 0)]
[LabelText("旧名")]
public string java_file
```
### java_file_new_name

###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidJavaTransfer.cs#L29)
```csharp title="Declaration"
[VerticalGroup("Java 配置", 0)]
[LabelText("新名")]
public string java_file_new_name
```
## Methods
### Transmit(string)

###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidJavaTransfer.cs#L61)
```csharp title="Declaration"
public void Transmit(string android_project_path)
```

##### Parameters

| Type | Name |
|:--- |:--- |
| `System.String` | *android_project_path* |

