using System;
using System.Threading;

class HiloDelegado{
	static void Main(String[] args) 
	{  
		if (args.Length > 0){
			 HiloDelegado h1 = new HiloDelegado();
			 Thread t = new Thread (delegate()
			 {
				h1.Escribir(args[0]);				
			 });
			 t.Start();
		}else
			Console.WriteLine("Parámetros incorrectos!!");
	}

	void Escribir(object nombre){
		Console.WriteLine(String.Format("Hola {0}!", nombre));
	}
}