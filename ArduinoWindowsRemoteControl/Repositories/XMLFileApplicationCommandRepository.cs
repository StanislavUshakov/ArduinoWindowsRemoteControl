using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArduinoWindowsRemoteControl.Repositories
{
    /// <summary>
    /// Realization of IApplicationCommandRepository that stores commands in XML file in working directory
    /// </summary>
    public class XMLFileApplicationCommandRepository : IApplicationCommandRepository
    {
        #region Private Fields (for XML names and attributes)

        private string _filename = "settings.xml";
        private string _rootElement = "commands";
        private string _commandElement = "command";
        private string _appNameAttribute = "application";
        private string _remoteCommandAttribute = "remoteCommand";
        private string _commandAttribute = "command";

        #endregion

        public void Save(IEnumerable<IApplicationCommand> commands)
        {
            XElement root = new XElement(_rootElement);
            foreach (var command in commands)
            {
                var commandElement = new XElement(_commandElement);
                commandElement.SetAttributeValue(_appNameAttribute, command.ApplicationName);
                commandElement.SetAttributeValue(_remoteCommandAttribute, command.RemoteCommand);
                commandElement.SetAttributeValue(_commandAttribute, command.Command);

                root.Add(commandElement);
            }

            root.Save(_filename);
        }

        public List<ApplicationCommandDTO> Load()
        {
            var result = new List<ApplicationCommandDTO>();

            XElement root = XElement.Load(_filename);
            foreach (var node in root.Elements())
            {
                result.Add(new ApplicationCommandDTO 
                    {
                        ApplicationName = node.Attribute(_appNameAttribute).Value,
                        RemoteCommand = (RemoteCommand)Enum.Parse(typeof(RemoteCommand), node.Attribute(_remoteCommandAttribute).Value),
                        Command = node.Attribute(_commandAttribute).Value
                    });
            }

            return result;
        }
    }
}
