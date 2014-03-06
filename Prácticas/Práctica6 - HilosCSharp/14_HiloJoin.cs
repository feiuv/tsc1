using System;
using System.Threading;

// Hilo para iniciar un método estático en un segundo hilo
public class HiloEjemplo {
    // El método Prueba es llamado cuando inicia la ejecución del hilo
    // Itera 10 veces, escribiendo en consola y yielding 
    public static void Prueba() {
        for (int i = 0; i < 10; i++) {
            Console.WriteLine("Método Prueba: {0}", i);
            Thread.Sleep(0);
        }
    }

    public static void Main() {
        Console.WriteLine("Hilo Main : Iniciar un segundo hilo.");

        Thread t = new Thread(new ThreadStart((Prueba)));
        t.Start();
        Thread.Sleep(0);

        for (int i = 0; i < 4; i++) {
            Console.WriteLine("Hilo Main: Haciendo algo.");
            Thread.Sleep(0);
        }

        Console.WriteLine("Hilo Main: Llamar Join(), para esperar hasta que Prueba finalice.");
        t.Join();
        Console.WriteLine("Hilo Main: Prueba.Join ha regresado.  Presiona enter para salir.");
        Console.ReadLine();
    }
}