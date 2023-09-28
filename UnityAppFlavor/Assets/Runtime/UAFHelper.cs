using System.Runtime.CompilerServices;
using UnityEngine;
using JetBrains.Annotations;

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
using Adaptor = UnityAppFlavor.OtherUAFAdaptor;

#elif UNITY_ANDROID
using Adaptor = UnityAppFlavor.AndroidUAFAdaptor;
#elif UNITY_IOS
using Adaptor = UnityAppFlavor.iOSUAFAdaptor;
#endif

namespace UnityAppFlavor
{
    [UsedImplicitly]
    public static class UAFHelper
    {
        #region 货币转换

        private static readonly UAFCultureMap _CULTURE_MAP;

        /// <summary>
        /// 当前货币与美元的比例
        /// </summary>
        private static double _PRICE_RATIO = 1;

        #endregion

        /// <summary>
        /// 转移部分外部回调
        /// </summary>
        internal static IUAFCallback call_back { get; set; }

        private static IUAFAdaptor _ADAPTOR;

        static UAFHelper()
        {
            _CULTURE_MAP = new UAFCultureMap();
            _ADAPTOR     = new Adaptor();

            var go = new GameObject
            {
                hideFlags = HideFlags.DontSave,
#if UNITY_EDITOR
                name = "[UAFMainThread]"
#endif
            };

            go.AddComponent<UAFMainThreadInvoke>();

            Object.DontDestroyOnLoad(go);
        }

        #region 货币本地化

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UAFCultureInfo GetCurrencyInfo(string symbol)
        {
            return _CULTURE_MAP.GetCurrencyCultureInfo(symbol);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UAFCultureInfo GetLanguageCultureInfo(SystemLanguage language)
        {
            return _CULTURE_MAP.GetLanguageCultureInfo(language);
        }

        /// <summary>
        /// 根据货币比例进行转换
        /// </summary>
        /// <param name="value"></param>
        /// <param name="keep_decimal"></param>
        /// <returns></returns>
        public static string Localize(this double value, int keep_decimal = 2)
        {
            value *= _PRICE_RATIO;

            var currency_info = _CULTURE_MAP.last_currency_info ?? _CULTURE_MAP.default_culture_info;

            return value.ToString($"C{keep_decimal}", currency_info.culture_info);
        }

        #endregion
    }
}