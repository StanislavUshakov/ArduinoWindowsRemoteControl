using ArduinoWindowsRemoteControl.Interfaces;
using ArduinoWindowsRemoteControl.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class FactoriesUnitTest
    {
        #region Tests

        [TestMethod]
        public void TestWindowsKeyboardCommandFactory()
        {
            var factory = new WindowsKeyboardCommandFactory();
            string commandString = "CommandTest";
            
            var command = factory.Create(commandString);

            Assert.IsInstanceOfType(command, typeof(WindowsKeyboardCommand));
            Assert.AreEqual(command.ToString(), commandString);
        }

        [TestMethod]
        public void TestWindowsKeyboardApplicationCommandFactory()
        {
            var commandFactory = new WindowsKeyboardCommandFactory();
            var factory = new WindowsKeyboardApplicationCommandFactory(commandFactory);
            RemoteCommand remoteCommand = RemoteCommand.Dig0;
            string appName = "AppTest";
            string commandString = "CommandTest";

            var command = factory.Create(appName, remoteCommand, commandString);

            Assert.IsInstanceOfType(command, typeof(WindowsKeyboardApplicationCommand));
            Assert.AreEqual(command.ApplicationName, appName);
            Assert.AreEqual(command.RemoteCommand, remoteCommand);
            Assert.IsInstanceOfType(command.Command, typeof(WindowsKeyboardCommand));
            Assert.AreEqual(command.Command.ToString(), commandString);
        }

        #endregion
    }
}
