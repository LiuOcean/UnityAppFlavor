namespace UnityAppFlavor.Editor
{
    public class LibSourceSet_GradleRebuildTask : AGradleRebuildTask
    {
        public override void Handle(ref string unity_lib_gradle, ref string launch_gradle, ref string properties_file)
        {
            if(_setting.lib_transfers is null || _setting.lib_transfers.Count <= 0)
            {
                return;
            }
            
            string source_set = string.Empty;

            foreach(var transfer in _setting.lib_transfers)
            {
                source_set += transfer.GenSourceSet();
            }
            
            unity_lib_gradle = _GradleReplace(unity_lib_gradle, "SOURCE", source_set);
        }
    }
}