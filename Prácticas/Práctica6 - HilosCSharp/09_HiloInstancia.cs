using System;
using System.Threading;

class HiloDelegado{
	static void Main() 
	{  
		 HiloDelegado h1 = new HiloDelegado();
		 Thread t = new Thread (h1.Escribir);
		 t.Start();
	}

	void Escribir(){
		Console.WriteLine("Hola!");
	}
}