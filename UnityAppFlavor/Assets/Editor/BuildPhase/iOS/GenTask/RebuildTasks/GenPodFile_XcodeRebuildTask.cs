#if UNITY_IOS

using System.IO;
using System.Text;
using UnityEditor.iOS.Xcode;

namespace UnityAppFlavor.Editor
{
    public class GenPodFile_XcodeRebuildTask : AXcodeRebuildTask
    {
        private const string POD_HEADER = @"source '{0}'
platform :ios, '{1}'
";

        private const string POD_TARGET = @"

target '{0}' do
  use_frameworks!
  {1}
end

";

        private const string POD_TAIL = @"
post_install do |installer|
  installer.pods_project.targets.each do |target|
    target.build_configurations.each do |config|
      config.build_settings['IPHONEOS_DEPLOYMENT_TARGET'] = '{0}'
    end
  end
end";

        public override void Handle(PBXProject pbx_project, string path_to_built_project, string channel_name)
        {
            var podfile_path = $"{path_to_built_project}/Podfile";

            if(File.Exists(podfile_path))
            {
                File.Delete(podfile_path);
            }

            using var podfile = new StreamWriter(podfile_path);
            var       sb      = new StringBuilder();

            sb.AppendFormat(POD_HEADER, _setting.pod_source, _setting.pod_ios_version);

            foreach(var target in _setting.ios_pods)
            {
                if(!string.Equals(channel_name, target.channel))
                {
                    continue;
                }

                sb.AppendFormat(POD_TARGET, "Unity-iPhone",   "");
                sb.AppendFormat(POD_TARGET, "UnityFramework", target.Pods2String());
            }

            sb.AppendFormat(POD_TAIL, _setting.pod_ios_version);

            podfile.Write(sb);

            podfile.Close();
        }
    }
}
#endif