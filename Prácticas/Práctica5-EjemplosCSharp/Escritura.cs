using System;
using System.IO; 

class Escritura
{
    public static void Main() 
    {
        // Crear una instancia de StreamWriter para escribir texto en un archivo.
        // Usar "usign" al crear StreamWriter para cerrar el archivo.
        using (StreamWriter sw = new StreamWriter("Archivo1.txt")) 
        {

            sw.WriteLine("**********************");
            sw.Write("Esto es una prueba de escritura123!");
            sw.WriteLine("**********************");

            sw.Write("La fecha es: ");
            sw.WriteLine(DateTime.Now);

        }
    }
}