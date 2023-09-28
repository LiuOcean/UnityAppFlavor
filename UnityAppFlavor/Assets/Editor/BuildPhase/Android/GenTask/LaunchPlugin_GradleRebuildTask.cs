namespace UnityAppFlavor.Editor
{
    public class LaunchPlugin_GradleRebuildTask : AGradleRebuildTask
    {
        public override void Handle(ref string unity_lib_gradle, ref string launch_gradle, ref string properties_file)
        {
            if(_setting.lib_transfers is null || _setting.lib_transfers.Count <= 0)
            {
                return;
            }

            string plugin = string.Empty;

            foreach(var transfer in _setting.apply_plugins)
            {
                plugin += transfer.GenLaunchPlugin();
            }

            launch_gradle = _GradleReplace(launch_gradle, "PLUGIN", plugin);
        }
    }
}