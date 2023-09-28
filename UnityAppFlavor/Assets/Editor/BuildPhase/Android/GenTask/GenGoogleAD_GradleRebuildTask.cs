namespace UnityAppFlavor.Editor
{
    public class GenGoogleAD_GradleRebuildTask : AGradleRebuildTask
    {
        private const string USE_AD = "manifestPlaceholders.put(\"GOOGLE_AD\", \"{0}\")";

        private const string NO_USE_AD = "manifestPlaceholders.put(\"GOOGLE_AD\", \"\")";

        public override void Handle(ref string unity_lib_gradle, ref string launch_gradle, ref string properties_file)
        {
            // TODO
            // if(_setting.android_build_params is null || _setting.android_build_params.Count <= 0)
            // {
            //     return;
            // }
            //
            // foreach(var param in _setting.android_build_params)
            // {
            //     var id = param.google_id;
            //
            //     unity_lib_gradle = _GradleReplace(
            //         unity_lib_gradle,
            //         $"{param.dir_name.ToUpper()}_GOOGLE_AD",
            //         id is null ? NO_USE_AD : string.Format(USE_AD, id)
            //     );
            // }
        }
    }
}