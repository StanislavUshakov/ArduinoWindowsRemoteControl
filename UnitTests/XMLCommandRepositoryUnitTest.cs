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
        [TestMethod]
        public void TestSavingToXML()
        {
            const string filename = "settings.xml";
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            
            var applications = new List<IApplicationCommand>();
            applications.Add(new WindowsKeyboardApplicationCommand("applicationTest", RemoteCommand.Dig0, new WindowsKeyboardCommand("A,A,A")));
            var repository = new XMLFileApplicationCommandRepository();
            repository.Save(applications);
            Assert.IsTrue(File.Exists(filename));

            var root = XElement.Load(filename);
            Assert.IsNotNull(root);
            Assert.IsTrue(root.HasElements);
        }
    }
}
