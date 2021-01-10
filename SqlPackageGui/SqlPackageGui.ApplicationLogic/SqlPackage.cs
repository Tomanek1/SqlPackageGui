using System;
using System.Diagnostics;

namespace SqlPackageGui.ApplicationLogic
{
    ///https://docs.microsoft.com/en-us/sql/tools/sqlpackage?view=sql-server-ver15
    public class SqlPackage
    {
        public string ConsoleLocation { get; set; }
        public SqlPackage(/*string location*/)
        {
            //ConsoleLocation = location;
        }

        Process proc = new Process();

        public void Execute(string action, string outputPath, string dacpacPath, Connection connection, DataReceivedEventHandler dataReceivedEventHandler)
        {
            string arg = "/action:" + action + " "
                        + "/p:GenerateSmartDefaults=True "
                        + "/v:DropCategoryAttributeTable=0 "
                        + "/SourceFile:\"" + dacpacPath + "\" ";
            if (outputPath != null)
                arg += "/OutputPath:\"" + outputPath + "\" ";

            if (!string.IsNullOrEmpty(connection.ConnectionString))
                //if (CbConnectionString.IsChecked.HasValue && CbConnectionString.IsChecked.Value)
                arg += "/TargetConnectionString:" + connection.ConnectionString + " ";
            else
                arg += "/TargetDatabaseName:" + connection.TargetDatabaseName + " "
                        + "/TargetServerName:" + connection.TargetServerName;

            this.proc.StartInfo = new ProcessStartInfo
            {
                FileName = ConsoleLocation,
                Arguments = arg,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            proc.OutputDataReceived += new DataReceivedEventHandler(dataReceivedEventHandler);
            proc.ErrorDataReceived += new DataReceivedEventHandler(dataReceivedEventHandler);

            proc.Start();
            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();
            proc.WaitForExit();

        }
    }
}
