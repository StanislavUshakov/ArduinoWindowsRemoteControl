using ArduinoWindowsRemoteControl.Windows;
using Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class BaseCommandsUnitTest
    {
        #region Public Properties

        public CurrentActiveApplicationCommandDispatcher Dispatcher { get; set; }
        public List<IApplicationCommand> Commands { get; set; }

        #endregion

        #region Setup

        [TestInitialize]
        public virtual void Setup()
        {
            Dispatcher = new CurrentActiveApplicationCommandDispatcher();
            Commands = new List<IApplicationCommand>();
            Commands.Add(new WindowsKeyboardApplicationCommand("App1", RemoteCommand.Dig1, new WindowsKeyboardCommand("Command1")));
            Commands.Add(new WindowsKeyboardApplicationCommand("App1", RemoteCommand.Dig2, new WindowsKeyboardCommand("Command2")));
            Commands.Add(new WindowsKeyboardApplicationCommand("App2", RemoteCommand.Dig1, new WindowsKeyboardCommand("Command3")));
        }

        #endregion
    }
}
