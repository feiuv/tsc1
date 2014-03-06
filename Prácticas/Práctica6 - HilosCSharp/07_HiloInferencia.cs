using System;
using System.Threading;

class HiloDelegado{
	static void Main() 
	{  
		 Thread t = new Thread (Escribir);
		 t.Start();
	}

	static void Escribir(){
		Console.WriteLine("Hola!");
	}
}