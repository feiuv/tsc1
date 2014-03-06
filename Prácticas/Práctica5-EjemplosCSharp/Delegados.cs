using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



public class Delegado 
{
        // Declare a delegate
        public delegate void Imprimir(string s);

        public delegate int DelCalcular(int x, int y); 
         

        // Create a method for a delegate.
        public static int Calcular(int x, int y)
        {
           return x + y;
        }


}



class Ejecucion{       
	public static void Main(){


		Console.WriteLine("***************Delegate**************");

		Delegado.DelCalcular handler = Delegado.Calcular;   

		Console.WriteLine(handler(3,1));
         
		//Delegado anonimo

		Delegado.Imprimir d = delegate(string s) {
	                    System.Console.WriteLine("Impresión delegado: " + s); 
        	};



               d("Hola mundo");



	       DelegateTest(d);	
	}

	public static void DelegateTest(Delegado.Imprimir d){
		Console.Write("Dentro de método DelegateTest => " ); 
		d("Saludos!");
	}
}