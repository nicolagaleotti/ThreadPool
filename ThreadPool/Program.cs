using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("nomi.txt");
            string file = "nomi.txt";
            if (File.Exists(file))
            {
                List<string> nomi = new List<string>();
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    nomi.Add(line);
                }

                Console.WriteLine("Inserisci un nome cognome da cercare");
                string nome = Console.ReadLine();
            }
        }

        private static void Thread(string nome, List<string> nomi)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(() => Research(nome, nomi));
                t.Start();
            }
        }

        private static void ThreadPool()
        {

        }

        private static string Research(string s, List<string> nomi)
        {
            for (int i = 0; i < nomi.Count; i++)
            {
                if (s == nomi[i])
                {
                    return $"Il nome ' {s} ' si trova in posizione {i}.";
                }
            }
            return $"Il nome ' {s} ' non è stato trovato.";
        }
    }
}
