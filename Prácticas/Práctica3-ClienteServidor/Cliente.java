//Simple cliente
//Tópicos Selectos de Computación I
//Luis Gerardo Montané Jiménez
 
import java.io.*;
import java.net.*;

public class Cliente{
    public static void main(String[] args) {
      String servidor = "127.0.0.1";
      int puerto = 5000;
      try{
        Socket socket= new Socket (servidor,puerto);
        BufferedReader in = new BufferedReader (new InputStreamReader(socket.getInputStream()));
        PrintWriter out = new PrintWriter(new OutputStreamWriter(socket.getOutputStream()),true);
        out.println("Saludos desde el cliente!!");
	out.println("respuesta");
	System.out.println(in.readLine());
        socket.close();
      } catch (IOException e)
      {
       		System.out.println("Error en conexión!!!");
      }
      
    }
}