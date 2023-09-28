---
title: Class UAFAndroidLibTransfer
sidebar_label: UAFAndroidLibTransfer
---
# Class UAFAndroidLibTransfer


###### **Assembly**: UnityAppFlavor.Editor.dll
###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidLibTransfer.cs#L8)
```csharp title="Declaration"
[Serializable]
public class UAFAndroidLibTransfer
```
## Properties
### trans_dir

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidLibTransfer.cs#L21)
```csharp title="Declaration"
public string trans_dir { get; }
```
### is_valid

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidLibTransfer.cs#L23)
```csharp title="Declaration"
public bool is_valid { get; }
```
## Fields
### dir_name

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidLibTransfer.cs#L14)
```csharp title="Declaration"
[Required]
[VerticalGroup("文件夹", 0)]
[HideLabel]
public string dir_name
```
### lib_files

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidLibTransfer.cs#L19)
```csharp title="Declaration"
[HideLabel]
[VerticalGroup("lib 文件名", 0)]
[TextArea(2, 4)]
public string lib_files
```
## Methods
### Transmit(string)

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidLibTransfer.cs#L25)
```csharp title="Declaration"
public void Transmit(string android_project_path)
```

##### Parameters

| Type | Name |
|:--- |:--- |
| `System.String` | *android_project_path* |

### GenAarImpl(bool, string)

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidLibTransfer.cs#L67)
```csharp title="Declaration"
public string GenAarImpl(bool with_channel = true, string tab = "\t\t\t\t")
```

##### Returns

`System.String`

##### Parameters

| Type | Name |
|:--- |:--- |
| `System.Boolean` | *with_channel* |
| `System.String` | *tab* |

### GenLaunchImpl()

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidLibTransfer.cs#L94)
```csharp title="Declaration"
public string GenLaunchImpl()
```

##### Returns

`System.String`
### GenIL2CppEvaluate()

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidLibTransfer.cs#L96)
```csharp title="Declaration"
public string GenIL2CppEvaluate()
```

##### Returns

`System.String`
### GenSourceSet()

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/Settings/Android/UAFAndroidLibTransfer.cs#L109)
```csharp title="Declaration"
public string GenSourceSet()
```

##### Returns

`System.String`
