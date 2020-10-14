using GeneratorGameTasks.Types;
using System;

namespace GeneratorGameTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskGenerator taskGenerator = new TaskGenerator();
            for (int i = 0; i < 20; i++)
            {
                Arithmetic3x3 arithmetic3x3 = taskGenerator.GenerateArithmetic3x3();
                Console.WriteLine(arithmetic3x3.ToString());
                Console.WriteLine("");
            }
            for (int i = 0; i < 20; i++)
            {
                Arithmetic4x4 arithmetic4x4 = taskGenerator.GenerateArithmetic4x4();
                Console.WriteLine(arithmetic4x4.ToString());
                Console.WriteLine("");
            }
        }

    }
}
