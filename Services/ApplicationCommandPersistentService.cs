using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /// <summary>
    /// Represents service that is responsible for saving/loading application commands
    /// </summary>
    public class ApplicationCommandPersistentService
    {
        #region Private Fields

        private IApplicationCommandRepository _repository;

        #endregion

        #region Constructor

        public ApplicationCommandPersistentService(IApplicationCommandRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Loads all commands from current repository to ICommandManager
        /// </summary>
        /// <param name="commandManager">ICommandManager object for storing commands</param>
        public void Load(ICommandManager commandManager)
        {
            commandManager.DeleteAllCommands();

            var commands = _repository.Load();
            foreach (var command in commands)
            {
                commandManager.AddNewCommandForApplication(command.ApplicationName, command.RemoteCommand, command.Command);
            }
        }

        /// <summary>
        /// Saves all commands contained in ICommandManager
        /// </summary>
        /// <param name="commandManager">ICommandManager objects storing commands</param>
        public void Save(ICommandManager commandManager)
        {
            var commands = new List<IApplicationCommand>();

            foreach (var applicationName in commandManager.GetApplicationNames())
            {
                foreach (var command in commandManager.GetCommandsForApplication(applicationName))
                {
                    commands.Add(command);
                }
            }

            _repository.Save(commands);
        }

        #endregion
    }
}