using System;
using System.Threading;

class HiloSencillo 
{
	static void Main() 
	{    
		Thread.CurrentThread.Name = "Main";
		Thread t = new Thread (Escribe);
		t.Name = "Escribe";
		t.Start();
		Escribe();
	}

	static void Escribe() 
	{
		for (int i = 0; i < 10; i++)
			Console.Write(Thread.CurrentThread.Name + ": Hola!!\t");
	}
}