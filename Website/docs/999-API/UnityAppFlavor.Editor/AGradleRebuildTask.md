---
title: Class AGradleRebuildTask
sidebar_label: AGradleRebuildTask
---
# Class AGradleRebuildTask


###### **Assembly**: UnityAppFlavor.Editor.dll
###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/BuildPhase/Android/GenTask/AGradleRebuildTask.cs#L5)
```csharp title="Declaration"
public abstract class AGradleRebuildTask
```
## Fields
### _setting

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/BuildPhase/Android/GenTask/AGradleRebuildTask.cs#L7)
```csharp title="Declaration"
protected readonly UAFEditorSetting _setting
```
## Methods
### Handle(ref string, ref string, ref string)

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/BuildPhase/Android/GenTask/AGradleRebuildTask.cs#L9)
```csharp title="Declaration"
public abstract void Handle(ref string unity_lib_gradle, ref string launch_gradle, ref string properties_file)
```

##### Parameters

| Type | Name |
|:--- |:--- |
| `System.String` | *unity_lib_gradle* |
| `System.String` | *launch_gradle* |
| `System.String` | *properties_file* |

### _GradleReplace(string, string, string, string)

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Editor/BuildPhase/Android/GenTask/AGradleRebuildTask.cs#L11)
```csharp title="Declaration"
protected static string _GradleReplace(string gradle, string mark, string replace, string comment = "//")
```

##### Returns

`System.String`

##### Parameters

| Type | Name |
|:--- |:--- |
| `System.String` | *gradle* |
| `System.String` | *mark* |
| `System.String` | *replace* |
| `System.String` | *comment* |

