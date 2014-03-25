using System;
using sys = System; 
using prt = System.Console;
using System.Collections.Generic;

public struct Book
{
    public decimal price;
    public string title;
    public string author;

    public decimal Price{
        set
        {
            price = value;
        }
        get
        {
            return price;
        }
    }
}



public class Program{
	static void Main(){
		Book b = new Book();
		b.Price = 1;
		b.title = "titulo";
		
		b.author = "alguien";

		Book b1 = b;
		
		b1.price = 23;

		b.price = 21;

		prt.WriteLine(b.price);
		sys.Console.WriteLine(b1.price);


		string cad = "";
		String cad1 = "";
		List<string> lst = new List<string>();

		lst.Add("x");
		lst.Add("y");
		lst.Add("z");

		

		foreach (string s in lst){
			prt.WriteLine(s);

		}


	}
}
