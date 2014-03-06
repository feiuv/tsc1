using System;
using System.Threading;

class HiloDelegado{
	string nombre;
	static void Main(String[] args) 
	{  

		if (args.Length > 0){
			 HiloDelegado h1 = new HiloDelegado();
			 h1.nombre = args[0];
			 Thread t = new Thread (h1.Escribir);	
			 t.Start();

			 HiloDelegado h2 = new HiloDelegado();
			 h2.nombre = "nombre x";
			 Thread t1 = new Thread (h2.Escribir);	
			 t1.Start();
		}else
			Console.WriteLine("Parámetros incorrectos!!");
	}

	void Escribir(){
		Console.WriteLine(String.Format("Hola {0}!", nombre));
	}
}