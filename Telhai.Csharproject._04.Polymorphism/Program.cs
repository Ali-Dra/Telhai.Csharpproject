using System.Collections.Generic;
using System.Drawing;

namespace Telhai.Csharproject._04.Polymorphism {

    internal class Program
    {
        public static void Main()
        {
            string userName = Environment.UserName;
            string machineName = Environment.MachineName;
            string osVersion = Environment.OSVersion.ToString();

            Console.WriteLine($"Current User: {userName}");
            Console.WriteLine($"Machine Name: {machineName}");
            Console.WriteLine($"Operating System: {osVersion}");
            Console.WriteLine("-----------");
            Drawing square = new Square();
            Drawing square2 = new Square();

            Drawing rectangle = new Rectangle();
            Drawing rectangle2 = new Rectangle();

            List<Drawing> array = new List<Drawing>();
            array.Add(square);
            array.Add(square2);
            array.Add(rectangle);
            array.Add(rectangle2);
            array.ForEach(item => Console.WriteLine(item.Area()));

            Dictionary<string, Drawing> dict = new Dictionary<string, Drawing>()
        {
            {"square",square},
            {"square2",square2},
            {"rectangle",rectangle},
            {"rectangle2",rectangle2}
        };

            foreach (KeyValuePair<string, Drawing> entry in dict)
            {
                var name = entry.Key;
                var shape = entry.Value;
                Console.WriteLine($"Shape: {name}, Area of the shape: {shape.Area()}");
            }


            Console.WriteLine(square);
            Console.WriteLine(rectangle);
        }


    }

}


