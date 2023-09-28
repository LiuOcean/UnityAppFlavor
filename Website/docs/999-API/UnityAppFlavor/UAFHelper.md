---
title: Class UAFHelper
sidebar_label: UAFHelper
---
# Class UAFHelper


###### **Assembly**: UnityAppFlavor.dll
###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Runtime/UAFHelper.cs#L16)
```csharp title="Declaration"
[UsedImplicitly]
public static class UAFHelper
```
## Methods
### GetCurrencyInfo(string)

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Runtime/UAFHelper.cs#L57)
```csharp title="Declaration"
public static UAFCultureInfo GetCurrencyInfo(string symbol)
```

##### Returns

[UnityAppFlavor.UAFCultureInfo](../UnityAppFlavor/UAFCultureInfo.md)

##### Parameters

| Type | Name |
|:--- |:--- |
| `System.String` | *symbol* |

### GetLanguageCultureInfo(SystemLanguage)

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Runtime/UAFHelper.cs#L63)
```csharp title="Declaration"
public static UAFCultureInfo GetLanguageCultureInfo(SystemLanguage language)
```

##### Returns

[UnityAppFlavor.UAFCultureInfo](../UnityAppFlavor/UAFCultureInfo.md)

##### Parameters

| Type | Name |
|:--- |:--- |
| `UnityEngine.SystemLanguage` | *language* |

### Localize(double, int)
根据货币比例进行转换
###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Runtime/UAFHelper.cs#L75)
```csharp title="Declaration"
public static string Localize(this double value, int keep_decimal = 2)
```

##### Returns

`System.String`

##### Parameters

| Type | Name |
|:--- |:--- |
| `System.Double` | *value* |
| `System.Int32` | *keep_decimal* |

