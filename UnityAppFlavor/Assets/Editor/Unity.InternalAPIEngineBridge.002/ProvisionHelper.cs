using UnityEditor.PlatformSupport;

namespace UnityAppFlavor.Editor
{
    public static class ProvisionHelper
    {
        public static string GetUUID()
        {
            var profile = ProvisioningProfileGUI.Browse("");

            return profile?.UUID;
        }
    }
}