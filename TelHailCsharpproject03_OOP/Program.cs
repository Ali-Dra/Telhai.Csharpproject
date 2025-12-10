namespace TelHailCsharpproject03_OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayList l1 = new PlayList();
            Type type = l1.GetType();
            type.ToString();

            l1.Name = "Chill_out";// set
            var name_playlist = l1.Name;//get

            l1.Name += "play list";//set and get 

            int count = l1.Count;

            PlayList l2 = new PlayList();
            l2.Name = "TECHNO";
            l2.Id = 1000;

            PlayList l3=new PlayList("AMBIENT");

            PlayList l4 = new PlayList { Id = 1001, Name = "LOAZI" };
            string osVersion = Environment.OSVersion.ToString();
            string userName = Environment.UserName;
            string machineName = Environment.MachineName;

            Console.WriteLine($"Current User   : {userName}");
            Console.WriteLine($"Machine Name   : {machineName}");
            Console.WriteLine($"OS Version     : {osVersion}");
            Console.WriteLine("-------------------");

            Console.ReadKey();


        }
    }
}
