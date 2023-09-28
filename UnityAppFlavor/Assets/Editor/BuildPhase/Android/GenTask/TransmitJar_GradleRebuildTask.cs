namespace UnityAppFlavor.Editor
{
    public class TransmitJar_GradleRebuildTask : AGradleRebuildTask
    {
        private readonly string _android_project_path;

        public TransmitJar_GradleRebuildTask(string android_project_path) =>
            _android_project_path = android_project_path;

        public override void Handle(ref string unity_lib_gradle, ref string launch_gradle, ref string properties_file)
        {
            if(_setting.lib_transfers is null || _setting.lib_transfers.Count <= 0)
            {
                return;
            }

            foreach(var transfer in _setting.lib_transfers)
            {
                transfer.Transmit(_android_project_path);
            }
        }
    }
}