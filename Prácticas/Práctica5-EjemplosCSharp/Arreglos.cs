using System;
class Arreglos 
{
    public static void Main()
    {
        // Arreglos unidimensionales
        int[] numbers = new int[5];

        // Arreglos multidimensionales
	int nrow = 5;
	int ncolumn = 5;
        string[,] names = new string[nrow, ncolumn];

	for (int row = 0; row < nrow; row++){
		for(int column = 0; column < ncolumn; column++){
			if ((row + column) % 2 == 0)
				names[row, column] = "Par";
			else
				names[row, column] = "Non";
		}
	}

	for (int row = 0; row < nrow; row++){
		for(int column = 0; column < ncolumn; column++){
			Console.Write(names[row,column] + "\t");
		}
		Console.WriteLine();
	}


        // Arreglos de arreglos
        byte[][] scores = new byte[5][];


        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = new byte[i+3];
        }

	scores[0][0] = 2;
	Console.WriteLine("Valor: " + scores[0][0]);
        
        for (int i = 0; i < scores.Length; i++)
        {
            Console.WriteLine("Tamaño de fila {0} es {1}", i, scores[i].Length);
        }

	for (int i = 0; i < scores.Length; i++)
        {
		for (int j = 0; j < scores[i].Length; j++){
	            Console.Write(scores[i][j] + " ");
		}
		 Console.WriteLine();
        }
    }
}