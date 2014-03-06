using System;
using System.Threading;

class HiloSencillo 
{  
	static void Main() 
	{    
		Thread t = new Thread (Escribe);   
		t.Start();                          // Ejecuta Hola en un nuevo thread    

		for (int i = 0; i < 10; i++)
			Console.Write ("Main: Hola!!\t");   
	}



	static void Escribe() 
	{    

		for (int i = 0; i < 10; i++)
			Console.Write("Escribe: Hola!!\t"); 
	}
}