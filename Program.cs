using System;

namespace CharacterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IInput input = new ConsoleInput();
            IOutput output = new ConsoleOutput();
            string filePath = "input.csv";

            var manager = new CharacterManager(input, output, filePath);
            manager.Run();
        }
    }

    public class ConsoleInput : IInput
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }

    public class ConsoleOutput : IOutput
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public void Write(string message)
        {
            Console.Write(message);
        }
    }
}
