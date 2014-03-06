using System;
using System.Threading;
class Prioridad
{  
	 static void Main (string[] args) 
	 {    
		  Thread worker = new Thread (delegate() { 
			Console.Write("Escribe nombre: ");
			string nombre = Console.ReadLine(); 
			Console.Write("Hola " + nombre);
		  });    
		  if (args.Length > 0)
			 worker.IsBackground = true;   
		  worker.Start();  
	 }
}