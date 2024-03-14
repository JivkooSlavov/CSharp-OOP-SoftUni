using CommandPattern.Core.Contracts;
using CommandPattern.IO;
using CommandPattern.IO.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICommandInterpreter cmdInterpreter;

        public Engine()
        {
            this.reader = new ConsoleReader();
            this.writer = new ConsoleWriter();
        }
        public Engine(ICommandInterpreter commandInterpreter) : this()
        {
            this.cmdInterpreter = commandInterpreter;
        }


        public void Run()
        {
            while (true)
            {
                try
                {
                    string inputLine = this.reader.ReadLine();
                    string result = this.cmdInterpreter.Read(inputLine);
                    this.writer.WriteLine(result);
                }
                catch (InvalidOperationException ex)
                {

                    this.writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
