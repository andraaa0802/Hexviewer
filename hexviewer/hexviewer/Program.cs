using System;
using System.IO;

namespace hexviewer
{
    class Program
    {
        static void Main(string[] args)
        {
            string location = @"C:\Users\ANDRA\source\repos\Hewviewer\hexviewer\hexviewer\fisier.txt";
            using (FileStream file = File.OpenRead(location))
            {
                byte[] data = new byte[16];
                int amount;
                do
                {
                    string line = string.Empty;
                    Console.Write(hex(file.Position, 8) + ": ");
                    amount = file.Read(data, 0, 16);
                    
                        line += "| ";
                    for (int i = 0; i < amount; i++)
                    {
                        Console.Write(hex(data[i], 2) + " ");
                        if (data[i] < 32)

                            line += ".";
                        else
                            line += (char)data[i];
                    }
                    if (amount < 16)
                    {
                        
                        for (int i = amount; i < 16; i++)
                            Console.Write("   ");
                    }
                        
                    Console.WriteLine(line);
                } while (amount == 16);
            }
        }

        private static string hex(long position, int nr)
        {
            string hex = Convert.ToString(position, 16);
            while (hex.Length < nr)
                hex = "0" + hex;
            return hex;
        }
    }
}
