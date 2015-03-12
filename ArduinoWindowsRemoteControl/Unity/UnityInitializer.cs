using ArduinoWindowsRemoteControl.Arduino;
using ArduinoWindowsRemoteControl.Interfaces;
using ArduinoWindowsRemoteControl.Repositories;
using ArduinoWindowsRemoteControl.Services;
using ArduinoWindowsRemoteControl.UI;
using ArduinoWindowsRemoteControl.Windows;
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
            container.RegisterType<ICommandDispatcher, CurrentActiveApplicationCommandDispatcher>();
            container.RegisterType<ICommandManager, WindowsActiveApplicationManager>(new ContainerControlledLifetimeManager());
            container.RegisterType<IArduinoDevice, StubArduinoDevice>();
            container.RegisterType<IApplicationCommandRepository, XMLFileApplicationCommandRepository>();
            container.RegisterType<ApplicationCommandPersistentService>();
            container.RegisterType<MainForm>();
            container.RegisterType<EditCommandForm>();

            return container;
        }
    }
}
