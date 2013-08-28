//Implementación del componente 
//Tópicos Selectos de Computación I
//Luis Gerardo Montané Jiménez

import org.smarthome.Conexion;
import org.omg.CORBA.*;
import org.omg.PortableServer.*;
import org.omg.PortableServer.POA;
import CasaApp.*;

public class CasaImpl extends CasaPOA {
  private static int x = 0;
  private ORB orb;

  public void setORB(ORB orb_val) {
    orb = orb_val; 
  }
 
  public boolean encender(String led){
	boolean result = false;  
	try{
               	Conexion con =  new  Conexion("192.168.1.177");
        	con.send(led + "\n\n");
        	con.close();
  		result = true;
	 }catch(Exception e){
        	
        }
  
	return result;
  }

  public String saludar() {    
    return "\nHola :) -> " + (x++) + "\n";
  }
    
  public int sumar(int x, int y) {
    return x + y;
  }
}