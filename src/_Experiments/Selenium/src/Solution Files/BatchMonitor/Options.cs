using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace BatchMonitor
{
    public class Options
    {
        [Option('d', "dirPath", DefaultValue = "", HelpText = "This is an option!", Required = true)]
        public string MonitorDirPath { get; set; }

        [Option('t', "triggerName", DefaultValue = "GenerateReport.bat", HelpText = "This is an option!")]
        public string TriggerName { get; set; }

        [Option('e', "ExecuteFileName", DefaultValue = "GenerateReport.bat", HelpText = "This is an option!")]
        public string ExecuteFileName { get; set; }

        [Option('p', "poolingInterval", DefaultValue = 5, HelpText = "This is an option!")]
        public int PoolingInterval { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
