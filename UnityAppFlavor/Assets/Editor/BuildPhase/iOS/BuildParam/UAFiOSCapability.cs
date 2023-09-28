using System;
using Sirenix.OdinInspector;

namespace UnityAppFlavor.Editor
{
    [Serializable]
    public class UAFiOSCapability
    {
        [VerticalGroup("基础")]
        [VerticalGroup("基础/配置")]
        [LabelText("渠道")]
        [UAFChannel]
        public string channel;

        [VerticalGroup("基础/配置")]
        [LabelText("支付")]
        public bool iap = true;

        [VerticalGroup("基础/配置")]
        [LabelText("苹果登录")]
        public bool sign_in_with_apple = true;


        [VerticalGroup("后台")]
        [VerticalGroup("后台/background")]
        [LabelText("后台")]
        public bool background_modes = true;

#if UNITY_IOS

        [ShowIf("@this.background_modes")]
        [VerticalGroup("后台/background")]
        [LabelText("后台选项")]
        public UnityEditor.iOS.Xcode.BackgroundModesOptions background_modes_options =
            UnityEditor.iOS.Xcode.BackgroundModesOptions.RemoteNotifications;
#endif

        [VerticalGroup("推送")]
        [VerticalGroup("推送/push")]
        [LabelText("推送")]
        public bool push_notifications = true;

        [ShowIf("@this.push_notifications")]
        [VerticalGroup("推送/push")]
        [LabelText("Dev")]
        public bool push_notifications_dev = true;

        public UAFiOSCapability() { }

        public UAFiOSCapability(string channel) { this.channel = channel; }
    }
}