using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Utilities
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdArgs = args .Split(' ');
            string commandName = cmdArgs[0];
            string[] invokeArgs = cmdArgs.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();
            Type intendedCmdType = assembly.GetTypes().FirstOrDefault(t => t.Name == $"{commandName}Command");
            if (intendedCmdType == null)
            {
     
                throw new InvalidOperationException("Invalid command type");       }

            MethodInfo executeMethodInfo = intendedCmdType.GetMethods(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(m=>m.Name == "Execute");
            if (executeMethodInfo==null)
            {
                throw new InvalidOperationException("Command does not implement required pattern");
            }
            object cmdInstance = Activator.CreateInstance(intendedCmdType);
            string result = (string)executeMethodInfo.Invoke(cmdInstance, new object[] { invokeArgs });

            return result;


        }
    }
}
