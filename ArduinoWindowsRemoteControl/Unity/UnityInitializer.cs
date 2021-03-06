﻿using Arduino.Devices;
using Arduino.Parsers;
using Services;
using ArduinoWindowsRemoteControl.UI;
using ArduinoWindowsRemoteControl.Windows;
using Core.Interfaces;
using DAL.Repositories;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoWindowsRemoteControl.Unity
{
    public static class UnityInitializer
    {
        public static IUnityContainer ConfigureUnity()
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType<ICommand, WindowsKeyboardCommand>();
            container.RegisterType<ICommandFactory, WindowsKeyboardCommandFactory>();
            container.RegisterType<IApplicationCommandFactory, WindowsKeyboardApplicationCommandFactory>();
            container.RegisterType<IRemoteCommandParser<RemoteCommand>, ArduinoRemoteCommandParser>();
            container.RegisterType<ICommandDispatcher, CurrentActiveApplicationCommandDispatcher>();
            container.RegisterType<ICommandManager, WindowsActiveApplicationManager>(new ContainerControlledLifetimeManager());
            container.RegisterType<IRemoteInputDevice<RemoteCommand>, ArduinoInputDevice<RemoteCommand>>(new InjectionConstructor(Program.PortName));
            container.RegisterType<IApplicationCommandRepository, XMLFileApplicationCommandRepository>();
            container.RegisterType<ApplicationCommandPersistentService>();
            container.RegisterType<MainForm>();
            container.RegisterType<EditCommandForm>();

            return container;
        }
    }
}
