using ArduinoWindowsRemoteControl.Repositories;
using ArduinoWindowsRemoteControl.Windows;
using Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace UnitTests
{
    [TestClass]
    public class XMLCommandRepositoryUnitTest
    {
        #region Public Properties

        public XMLFileApplicationCommandRepository Repository { get; set; }

        public List<IApplicationCommand> Commands { get; set; }

        public string Filename { get; set; }

        #endregion

        #region SetUp

        [TestInitialize]
        public void Setup()
        {
            Repository = new XMLFileApplicationCommandRepository();
            Commands = new List<IApplicationCommand>();
            Commands.Add(new WindowsKeyboardApplicationCommand("applicationTest", RemoteCommand.Dig0, new WindowsKeyboardCommand("A,A,A")));
            Filename = "settings.xml";
        }

        #endregion

        #region Tests

        [TestMethod]
        public void TestSavingToXML()
        {
            SaveCommands(Commands);

            Assert.IsTrue(File.Exists(Filename));

            var root = XElement.Load(Filename);

            Assert.IsNotNull(root);
            Assert.IsTrue(root.HasElements);
        }

        [TestMethod]
        public void TestLoadingFromXML()
        {
            SaveCommands(Commands);

            var loadedCommands = Repository.Load();

            Assert.IsNotNull(loadedCommands);
            Assert.AreEqual(loadedCommands.Count, 1);
            Assert.AreEqual(loadedCommands[0].ApplicationName, Commands[0].ApplicationName);
            Assert.AreEqual(loadedCommands[0].RemoteCommand, Commands[0].RemoteCommand);
            Assert.AreEqual(loadedCommands[0].Command, Commands[0].Command.ToString());
        }

        #endregion

        #region Private Methods
        private void SaveCommands(IEnumerable<IApplicationCommand> commands)
        {
            if (File.Exists(Filename))
            {
                File.Delete(Filename);
            }

            Repository.Save(commands);
        }

        #endregion
    }
}
