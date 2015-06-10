using ArduinoWindowsRemoteControl.Windows;
using Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class WindowsActiveApplicationManagerUnitTest : BaseCommandsUnitTest
    {
        #region Public Properties

        public Mock<IRemoteInputDevice<RemoteCommand>> RemoteInputMock { get; set; }

        public Mock<ICommandDispatcher> CommandDispatcherMock { get; set; }

        public IApplicationCommandFactory Factory { get; set; }

        public WindowsActiveApplicationManager ManagerWithMocks { get; set; }

        public WindowsActiveApplicationManager Manager { get; set; }

        #endregion

        #region Setup

        [TestInitialize]
        public override void Setup()
        {
            base.Setup();

            RemoteInputMock = new Mock<IRemoteInputDevice<RemoteCommand>>();
            CommandDispatcherMock = new Mock<ICommandDispatcher>();
            CommandDispatcherMock.Setup(d => d.DispatchCommand(RemoteCommand.Dig0));
            Factory = new WindowsKeyboardApplicationCommandFactory(new WindowsKeyboardCommandFactory());

            ManagerWithMocks = new WindowsActiveApplicationManager(Factory, CommandDispatcherMock.Object, RemoteInputMock.Object);

            Manager = new WindowsActiveApplicationManager(Factory, new CurrentActiveApplicationCommandDispatcher(), RemoteInputMock.Object);
        }

        #endregion

        #region Tests

        [TestMethod]
        public void TestDispacthIsCalled()
        {
            RemoteInputMock.Raise(input => input.CommandReceived += null, RemoteCommand.Dig0);
            CommandDispatcherMock.Verify(dispatcher => dispatcher.DispatchCommand(RemoteCommand.Dig0), Times.Exactly(1));
        }

        [TestMethod]
        public void TestSimpleAdd()
        {
            Assert.IsFalse(Manager.AddNewCommandForApplication(Commands[0].ApplicationName, Commands[0].RemoteCommand, Commands[0].Command.ToString()));
            Assert.AreEqual(Manager.GetApplicationNames().Count, 1);
            Assert.AreEqual(Manager.GetApplicationNames()[0], Commands[0].ApplicationName);
            Assert.AreEqual(Manager.GetCommandsForApplication(Commands[0].ApplicationName).Count, 1);
            Assert.AreEqual(Manager.GetCommandsForApplication(Commands[0].ApplicationName)[0].Command.ToString(), Commands[0].Command.ToString());
        }

        [TestMethod]
        public void TestSameAdd()
        {
            Assert.IsFalse(Manager.AddNewCommandForApplication(Commands[0].ApplicationName, Commands[0].RemoteCommand, Commands[0].Command.ToString()));
            Assert.IsTrue(Manager.AddNewCommandForApplication(Commands[0].ApplicationName, Commands[0].RemoteCommand, Commands[0].Command.ToString()));
            Assert.AreEqual(Manager.GetApplicationNames().Count, 1);
            Assert.AreEqual(Manager.GetApplicationNames()[0], Commands[0].ApplicationName);
            Assert.AreEqual(Manager.GetCommandsForApplication(Commands[0].ApplicationName).Count, 1);
            Assert.AreEqual(Manager.GetCommandsForApplication(Commands[0].ApplicationName)[0].Command.ToString(), Commands[0].Command.ToString());
        }

        [TestMethod]
        public void TestDelete()
        {
            Manager.AddNewCommandForApplication(Commands[0].ApplicationName, Commands[0].RemoteCommand, Commands[0].Command.ToString());
            Manager.DeleteApplicationCommand(Commands[0]);

            Assert.AreEqual(Manager.GetApplicationNames().Count, 0);
        }

        [TestMethod]
        public void TestDeleteAll()
        {
            Manager.AddNewCommandForApplication(Commands[0].ApplicationName, Commands[0].RemoteCommand, Commands[0].Command.ToString());
            Manager.DeleteAllCommands();

            Assert.AreEqual(Manager.GetApplicationNames().Count, 0);
            Assert.AreEqual(Manager.GetCommandsForApplication(Commands[0].ApplicationName).Count, 0);
        }

        #endregion
    }
}
