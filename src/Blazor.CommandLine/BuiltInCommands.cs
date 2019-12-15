namespace Blazor.Components.CommandLine
{
    using Blazor.Components.CommandLine.Command;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    internal class HelpCommand : IHelpCommand
    {
        public string Output { get; set; }
        public string Help { get; }
        public Dictionary<string, ICommand> Commands { get; set; }

        public async Task<string> Run(params string[] arguments)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<p>");
            sb.Append($"<span style='color:white;display:block'>{string.Format("help\t\tShow command line help with available commands.")}</span>");
            sb.Append($"<span style='color:white;display:block'>{string.Format("version\t\tDisplays Blazor.Console version.")}</span>");
            sb.Append($"<span style='color:white;display:block'>{string.Format("os\t\tDisplays the current opearting system.")}</span>");
            sb.Append($"<span style='color:white;display:block'>{string.Format("clear\t\tClears the console.")}</span>");
            sb.Append($"</p>");

            foreach (var item in Commands)
            {
                sb.Append($"<span style='color:white;display:block'>{item.Key}\t\t{item.Value.Help}</span>");
            }

            Output = sb.ToString();

            return Output;
        }
    }

    internal class InvalidCommand : IInvalidCommand
    {
        public string Output { get; set; }
        public string Help { get; }

        private string _commandText = string.Empty;
        public InvalidCommand(string commandText)
        {
            _commandText = commandText;
        }

        public async Task<string> Run(params string[] arguments)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"<span style='color:red'>{_commandText}: command not found.</span>");

            Output = sb.ToString();

            return Output;
        }
    }

    internal class OSCommand : IOSCommand
    {
        public string Output { get; set; }
        public string Help { get; } = "Displays the current opearting system.";
        public async Task<string> Run(params string[] arguments)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<p>");
            sb.Append($"<span style='color:white'>{System.Runtime.InteropServices.RuntimeInformation.OSDescription}</span>");
            sb.Append($"</p>");

            Output = sb.ToString();

            return Output;
        }
    }

    internal class VersionCommand : IVersionCommand
    {
        public string Output { get; set; }
        public string Help { get; } = "Displays Blazor.Console version.";
        public async Task<string> Run(params string[] arguments)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"<p>");
            sb.Append($"<span style='color:white'>Blazor.Console {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()}</span>");
            sb.Append($"</p>");

            Output = sb.ToString();

            return Output;
        }
    }

}
