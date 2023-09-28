#if UNITY_IOS

using UnityEditor.iOS.Xcode;

namespace UnityAppFlavor.Editor
{
    public abstract class AXCodePlistTask
    {
        protected enum UrlTypeRole
        {
            None,
            Editor,
            Viewer,
        }

        protected readonly UAFEditorSetting _setting = UAFEditorSetting.GetOrCreateSettings();

        public abstract void Handle(PlistDocument plist, string path_to_built_project, string channel_name);

        protected void _AddUrlTypes(PlistDocument plist,
                                    string        name,
                                    string        value,
                                    UrlTypeRole   role = UrlTypeRole.Editor)
        {
            const string url_types_key = "CFBundleURLTypes";

            if(!plist.root.values.TryGetValue(url_types_key, out var url_element))
            {
                url_element = new PlistElementArray();

                plist.root.values[url_types_key] = url_element;
            }

            var url_types = url_element.AsArray();

            for(int i = url_types.values.Count - 1; i >= 0; i--)
            {
                if(_IsValueInUrlTypes(url_types.values[i], value))
                {
                    url_types.values.RemoveAt(i);
                }
            }

            var url_type = new PlistElementDict
            {
                values =
                {
                    ["CFBundleURLName"]  = new PlistElementString(name),
                    ["CFBundleTypeRole"] = new PlistElementString(role.ToString())
                }
            };

            var url_schemes = new PlistElementArray();

            url_schemes.AddString(value);

            url_type.values["CFBundleURLSchemes"] = url_schemes;

            url_types.values.Add(url_type);
        }

        protected bool _IsValueInUrlTypes(PlistElement url_type, string value)
        {
            var url_type_dic = url_type.AsDict();

            if(url_type_dic.values.TryGetValue("CFBundleURLSchemes", out var url_schemes_element))
            {
                var url_schemes = url_schemes_element.AsArray();

                foreach(var url_scheme in url_schemes.values)
                {
                    if(url_scheme.AsString() == value)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
#endif