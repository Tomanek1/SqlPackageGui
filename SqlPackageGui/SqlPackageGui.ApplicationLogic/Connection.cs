﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SqlPackageGui.ApplicationLogic
{
    public class Connection
    {
        public string ConnectionString { get; set; }
        public string TargetDatabaseName { get; set; }
        public string TargetServerName { get; set; }
    }
}
