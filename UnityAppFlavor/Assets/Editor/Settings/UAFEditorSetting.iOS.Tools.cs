using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEditor;

namespace UnityAppFlavor.Editor
{
    public partial class UAFEditorSetting
    {
        public void ResetProvision()
        {
            Undo.RecordObject(this, "UAF/Config/ResetProvision");

            provisions = new List<UAFiOSProvision> {new() {channel = "oversea"}, new() {channel = "inland"}};
        }

        public void ResetPod()
        {
            Undo.RecordObject(this, "UAF/Config/ResetPod");

            pod_ios_version = "12.0";
            pod_source      = "https://mirrors.tuna.tsinghua.edu.cn/git/CocoaPods/Specs.git";

            ios_pods = new List<UAFiOSPodChannel>
            {
                new()
                {
                    channel = "oversea",
                    pods =
                        new List<UAFiOSPod>
                        {
                            // 填入默认的 pod
                        }
                },
                new()
                {
                    channel = "inland",
                    pods = new List<UAFiOSPod>
                    {
                        // 填入默认的 pod
                    }
                }
            };
        }

        public void ResetiOSCapability()
        {
            Undo.RecordObject(this, "UAF/Config/ResetiOSCapability");

            ios_capabilities = new List<UAFiOSCapability> {new("oversea"), new("inland")};
        }

        private static string _copy_target_path => Path.Combine(_GetRunningPath(), "iOS/Res/CopyTarget.rb.txt");

        private static string _info_plist_path => Path.Combine(_GetRunningPath(), "iOS/Res/Info.plist.txt");

        private static string _GetRunningPath([CallerFilePath] string path = null) => Path.GetDirectoryName(path);

#if UNITY_IOS

        public static void iOSTransmitAll(string                             path_to_built_project,
                                          string                             channel_name,
                                          Action<List<AXcodeRebuildTask>>    rebuilder_inject  = null,
                                          Action<List<AXCodePlistTask>>      plist_inject      = null,
                                          Action<List<AXcodeCapabilityTask>> capability_inject = null)
        {
            // _Prepare(path_to_built_project);
            _RebuildTasks(path_to_built_project, channel_name, rebuilder_inject);
            _PlistTasks(path_to_built_project, channel_name, plist_inject);
            _CapabilityTasks(path_to_built_project, channel_name, capability_inject);
        }

        // private static void _Prepare(string path_to_built_project)
        // {
        //     RunCopyTarget(path_to_built_project);
        //     MakeChannelInfoPlistFile(path_to_built_project);
        // }

        // public static void MakeChannelInfoPlistFile(string path_to_built_project)
        // {
        //     var settings = GetOrCreateSettings();
        //
        //     foreach(var channel in settings.channels)
        //     {
        //         if(channel.IsUnityIPhoneTarget())
        //         {
        //             continue;
        //         }
        //
        //         var dest_path = Path.Combine(path_to_built_project, $"{channel.name}-Info.plist");
        //
        //         if(File.Exists(dest_path))
        //         {
        //             File.Delete(dest_path);
        //         }
        //
        //         File.Copy(
        //             string.IsNullOrEmpty(settings.info_plist_tpl_path)
        //                 ? _info_plist_path
        //                 : settings.info_plist_tpl_path,
        //             dest_path
        //         );
        //     }
        // }

        private static void _RebuildTasks(string                          path_to_built_project,
                                          string                          channel_name,
                                          Action<List<AXcodeRebuildTask>> rebuilder_inject = null)
        {
            var pbx_project_path = UnityEditor.iOS.Xcode.PBXProject.GetPBXProjectPath(path_to_built_project);

            var pbx_project = new UnityEditor.iOS.Xcode.PBXProject();

            pbx_project.ReadFromFile(pbx_project_path);


            var rebuild_tasks = new List<AXcodeRebuildTask>
            {
                // 设置描述文件 uuid
                new SetProvisions_XcodeRebuildTask(),
                // 生成 Pod File
                new GenPodFile_XcodeRebuildTask(),
                // 增加头文件搜索路径
                new AddHeaderPath_XcodeRebuildTask(),
                // 对 info.plist 所有渠道的引用位置进行重定向
                new RedirectInfoPath_XcodeRebuildTask(),
                // 追加 Link Flag -ObjC
                new AddLinkFlag_XcodeRebuildTask(),
                // 将 google 相关的 IL2Cpp 头文件拷贝到 XCode 工程中
                new CopyIL2CppGoogleHeader_XcodeRebuildTask(),
                // 关闭 BitCode
                new DisableBitCode_XcodeRebuildTask(),
                // 调整 Swift Lib 参数
                new ChangeSwiftLib_XcodeRebuildTask(),
                // 生成 Google Service Info 文件
                new GenGoogleService_XcodeRebuildTask(),
                // BUG 由于 Unity 自己的 AddInAppPurchase API 不会判断是否已经添加了 StoreKit.framework
                // BUG 如果没有添加, 则会导致 IAP capability 添加失败! 蛋疼
                // 保证 IAP 相关的 framework 优先添加
                new EnsureStoreKitFramework_AXcodeRebuildTask(),
                // 对每个渠道增加 GCC 的宏定义, 用于解决不同渠道 AppController 的冲突问题
                new AddGCCMacro_XcodeRebuildTask()
            };

            rebuilder_inject?.Invoke(rebuild_tasks);

            foreach(var task in rebuild_tasks)
            {
                task.Handle(pbx_project, path_to_built_project, channel_name);
            }

            pbx_project.WriteToFile(pbx_project_path);
        }

        private static void _PlistTasks(string                        path_to_built_project,
                                        string                        channel_name,
                                        Action<List<AXCodePlistTask>> inject = null)
        {
            var plist_tasks = new List<AXCodePlistTask>
            {
                // 填入自定义内容
            };

            inject?.Invoke(plist_tasks);

            var plist = new UnityEditor.iOS.Xcode.PlistDocument();

            string plist_path = Path.Combine(path_to_built_project, "info.plist");

            plist.ReadFromFile(plist_path);

            foreach(var task in plist_tasks)
            {
                task.Handle(plist, path_to_built_project, channel_name);
            }

            plist.WriteToFile(plist_path);
        }

        private static void _CapabilityTasks(string                             path_to_built_project,
                                             string                             channel_name,
                                             Action<List<AXcodeCapabilityTask>> inject = null)
        {
            var capability_tasks = new List<AXcodeCapabilityTask>
            {
                // 添加通用的能力
                new AddGeneral_XcodeCapabilityTask(),
            };

            inject?.Invoke(capability_tasks);

            foreach(var task in capability_tasks)
            {
                task.Handle(path_to_built_project, channel_name);
            }
        }

#endif
    }
}