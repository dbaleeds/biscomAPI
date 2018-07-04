using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestClient1
{
    class GetWorkspaceUserSettingsOutputWS1
    {
        public int returnCode { get; set; }
        public SettingMap settingMap { get; set; }

        public string toString()
        {
            string NEW_LINE = "\n";
            StringBuilder thisString = new StringBuilder();
            thisString.Append("returnCode: ");
            thisString.Append(this.returnCode);
            thisString.Append(NEW_LINE);
            thisString.Append("settingMap: ");

            int length = this.settingMap.entry.Count;
            for (int i = 0; i < length; i++)
            {
                thisString.Append((settingMap.entry != null) ? this.settingMap.entry[i].key.ToString() + " = " + this.settingMap.entry[i].value.ToString() : "<null>");
                thisString.Append(NEW_LINE);
            }
            return thisString.ToString();
        }
    }

    public class Entry
    {
        public string key { get; set; }
        public string value { get; set; }
    }


    public class SettingMap
    {
        public List<Entry> entry { get; set; }
    }

}
