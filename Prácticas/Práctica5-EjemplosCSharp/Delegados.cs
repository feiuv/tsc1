using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



public class Delegado 
{
        //1era
        public static int Calcular(int x, int y)
        {
           return x + y;
        }

 	    public delegate int DelCalcular(int x, int y); 
       
        //2da
        public delegate void Imprimir(string s);

        //3ra
	    public delegate void ImprimirLambda(string s);


}



class Ejecucion{
    public static void Main()
    {

        Console.WriteLine("***************Delegate**************");

        Delegado.DelCalcular handler = Delegado.Calcular;

        Console.WriteLine(handler(3, 1));


        //Delegado anonimo

        Delegado.Imprimir d = delegate(string s)
        {
            System.Console.WriteLine("Impresión delegado: " + s);
        };


        d("Hola mundo");


        Delegado.ImprimirLambda d1 = n =>
        {
            string s = n + " - TSCI";
            Console.WriteLine(s);
        };


        d1("Hola mundo");

        DelegateTest(d);

    }

	public static void DelegateTest(Delegado.Imprimir d){
		Console.Write("Dentro de método DelegateTest => " ); 
		d("Saludos!");
	}
}