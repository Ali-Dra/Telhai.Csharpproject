//  Using for other namespace 
using Telhai.Csharpproject.Database;

namespace Telhai.Csharpproject{
    internal class Program
    {
         static void Main(string[] args) {
            Console.WriteLine("hello world");
            Db d = new Db();
            FileManger fileManger = new FileManger();
            Console.ReadKey();
         }
    }
}
