---
title: Class AppendJavaHome_GradleRebuildTask
sidebar_label: AppendJavaHome_GradleRebuildTask
---
# Class AppendJavaHome_GradleRebuildTask


###### **Assembly**: UnityAppFlavor.Editor.dll
###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/BuildPhase/Android/GenTask/AppendJavaHome_GradleRebuildTask.cs#L6)
```csharp title="Declaration"
public class AppendJavaHome_GradleRebuildTask : AGradleRebuildTask
```
## Methods
### Handle(ref string, ref string, ref string)

###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/BuildPhase/Android/GenTask/AppendJavaHome_GradleRebuildTask.cs#L8)
```csharp title="Declaration"
public override void Handle(ref string unity_lib_gradle, ref string launch_gradle, ref string properties_file)
```

##### Parameters

| Type | Name |
|:--- |:--- |
| `System.String` | *unity_lib_gradle* |
| `System.String` | *launch_gradle* |
| `System.String` | *properties_file* |

### GetOpenJDKPath()

###### [View Source](git@github.com:LiuOcean/UnityAppFlavor.git/blob/main/UnityAppFlavor/Assets/Editor/BuildPhase/Android/GenTask/AppendJavaHome_GradleRebuildTask.cs#L20)
```csharp title="Declaration"
public static string GetOpenJDKPath()
```

##### Returns

`System.String`
