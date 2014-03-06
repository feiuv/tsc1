using System;
using System.Threading;

class DormirHilo
{
    static void Main()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Durmiendo 3 segundos.");
            Thread.Sleep(3000);
        }

        Console.WriteLine("Terminando hilo principal Main.");
    }
}
