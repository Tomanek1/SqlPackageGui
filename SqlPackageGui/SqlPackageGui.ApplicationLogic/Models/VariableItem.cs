using System;

namespace SqlPackageGui.ApplicationLogic.Models
{
    [Serializable]
    public class VariableItem
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public VariableItem()
        {

        }

        public VariableItem(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
