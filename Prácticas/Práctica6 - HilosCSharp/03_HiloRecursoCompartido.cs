using System;
using System.Threading;

class HiloSencillo 
{
	int numero;
	static void Main() 
	{    
		Thread.CurrentThread.Name = "Main";
		HiloSencillo h1 = new HiloSencillo();
		Thread t = new Thread(h1.Escribe);
		t.Name = "Escribe";
		t.Start();
		h1.Escribe();
	}

	void Escribe() 
	{
		for (int i = 0; i < 10; i++)
				Console.Write("-> " + numero++);
	}
}