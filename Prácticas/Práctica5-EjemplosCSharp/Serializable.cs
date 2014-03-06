using System;
using System.IO;
public class Persona 
{
  public string Apellido {get;set;}
  public string Nombre;
}

class Serializable
{ 
   static void Main(string[] args)
   {
	string archivo = "Persona.txt";
	Persona p = new Persona();
	p.Nombre = "Juan";
	p.Apellido = "Pérez";

	//Serializar
	System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(p.GetType());
	using(TextWriter tw = new StreamWriter(archivo)){
		Console.WriteLine("Serializando....!");
	        x.Serialize(tw, p);	
	}


	//Deserializar
		Console.WriteLine("Deserializando....!");



	System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(Persona));
	StreamReader archivoSR = new StreamReader(archivo);
	Persona personaTmp = new Persona();
	personaTmp = (Persona)reader.Deserialize(archivoSR);

	Console.WriteLine(personaTmp.Apellido);
        Console.ReadLine();
   }
}