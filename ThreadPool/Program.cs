using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPool
{
    class Program
    {

        static string nome;
        static List<string> nomi = new List<string>();


        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("nomi.txt");
            string file = "nomi.txt";
            if (File.Exists(file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    nomi.Add(line);
                }

                Console.WriteLine("Inserisci un nome cognome da cercare");
                nome = Console.ReadLine();

                Stopwatch time = new Stopwatch();

                Console.WriteLine("Ricerca con 10 Thread :");
                time.Start();
                Thread();
                time.Stop();
                Console.WriteLine($"Tempo impiegato dai Thread : {time}\n");

                time.Reset();

                Console.WriteLine("Ricerca con ThreadPool :");
                time.Start();
                ThreadPoolMethod();
                time.Stop();
                Console.WriteLine($"Tempo impiegato dal ThreadPool : {time}");
            }
        }

        static void Thread()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(Research);
                t.Start();
            }
        }

        static void ThreadPoolMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Research));
            }
        }

        static void Research(object callback)
        {
            bool trovato = false;
            for (int i = 0; i < nomi.Count; i++)
            {
                if (nome == nomi[i])
                {
                    Console.WriteLine($"Il nome ' {nome} ' si trova in posizione {i}.");
                    trovato = true;
                }
            }

            if (trovato == false)
            {
                Console.WriteLine($"Il nome ' {nome} ' non è stato trovato.");
            }
        }
    }
}
