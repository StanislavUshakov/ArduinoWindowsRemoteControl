using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ArduinoWindowsRemoteControl.Interfaces;
using ArduinoWindowsRemoteControl.Windows;
using ArduinoWindowsRemoteControl.Repositories;
using System.IO;
using System.Xml.Linq;

namespace UnitTests
{
    [TestClass]
    public class XMLCommandRepositoryUnitTest
    {
        public const string filename = "settings.xml";
        public const string appName = "applicationTest";
        public const RemoteCommand remoteCommand = RemoteCommand.Dig0;
        public const string command = "A,A,A";

        public XMLFileApplicationCommandRepository Repository { get; set; }

        [TestInitialize]
        public void Setup()
        {
            Repository = new XMLFileApplicationCommandRepository();
        }

        [TestMethod]
        public void TestSavingToXML()
        {
            SaveCommands(GetCommands());

            Assert.IsTrue(File.Exists(filename));

            var root = XElement.Load(filename);

            Assert.IsNotNull(root);
            Assert.IsTrue(root.HasElements);
        }

        [TestMethod]
        public void TestLoadingFromXML()
        {
            var commands = GetCommands();

            SaveCommands(commands);

            var loadedCommands = Repository.Load();

            Assert.IsNotNull(loadedCommands);
            Assert.AreEqual(loadedCommands.Count, 1);
            Assert.AreEqual(loadedCommands[0].ApplicationName, commands[0].ApplicationName);
            Assert.AreEqual(loadedCommands[0].RemoteCommand, commands[0].RemoteCommand);
            Assert.AreEqual(loadedCommands[0].Command, commands[0].Command.ToString());
        }

        private void SaveCommands(IEnumerable<IApplicationCommand> commands)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            Repository.Save(commands);
        }

        private List<IApplicationCommand> GetCommands()
        {
            var commands = new List<IApplicationCommand>();
            commands.Add(new WindowsKeyboardApplicationCommand(appName, remoteCommand, new WindowsKeyboardCommand(command)));
            return commands;
        }
    }
}
