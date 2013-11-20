package org.json.test;

/**
*
* @author msicu
*/
public class Estudiante
{
   public String id;
   public String nombre;
   public String apellidopaterno;
   public String apellidomaterno;
   public String matricula;
   public String direccion;
   
   public String getIdEstudinte(){
	   return id;
   }
   public String getNombreCompleto(){
	   return String.format("%s %s %s", nombre, apellidopaterno, apellidomaterno);
   }
   
   public String toString(){
	   return String.format("%s %s %s", nombre, apellidopaterno, apellidomaterno);
   }
   
}


