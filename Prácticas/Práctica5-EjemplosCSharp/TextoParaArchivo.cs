using System;
using System.IO;
public class TextoParaArchivo 
{ 
    private const string FILE_NAME = "Archivo2.txt";
    public static void Main(String[] args) 
    {
        if (File.Exists(FILE_NAME)) 
        {
            Console.WriteLine("{0} ya existe.", FILE_NAME);
            return;
        }
        using (StreamWriter sw = File.CreateText(FILE_NAME))
        {
            sw.WriteLine ("Esto es mi archivo.");
            sw.WriteLine ("Yo puedo escribir enteros {0} o flotantes {1}.", 
                1, 4.2);
            sw.Close();
        }
    }
}