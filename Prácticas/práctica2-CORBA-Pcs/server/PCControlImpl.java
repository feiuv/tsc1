//Implementación del componente 
//Tópicos Selectos de Computación I
//Luis Gerardo Montané Jiménez

import org.smarthome.Conexion;
import org.omg.CORBA.*;
import org.omg.PortableServer.*;
import org.omg.PortableServer.POA;
import PCControlApp.*;
import PCControlApp.PCControlPackage.*;

public class PCControlImpl extends PCControlPOA {
  private static int x = 0;
  private ORB orb;
  private static Pc[] pcs = new Pc[10];
  private static int index = 0;

  public void setORB(ORB orb_val) {
    orb = orb_val; 
  }
 
  public boolean registrar(PCControlApp.PCControlPackage.Pc pc){
	boolean result = false;  
	try{
		if (pc != null && index < pcs.length){
			 pcs[index] = pc; 
			index++;
			result = true;
		}
		
	 }catch(Exception e){
        	
        }
  
	return result;
  }

  public PCControlApp.PCControlPackage.Pc[] getPcs () {    
  	Pc[] pcsNN = new Pc[index];
	for (int itmp = 0; itmp < index; itmp++)
	{		
		pcsNN[itmp] = pcs[itmp];
	}
  	return pcsNN;
  }
 }