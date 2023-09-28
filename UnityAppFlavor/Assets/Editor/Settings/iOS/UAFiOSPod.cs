using System;
using System.Collections.Generic;
using System.Text;
using Sirenix.OdinInspector;
using UnityEngine.Serialization;

namespace UnityAppFlavor.Editor
{
    [Serializable]
    public class UAFiOSPodChannel
    {
        [FormerlySerializedAs("name")]
        [VerticalGroup("基础配置")]
        [LabelText("渠道名")]
        [UAFChannel]
        [Required]
        public string channel;
        
        [VerticalGroup("Pod")]
        [HideLabel]
        [Required]
        [TableList(AlwaysExpanded = true)]
        public List<UAFiOSPod> pods;

        public string Pods2String()
        {
            var sb = new StringBuilder();

            foreach(var pod in pods)
            {
                sb.AppendLine(pod.ToString());
            }

            return sb.ToString();
        }
    }

    [Serializable]
    public class UAFiOSPod
    {
        [VerticalGroup("注释")]
        [HideLabel]
        public string comment;

        [VerticalGroup("包名")]
        [Required]
        [HideLabel]
        public string package_name;

        [VerticalGroup("包版本")]
        [HideLabel]
        public string package_version;

        public UAFiOSPod() { }

        public UAFiOSPod(string package_name, string comment = null, string package_version = null)
        {
            this.comment         = comment;
            this.package_name    = package_name;
            this.package_version = package_version;
        }

        public override string ToString()
        {
            string result = "";

            if(!string.IsNullOrEmpty(comment))
            {
                result = $"  #{comment}\n";
            }

            result += $"  pod '{package_name}'";

            if(!string.IsNullOrEmpty(package_version))
            {
                result += $",'{package_version}'";
            }

            return result;
        }
    }
}