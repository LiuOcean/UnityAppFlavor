namespace UnityAppFlavor.Editor
{
    public class LibShareAarImpl_GradleRebuildTask : AGradleRebuildTask
    {
        public override void Handle(ref string unity_lib_gradle, ref string launch_gradle, ref string properties_file)
        {
            if(_setting.share_lib_transfers is null || _setting.share_lib_transfers.Count <= 0)
            {
                return;
            }

            foreach(var transfer in _setting.share_lib_transfers)
            {
                unity_lib_gradle = _GradleReplace(
                    unity_lib_gradle,
                    transfer.dir_name.ToUpper(),
                    transfer.GenAarImpl(false, "\t")
                );
            }
        }
    }
}