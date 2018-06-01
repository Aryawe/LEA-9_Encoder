using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileEncoder3
{
    class Program
    {

        static void Main(string[] args)
        {
            if (args.Length == 11)
            {
                String source = args[9];
                String path = args[10];

                int[] key = new int[9];

                for(int i = 0; i < 9; i++)
                {
                    if (!int.TryParse(args[i], out key[i]) ) writeError(0);
                }

                if (File.Exists(source) && !File.Exists(path))
                {
                    byte[] buffer = File.ReadAllBytes(source);

                    writeLine("File (" + buffer.Length / 1000 + " kb):"+ source);
                    writeLine("Processing file...");

                    File.WriteAllBytes(path, Crypt(buffer, key));

                    writeColouredLine("Done !\n", ConsoleColor.Green);
                }
                else
                {
                    writeError(1);
                }

            }
            else
            {
                writeError(0);
            }

        }

        private static byte[] Crypt(byte[] raw, int[] key)
        {
            int m = 256;
            byte[] buffer = new byte[raw.Length];
            
            for (int i = 0; i < buffer.Length; i += 3)
            {
                if (i + 1 == raw.Length)
                {
                    buffer[i] = raw[i];
                }
                else if (i + 2 == raw.Length)
                {
                    buffer[i] = raw[i];
                    buffer[i+1] = raw[i+1];
                } else
                {
                    buffer[i] = (byte)(((key[0] * raw[i]) + (key[1] * raw[i + 1]) + (key[2] * raw[i + 2])) % m) ;
                    buffer[i + 1] = (byte)(((key[3] * raw[i]) + (key[4] * raw[i + 1]) + (key[5] * raw[i + 2])) % m);
                    buffer[i + 2] = (byte)(((key[6] * raw[i]) + (key[7] * raw[i + 1]) + (key[8] * raw[i + 2])) % m);
                }
            }

            return buffer;
        }

        public static void writeLine(string text)
        {
            Console.Write("[" + DateTime.Now.ToLongTimeString() + "] ");
            Console.WriteLine(text);
        }

        public static void writeColouredLine(string text, ConsoleColor color)
        {
            Console.Write("[" + DateTime.Now.ToLongTimeString() + "] ");

            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ForegroundColor = old;
        }

        public static void writeErrorLine(string text)
        {
            Console.Write("[" + DateTime.Now.ToLongTimeString() + "] ");

            ConsoleColor old = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("ERROR: ");
            Console.ForegroundColor = old;
            Console.WriteLine(text);
        }

        public static void writeError(int error)
        {
            switch (error)
            {
                case 0:
                    writeErrorLine("Invalid argument");
                    break;
                case 1:
                    writeErrorLine("Source file not found or target file already exists.");
                    break;
                default:
                    break;
            }
        }
    }
}
