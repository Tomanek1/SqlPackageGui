using SqlPackageGui.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
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

        Process proc;

        public void Execute(string action, string outputPath, string dacpacPath, Connection connection, DataReceivedEventHandler dataReceivedEventHandler)
        {
            Execute(action, outputPath, dacpacPath, connection, dataReceivedEventHandler, new MyVariableList());
        }

        public void Execute(string action, string outputPath, string dacpacPath, Connection connection, DataReceivedEventHandler dataReceivedEventHandler, MyVariableList custParams)
        {
            string arg = "/action:" + action + " "
                        + "/p:GenerateSmartDefaults=True "
                        + "/SourceFile:\"" + dacpacPath + "\" ";

            //foreach (var item in custParams)
            //{
            arg += "/v:" + custParams.Key + "=" + custParams.Value + " ";
            //}

            if (outputPath != null)
                arg += "/OutputPath:\"" + outputPath + "\" ";

            if (!string.IsNullOrEmpty(connection.ConnectionString))
                //if (CbConnectionString.IsChecked.HasValue && CbConnectionString.IsChecked.Value)
                arg += "/TargetConnectionString:" + connection.ConnectionString + " ";
            else
                arg += "/TargetDatabaseName:" + connection.TargetDatabaseName + " "
                        + "/TargetServerName:" + connection.TargetServerName;

            using (proc = new Process())
            {

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
}
