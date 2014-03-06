using System; 
  class Persona
  {
     // Campo de cada objeto Persona que almacena su nombre
     public string Nombre;      
     // Campo de cada objeto Persona que almacena su edad
     public int Edad;               
     // Campo de cada objeto Persona que almacena su NIF
     public string NIF;             
     
     // Incrementa en uno la edad del objeto Persona 
     public virtual void Cumpleaños() 
     {
     Console.WriteLine("Incrementada edad de persona");
     }
  
     public void Imprimir(){
	Console.WriteLine("hola0");
     }

     // Constructor de Persona
     public Persona (string nombre, int edad, string nif) 
     {
      Nombre = nombre;
      Edad = edad;
      NIF = nif;
     } 
  }
  
  class Trabajador: Persona
  
  {  // Campo de cada objeto Trabajador que almacena cuánto gana
     int Sueldo; 
  
     Trabajador(string nombre, int edad, string nif, int sueldo)
         : base(nombre, edad, nif)
     { // Inicializamos cada Trabajador en base al constructor de Persona 
		Sueldo = sueldo; 
     }
  
	new public void Imprimir(){
		Console.WriteLine("hola");
	}

    public override void Cumpleaños()
     {
     Edad++;
     Console.WriteLine("Incrementada edad de trabajador");
     }          
  
     public static void Main()
     {
        Persona p = new Trabajador("Josan", 22, "77588260-Z", 100000);
        p.Cumpleaños();      

	Trabajador t =  new Trabajador("Luis", 22, "77588260-Z", 100000);
	p.Imprimir();
        // p.Sueldo++; //ERROR: Sueldo no es miembro de Persona
     }
  }