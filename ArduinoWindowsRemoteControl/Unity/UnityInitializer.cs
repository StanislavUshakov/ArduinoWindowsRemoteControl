using ArduinoWindowsRemoteControl.Interfaces;
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
            container.RegisterType<ICommandManager, WindowsActiveApplicatinoManager>();
            container.RegisterType<MainForm>();

            return container;
        }
    }
}
