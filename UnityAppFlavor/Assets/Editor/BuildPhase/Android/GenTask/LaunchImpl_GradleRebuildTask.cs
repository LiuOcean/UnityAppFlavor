namespace UnityAppFlavor.Editor
{
    public class LaunchImpl_GradleRebuildTask : AGradleRebuildTask
    {
        public override void Handle(ref string unity_lib_gradle, ref string launch_gradle, ref string properties_file)
        {
            if(_setting.lib_transfers is null || _setting.lib_transfers.Count <= 0)
            {
                return;
            }

            string replace = string.Empty;

            foreach(var transfer in _setting.lib_transfers)
            {
                replace += transfer.GenLaunchImpl();
            }

            launch_gradle = _GradleReplace(launch_gradle, "IMPL", replace);
        }
    }
}