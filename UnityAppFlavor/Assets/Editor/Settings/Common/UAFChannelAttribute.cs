using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace UnityAppFlavor.Editor
{
    [AttributeUsage(AttributeTargets.Field)]
    [IncludeMyAttributes]
    [ValueDropdown("@UAFChannelAttribute.Get()")]
    internal class UAFChannelAttribute : Attribute
    {
        private static IEnumerable<ValueDropdownItem> Get()
        {
            var setting = UAFEditorSetting.GetOrCreateSettings();

            foreach(var channel in setting.channels)
            {
                yield return new ValueDropdownItem(channel.alias, channel.name);
            }
        }
    }
}