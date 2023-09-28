using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UnityAppFlavor
{
    public class UAFCultureInfo
    {
        public readonly CultureInfo culture_info;
        public readonly RegionInfo  region_info;

        public string symbol => region_info.CurrencySymbol;

        public string iso_symbol => region_info.ISOCurrencySymbol;

        public string region_name => region_info.TwoLetterISORegionName;

        public UAFCultureInfo(string name)
        {
            culture_info = new CultureInfo(name);
            region_info  = new RegionInfo(culture_info.LCID);
        }

        public UAFCultureInfo(CultureInfo culture_info)
        {
            this.culture_info = culture_info;
            region_info       = new RegionInfo(culture_info.LCID);
        }
    }

    public class UAFCultureMap
    {
        private readonly Dictionary<string, UAFCultureInfo> _alpha_2_country_info = new();
        private readonly Dictionary<string, UAFCultureInfo> _currency_info        = new();

        private readonly Dictionary<SystemLanguage, UAFCultureInfo> _system_language_info = new()
        {
            {SystemLanguage.Afrikaans, new("af-ZA")},
            {SystemLanguage.Arabic, new("ar-SA")},
            {SystemLanguage.Basque, new("eu-ES")},
            {SystemLanguage.Belarusian, new("be-BY")},
            {SystemLanguage.Bulgarian, new("bg-BG")},
            {SystemLanguage.Catalan, new("ca-ES")},
            {SystemLanguage.Chinese, new("zh-CN")},
            {SystemLanguage.ChineseSimplified, new("zh-CN")},
            {SystemLanguage.ChineseTraditional, new("zh-TW")},
            {SystemLanguage.Czech, new("cs-CZ")},
            {SystemLanguage.Danish, new("da-DK")},
            {SystemLanguage.Dutch, new("nl-NL")},
            {SystemLanguage.English, new("en-US")},
            {SystemLanguage.Estonian, new("et-EE")},
            {SystemLanguage.Faroese, new("fo-FO")},
            {SystemLanguage.Finnish, new("fi-FI")},
            {SystemLanguage.French, new("fr-FR")},
            {SystemLanguage.German, new("de-DE")},
            {SystemLanguage.Greek, new("el-GR")},
            {SystemLanguage.Hebrew, new("he-IL")},
            {SystemLanguage.Hungarian, new("hu-HU")},
            {SystemLanguage.Icelandic, new("is-IS")},
            {SystemLanguage.Indonesian, new("id-ID")},
            {SystemLanguage.Italian, new("it-IT")},
            {SystemLanguage.Japanese, new("ja-JP")},
            {SystemLanguage.Korean, new("ko-KR")},
            {SystemLanguage.Latvian, new("lv-LV")},
            {SystemLanguage.Lithuanian, new("lt-LT")},
            {SystemLanguage.Polish, new("pl-PL")},
            {SystemLanguage.Portuguese, new("pt-PT")},
            {SystemLanguage.Romanian, new("ro-RO")},
            {SystemLanguage.Russian, new("ru-RU")},
            {SystemLanguage.Slovak, new("sk-SK")},
            {SystemLanguage.Slovenian, new("sl-SI")},
            {SystemLanguage.Spanish, new("es-ES")},
            {SystemLanguage.Swedish, new("sv-SE")},
            {SystemLanguage.Thai, new("th-TH")},
            {SystemLanguage.Turkish, new("tr-TR")},
            {SystemLanguage.Ukrainian, new("uk-UA")},
            {SystemLanguage.Vietnamese, new("vi-VN")},
            {SystemLanguage.Unknown, new("en-US")}
        };

        internal readonly UAFCultureInfo default_culture_info;

        public UAFCultureInfo last_currency_info { get; private set; }

        public UAFCultureInfo last_language_info { get; private set; }

        public UAFCultureMap(CultureInfo default_culture_info = null)
        {
            default_culture_info ??= new CultureInfo("en-US");

            this.default_culture_info = new(default_culture_info);

            foreach(CultureInfo culture in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                var region = new RegionInfo(culture.LCID);

                // ISO 3166-1 alpha-2 会重复, 以第一个为准
                _alpha_2_country_info.TryAdd(region.TwoLetterISORegionName, new(culture));

                // ISO 4217
                _currency_info.TryAdd(region.ISOCurrencySymbol, new(culture));
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UAFCultureInfo GetCountryCultureInfo(string alpha_2_country_code)
        {
            return _alpha_2_country_info.TryGetValue(alpha_2_country_code, out var culture_info)
                ? culture_info
                : default_culture_info;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UAFCultureInfo GetLanguageCultureInfo(SystemLanguage system_language)
        {
            if(!_system_language_info.TryGetValue(system_language, out var culture_info))
            {
                return default_culture_info;
            }

            last_language_info = culture_info;
            return culture_info;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public UAFCultureInfo GetCurrencyCultureInfo(string currency_code)
        {
            if(!_currency_info.TryGetValue(currency_code, out var culture_info))
            {
                return default_culture_info;
            }

            last_currency_info = culture_info;
            return culture_info;
        }
    }
}