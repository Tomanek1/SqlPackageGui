using System;
using System.Collections.Generic;
using System.Text;

namespace SqlPackageGui.ApplicationLogic.Models
{
    [Serializable]
    public class MyVariableList
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public MyVariableList()
        {

        }

        public MyVariableList(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
