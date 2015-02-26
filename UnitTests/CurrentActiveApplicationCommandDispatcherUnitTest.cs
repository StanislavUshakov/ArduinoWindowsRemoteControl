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
    public class CurrentActiveApplicationCommandDispatcherUnitTest : BaseCommandsUnitTest
    {
        #region Setup

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();
        }

        #endregion

        #region Tests

        [TestMethod]
        public void TestDeleteAll()
        {
            foreach (var command in Commands)
            {
                Dispatcher.AddApplicationCommand(command);
            }

            Dispatcher.DeleteAllCommands();

            Assert.AreEqual(Dispatcher.GetApplicationNames().Count, 0);
            Assert.AreEqual(Dispatcher.GetCommandsForApplication("App1").Count, 0);
        }

        [TestMethod]
        public void TestSimpleAdd()
        {
            Dispatcher.AddApplicationCommand(Commands[0]);

            Assert.AreEqual(Dispatcher.GetApplicationNames().Count, 1);
            Assert.AreEqual(Dispatcher.GetApplicationNames()[0], "App1");
            Assert.AreEqual(Dispatcher.GetCommandsForApplication("App1").Count, 1);
            Assert.AreEqual(Dispatcher.GetCommandsForApplication("App1")[RemoteCommand.Dig1].RemoteCommand, RemoteCommand.Dig1);
            Assert.AreEqual(Dispatcher.GetCommandsForApplication("App1")[RemoteCommand.Dig1].Command.ToString(), "Command1");
            Assert.AreEqual(Dispatcher.GetCommandsForApplication("App1")[RemoteCommand.Dig1].ApplicationName, "App1");
        }

        [TestMethod]
        public void TestComplexAdd()
        {
            foreach (var command in Commands)
            {
                Dispatcher.AddApplicationCommand(command);
            }

            Assert.AreEqual(Dispatcher.GetApplicationNames().Count, 2);
            Assert.AreEqual(Dispatcher.GetApplicationNames()[0], "App1");
            Assert.AreEqual(Dispatcher.GetApplicationNames()[1], "App2");
            Assert.AreEqual(Dispatcher.GetCommandsForApplication("App1").Count, 2);
            Assert.AreEqual(Dispatcher.GetCommandsForApplication("App1")[RemoteCommand.Dig2].Command.ToString(), "Command2");
            Assert.AreEqual(Dispatcher.GetCommandsForApplication("App1")[RemoteCommand.Dig1].Command.ToString(), "Command1");
            Assert.AreEqual(Dispatcher.GetCommandsForApplication("App2")[RemoteCommand.Dig1].Command.ToString(), "Command3");
            Assert.AreEqual(Dispatcher.GetCommandsForApplication("App2")[RemoteCommand.Dig1].ApplicationName, "App2");
        }

        [TestMethod]
        public void TestAddSame()
        {
            Assert.IsFalse(Dispatcher.AddApplicationCommand(Commands[0]));
            Assert.IsTrue(Dispatcher.AddApplicationCommand(Commands[0]));
        }

        [TestMethod]
        public void TestDelete()
        {
            foreach (var command in Commands)
            {
                Dispatcher.AddApplicationCommand(command);
            }

            Assert.AreEqual(Dispatcher.GetApplicationNames().Count, 2);

            Dispatcher.DeleteApplicationCommand(Commands[2]);

            Assert.AreEqual(Dispatcher.GetApplicationNames().Count, 1);

            Dispatcher.DeleteApplicationCommand(Commands[1]);

            Assert.AreEqual(Dispatcher.GetApplicationNames().Count, 1);
            Assert.AreEqual(Dispatcher.GetCommandsForApplication("App1").Count, 1);
            Assert.AreEqual(Dispatcher.GetCommandsForApplication("App1")[RemoteCommand.Dig1].RemoteCommand, RemoteCommand.Dig1);
            Assert.AreEqual(Dispatcher.GetCommandsForApplication("App1")[RemoteCommand.Dig1].Command.ToString(), "Command1");
            Assert.AreEqual(Dispatcher.GetCommandsForApplication("App1")[RemoteCommand.Dig1].ApplicationName, "App1");
            
            Dispatcher.DeleteApplicationCommand(Commands[0]);

            Assert.AreEqual(Dispatcher.GetApplicationNames().Count, 0);
            Assert.AreEqual(Dispatcher.GetCommandsForApplication("App1").Count, 0);
        }

        #endregion
    }
}
