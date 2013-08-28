//Simple cliente
//Tópicos Selectos de Computación I
//Luis Gerardo Montané Jiménez

import java.io.*; 
import java.net.*;

public class ClienteHTTP{
    public static void main(String[] args) {
      String servidor = "127.0.0.1";
      int puerto = 36750;
      try{
        Socket socket= new Socket (servidor,puerto);
        BufferedReader in = new BufferedReader (new InputStreamReader(socket.getInputStream()));
        PrintWriter out = new PrintWriter(new OutputStreamWriter(socket.getOutputStream()),true);
	
/*	String soap = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n"
		      + "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">\n"
		      + "<soap:Body>\n"
 		      + "<GetCitys xmlns=\"http://tempuri.org/\">\n"
			//+ "<longitud>12</longitud>\n"
			//+ "<latitud>42</latitud>\n"
			+ "</GetCitys>\n"
			+ "</soap:Body>\n"
			+ "</soap:Envelope>\n";

*/
/*	String peticion  = "POST /Test.asmx/GetCitys HTTP/1.1\r\n" 
			   + "Host: localhost:36750 \r\n" 
			   + "Content-Type: application/json; charset=utf-8\r\n";
			  // + "SOAPAction: \"http://tempuri.org/GetCitys\"\r\n"
			   + "Content-Length: " + soap.length() + "\r\n\r\n"
			   + soap;	 */

//	String peticion  = "GET /Test.asmx/GetSites?longitud=122&latitud=321 HTTP/1.1\r\n" 
//			   + "Host: localhost:36750 \r\n" 
//			   + "Content-Type: application/json; charset=utf-8\r\n";

	String tmp = "longitud=122&latitud=321";
	String peticion  = "GET /Test.asmx/GetSites?longitud=122&latitud=321 HTTP/1.1\r\n" 
			   + "Host: localhost:36750 \r\n" 
			   + "Content-Type: application/json; charset=utf-8\r\n";
//			   + "Content-Length: " + tmp.length() + "\r\n\r\n"
		 	 //  + tmp;


/*			   + "SOAPAction: \"http://tempuri.org/GetSites\"\r\n"
			   + "Content-Length: " + soap.length() + "\r\n\r\n"
 			    + soap;	 */
	
	System.out.println(peticion);	
        out.println(peticion);

	String line = "";
	while  ((line = in.readLine()) != null){
		System.out.println(line);
	}
        socket.close();
      } catch (IOException e)
      {
       		System.out.println("Error en conexión!!!");
      }
      
    }
}