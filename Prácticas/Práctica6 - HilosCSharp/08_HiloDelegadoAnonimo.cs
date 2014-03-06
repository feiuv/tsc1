using System;
using System.Threading;

class HiloDelegado{
	static void Main() 
	{  
		 Thread t = new Thread (delegate() 
		 { 
			  Console.WriteLine ("Hola!"); 
		 });  
		 t.Start();
	}
}