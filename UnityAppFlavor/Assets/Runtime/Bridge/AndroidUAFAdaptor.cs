#if UNITY_ANDROID

using JetBrains.Annotations;
using UnityEngine;

namespace UnityAppFlavor.Bridge
{
    [UsedImplicitly]
    public class AndroidUAFAdaptor : AndroidJavaProxy, IUAFAdaptor
    {
        protected readonly AndroidJavaObject _j_obj;

        public AndroidUAFAdaptor() : base("com.company.dome.UAFProxy") // 请修改为自己的包名
        {
            using var jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

            _j_obj = jc.GetStatic<AndroidJavaObject>("currentActivity");
            _j_obj.Call("setProxy", this);
        }
    }
}
#endif