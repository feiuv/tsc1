//Implementación del componente 
//Tópicos Selectos de Computación I
//Luis Gerardo Montané Jiménez

import org.smarthome.Conexion;
import org.omg.CORBA.*;
import org.omg.PortableServer.*;
import org.omg.PortableServer.POA;
import HolaApp.*;

public class HolaImpl extends HolaPOA {
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
		Thread.sleep(2000);
            	con.close();

               	con =  new  Conexion("192.168.1.177");
        	con.send(led + "\n\n");
		Thread.sleep(2000);
            	con.close();

	   	con =  new  Conexion("192.168.1.177");
        	con.send(led + "\n\n");
		Thread.sleep(2000);
            	con.close();

	   	con =  new  Conexion("192.168.1.177");
        	con.send(led + "\n\n");
		Thread.sleep(2000);
            	con.close();

  		result = true;
	 }catch(Exception e){
		        	
        }
  
	return result;
  }
    
  public String saludar() {    
    return "\nHolaExt :) -> " + (x++) + "\n";
  }
    
  public int sumar(int x, int y) {
    return x + y + 1000;
  }
}