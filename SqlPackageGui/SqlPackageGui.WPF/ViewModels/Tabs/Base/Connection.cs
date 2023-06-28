namespace SqlPackageGui.WPF.ViewModels.Tabs.Base
{
    public class Connection
    {
        public string ConnectionString { get; set; }

        public string Console { get; set; }

        public string TargetDatabase { get; set; }

        public string TargetServer { get; set; }
        public string TargetDacpac { get; set; }

        public bool BlockOnPossibleDataLoss { get; set; }
    }
}
