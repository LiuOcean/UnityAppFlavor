#if UNITY_IOS

namespace UnityAppFlavor.Editor
{
    public class AddGeneral_XcodeCapabilityTask : AXcodeCapabilityTask
    {
        public override void Handle(string path_to_built_project, string channel_name)
        {
            foreach(var capability in _setting.ios_capabilities)
            {
                if(!string.Equals(channel_name, capability.channel))
                {
                    continue;
                }

                var manager = _GetCapabilityManager(path_to_built_project, capability.channel);

                if(capability.push_notifications)
                {
                    manager.AddPushNotifications(capability.push_notifications_dev);
                }

                if(capability.background_modes)
                {
                    manager.AddBackgroundModes(capability.background_modes_options);
                }

                if(capability.iap)
                {
                    manager.AddInAppPurchase();
                }

                if(capability.sign_in_with_apple)
                {
                    manager.AddSignInWithApple();
                }

                // 这个 manager Unity 设计的并不好, 为了防止覆盖写入, 所以每次循环结束, 都需要重新写入一次
                manager.WriteToFile();
            }
        }
    }
}
#endif