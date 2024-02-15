using Microsoft.Extensions.Logging;
using SqlPackageGui.ApplicationLogic.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace SqlPackageGui.ApplicationLogic
{
    ///https://docs.microsoft.com/en-us/sql/tools/sqlpackage?view=sql-server-ver15
    public class SqlPackage
    {
        public string ConsoleLocation { get; set; }

        public SqlPackage(ILogger logger)
        {
            this.logger = logger;
        }

        private Process proc;
        private readonly ILogger logger;

        public void Execute(CommonParameters parameters, string outputPath, Connection connection, DataReceivedEventHandler dataReceivedEventHandler)
        {
            Execute(parameters, outputPath, connection, dataReceivedEventHandler, new Dictionary<string, VariableItem>());
        }

        public void Execute(CommonParameters parameters, string outputPath, Connection connection, DataReceivedEventHandler dataReceivedEventHandler, IDictionary<string, VariableItem> custParams)
        {
            string args = "/action:" + parameters.Action + " "
                        + "/p:GenerateSmartDefaults=True "
                        + "/p:IgnoreColumnOrder=" + parameters.IgnoreColumnOrder + " "
                        + "/p:BlockOnPossibleDataLoss=" + parameters.BlockOnPossibleDataLoss + " "
                        + "/SourceFile:\"" + parameters.DacpacPath + "\" ";

            if (custParams.TryGetValue("V", out var variable) && !string.IsNullOrEmpty(variable.Key) && !string.IsNullOrEmpty(variable.Value))
                args += "/v:" + variable.Key + "=" + variable.Value + " ";

            if (custParams.TryGetValue("P", out var parameter) && !string.IsNullOrEmpty(parameter.Key) && !string.IsNullOrEmpty(parameter.Value))
                args += "/p:" + parameter.Key + "=" + parameter.Value + " ";

            if (outputPath != null)
                args += "/OutputPath:\"" + outputPath + "\" ";

            if (!string.IsNullOrEmpty(connection.ConnectionString))
                //if (CbConnectionString.IsChecked.HasValue && CbConnectionString.IsChecked.Value)
                args += "/TargetConnectionString:" + connection.ConnectionString + " ";
            else
                args += "/TargetDatabaseName:" + connection.TargetDatabaseName + " "
                        + "/TargetServerName:" + connection.TargetServerName + " "
                        + "/stsc:True "
                        + "/ttsc:True";

            using (proc = new Process())
            {

                this.proc.StartInfo = new ProcessStartInfo
                {
                    FileName = ConsoleLocation,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                };


                proc.OutputDataReceived += new DataReceivedEventHandler(dataReceivedEventHandler);
                proc.ErrorDataReceived += new DataReceivedEventHandler(dataReceivedEventHandler);

                logger.LogInformation("Starting process with args: {args}", args);
                proc.Start();

                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();

                proc.WaitForExit();
            }
        }
    }
}
