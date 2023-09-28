using System.Collections.Generic;
using System.IO;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace UnityAppFlavor.Editor
{
    public partial class UAFEditorSetting : SerializedScriptableObject
    {
        private const string _PATH = "Assets/Editor/UAFEditorSetting.asset";

        [TabGroup("Split", "Common", SdfIconType.Bank)]
        [TableList(AlwaysExpanded = true, ShowIndexLabels = false)]
        [HideLabel]
        [PropertyOrder(-1)]
        public List<UAFCommonChannel> channels;

        [TabGroup("Split", "Common", SdfIconType.Bank)]
        [Button(ButtonSizes.Small, Name = "重置")]
        [PropertyOrder(-1)]
        public void ResetCommon()
        {
            // @formatter:off
            channels = new List<UAFCommonChannel> {
                new("海外", "oversea", "com.company.demo"),
                new("国内", "inland", "com.company.demo.cn")
            };
            // @formatter:on
        }

        [Button(ButtonSizes.Small, Name = "Ping 配置")]
        [PropertyOrder(-2)]
        private void _PinAsset() { EditorGUIUtility.PingObject(this); }

        #region Reset

        public void ResetAll()
        {
            ResetCommon();
            ResetAndroid();
            ResetiOS();
        }

        public void ResetAndroid()
        {
            if(_android_rest_type.HasFlag(AndroidResetType.Java))
            {
                ResetJava();
            }

            if(_android_rest_type.HasFlag(AndroidResetType.Libs))
            {
                ResetLibs();
            }

            if(_android_rest_type.HasFlag(AndroidResetType.ShareLibs))
            {
                ResetShareLibs();
            }

            if(_android_rest_type.HasFlag(AndroidResetType.ApplyPlugins))
            {
                ResetApplyPlugins();
            }
        }

        public void ResetiOS()
        {
            if(_ios_rest_type.HasFlag(iOSResetType.Provision))
            {
                ResetProvision();
            }

            if(_ios_rest_type.HasFlag(iOSResetType.Pod))
            {
                ResetPod();
            }

            if(_ios_rest_type.HasFlag(iOSResetType.Capability))
            {
                ResetiOSCapability();
            }
        }

        #endregion

        private static UAFEditorSetting _instance;

        public static UAFEditorSetting GetOrCreateSettings()
        {
            if(_instance != null)
            {
                return _instance;
            }

            var guids = AssetDatabase.FindAssets($"t:ScriptableObject {nameof(UAFEditorSetting)}");
            
            if(guids.Length > 1)
            {
                Debug.LogWarning("Found multiple settings files, using the first.");
            }

            switch(guids.Length)
            {
                case 0:
                    var settings = CreateInstance<UAFEditorSetting>();

                    if(!Directory.Exists("Assets/Editor"))
                    {
                        Directory.CreateDirectory("Assets/Editor");
                    }

                    AssetDatabase.CreateAsset(settings, _PATH);

                    _instance = settings;

                    // 先赋值, 才能进行重置, 否则会导致死循环
                    settings.ResetAll();

                    break;

                default:
                    var path = AssetDatabase.GUIDToAssetPath(guids[0]);
                    _instance = AssetDatabase.LoadAssetAtPath<UAFEditorSetting>(path);
                    break;
            }

            return _instance;
        }
    }
}