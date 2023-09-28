---
title: Class UAFCultureMap
sidebar_label: UAFCultureMap
---
# Class UAFCultureMap


###### **Assembly**: UnityAppFlavor.dll
###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Runtime/Defines/UAFCultureInfo.cs#L32)
```csharp title="Declaration"
public class UAFCultureMap
```
## Properties
### last_currency_info

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Runtime/Defines/UAFCultureInfo.cs#L84)
```csharp title="Declaration"
public UAFCultureInfo last_currency_info { get; }
```
### last_language_info

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Runtime/Defines/UAFCultureInfo.cs#L86)
```csharp title="Declaration"
public UAFCultureInfo last_language_info { get; }
```
## Methods
### GetCountryCultureInfo(string)

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Runtime/Defines/UAFCultureInfo.cs#L106)
```csharp title="Declaration"
public UAFCultureInfo GetCountryCultureInfo(string alpha_2_country_code)
```

##### Returns

[UnityAppFlavor.UAFCultureInfo](../UnityAppFlavor/UAFCultureInfo.md)

##### Parameters

| Type | Name |
|:--- |:--- |
| `System.String` | *alpha_2_country_code* |

### GetLanguageCultureInfo(SystemLanguage)

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Runtime/Defines/UAFCultureInfo.cs#L114)
```csharp title="Declaration"
public UAFCultureInfo GetLanguageCultureInfo(SystemLanguage system_language)
```

##### Returns

[UnityAppFlavor.UAFCultureInfo](../UnityAppFlavor/UAFCultureInfo.md)

##### Parameters

| Type | Name |
|:--- |:--- |
| `UnityEngine.SystemLanguage` | *system_language* |

### GetCurrencyCultureInfo(string)

###### [View Source](https://github.com/LiuOcean/UnityAppFlavor/blob/main/UnityAppFlavor/Assets/Runtime/Defines/UAFCultureInfo.cs#L126)
```csharp title="Declaration"
public UAFCultureInfo GetCurrencyCultureInfo(string currency_code)
```

##### Returns

[UnityAppFlavor.UAFCultureInfo](../UnityAppFlavor/UAFCultureInfo.md)

##### Parameters

| Type | Name |
|:--- |:--- |
| `System.String` | *currency_code* |

