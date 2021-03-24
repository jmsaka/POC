
namespace File
{
    //https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/file-system/how-to-read-a-text-file-one-line-at-a-time
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            string line;

            // Read the file and display it line by line.  
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"c:\temp\teste.txt");
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine(line);
                System.Console.WriteLine(line.Substring(1,3));
                counter++;
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            System.Console.ReadLine();
        }
    }
}
