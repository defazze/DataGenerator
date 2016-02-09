using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator.BL;
using DataGenerator.Data;

namespace DataGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();
            repository.Init();

            ScriptGenerator generator = new ScriptGenerator(repository);
            string result = generator.CreateScript(1000);

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
