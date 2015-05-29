using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ArduinoWindowsRemoteControl.Repositories;
using System.IO;
using Core.Interfaces;

namespace UnitTests
{
    [TestClass]
    public class DictionaryRepositoryUnitTest
    {
        [TestMethod]
        public void TestSaveAndLoadEmpty()
        {
            var dictionary = new Dictionary<int, string>();
            var repository = new DictionaryRepository();
            string filename = "test.txt";
            repository.Save(dictionary, filename);
            Assert.IsTrue(File.Exists(filename));

            var loadedDictionary = repository.Load<int, string>(filename);

            Assert.AreEqual(loadedDictionary.Count, 0);
        }

        [TestMethod]
        public void TestSaveAndLoadOneElement()
        {
            var dictionary = new Dictionary<int, string>() { {1, "test"} };
            var repository = new DictionaryRepository();
            string filename = "test.txt";
            repository.Save(dictionary, filename);
            Assert.IsTrue(File.Exists(filename));

            var loadedDictionary = repository.Load<int, string>(filename);

            Assert.AreEqual(loadedDictionary.Count, 1);
            Assert.AreEqual(loadedDictionary[1], "test");
        }

        [TestMethod]
        public void TestSaveAndLoadMany()
        {
            var dictionary = new Dictionary<int, string>() { { 1, "test" }, { 0, "a" }, { -1, "b" } };
            var repository = new DictionaryRepository();
            string filename = "test.txt";
            repository.Save(dictionary, filename);
            Assert.IsTrue(File.Exists(filename));

            var loadedDictionary = repository.Load<int, string>(filename);

            Assert.AreEqual(loadedDictionary.Count, 3);
            Assert.AreEqual(loadedDictionary[1], "test");
            Assert.AreEqual(loadedDictionary[0], "a");
            Assert.AreEqual(loadedDictionary[-1], "b");
        }

        [TestMethod]
        public void TestSaveAndLoadRemoteCommands()
        {
            var dictionary = new Dictionary<int, RemoteCommand>() { { 1, RemoteCommand.Dig1 }, { 0, RemoteCommand.Dig0 } };
            var repository = new DictionaryRepository();
            string filename = "test.txt";
            repository.Save(dictionary, filename);
            Assert.IsTrue(File.Exists(filename));

            var loadedDictionary = repository.Load<int, RemoteCommand>(filename);

            Assert.AreEqual(loadedDictionary.Count, 2);
            Assert.AreEqual(loadedDictionary[1], RemoteCommand.Dig1);
            Assert.AreEqual(loadedDictionary[0], RemoteCommand.Dig0);
        }
    }
}
