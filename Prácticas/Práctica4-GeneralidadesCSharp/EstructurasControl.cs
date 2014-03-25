using System.Collections.Generic; 
using Out = System.Console;
class EstructurasControl{	
	static void Main(){
		int i = 0;
		while(i < 10){
			Out.WriteLine("while # {0}", i++);
		}
		 
		Out.WriteLine("***************************");





		i = 0;
		do{
			Out.WriteLine("do # {0}", i++);
		}while(i < 10);





		Out.WriteLine("***************************");		 


		for (i = 0; i < 10; i++){
			Out.WriteLine("for # {0}", i);

		}

         Out.WriteLine("***************************");		 

		int[] numeros = new int[]{4,51,1,3};
//		numeros.Add(5);
//		numeros.Add(4);		
//		numeros.Add(8);




		foreach(int i1 in numeros){
			
			Out.WriteLine("foreach # {0}", i1);		
		}		




		Out.WriteLine("***************************");		 		
		switch(i){
			case 1:
				Out.WriteLine("switch - 1");
				break;

			case 2:
			case 10:
				Out.WriteLine("switch - 2,10");
				break;
			default:
				Out.WriteLine("switch Default");
				break;
		}
	}
}