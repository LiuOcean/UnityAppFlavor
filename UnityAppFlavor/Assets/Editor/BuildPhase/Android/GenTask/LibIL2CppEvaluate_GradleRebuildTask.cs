namespace UnityAppFlavor.Editor
{
    public class LibIL2CppEvaluate_GradleRebuildTask : AGradleRebuildTask
    {
        public override void Handle(ref string unity_lib_gradle, ref string launch_gradle, ref string properties_file)
        {
            if(_setting.lib_transfers is null || _setting.lib_transfers.Count <= 0)
            {
                return;
            }

            string il2cpp_evaluate = string.Empty;
            string il2cpp_start = @"
android {
    afterEvaluate {
        ";
            string il2cpp_end = @"
    }
}";
            foreach(var transfer in _setting.lib_transfers)
            {
                il2cpp_evaluate += transfer.GenIL2CppEvaluate();
            }

            unity_lib_gradle = _GradleReplace(unity_lib_gradle, "IL2CPP", il2cpp_start + il2cpp_evaluate + il2cpp_end);
        }
    }
}