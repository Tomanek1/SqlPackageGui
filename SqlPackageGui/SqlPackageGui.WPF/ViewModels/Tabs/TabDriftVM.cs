﻿using SqlPackageGui.ApplicationLogic.Models;
using SqlPackageGui.WPF.ViewModels.Tabs.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SqlPackageGui.WPF.ViewModels.Tabs
{
    public class TabDriftVM : TabBaseVM
    {
        public string OutputPath { get; set; }

        //public ICommand Execute { get; set; }

        public TabDriftVM()
        {
            //Execute = new BasicCommand(this.Executee);
        }

        public TabDriftVM(Connection connection, VariableItem valuePairs)
        {
            this.Connection = connection;
            //Execute = new BasicCommand(this.Executee);
            this.Variables = valuePairs;
        }

        private void Executee()
        {
            throw new NotImplementedException();
        }
    }
}
