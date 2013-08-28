//Simple Servidor 
//Tópicos Selectos de Computación I
//Luis Gerardo Montané Jiménez

import java.net.*;
import java.io.*;
public class Server{
	public static void main(String args[]){
		try {
			int puerto = 5000;
			ServerSocket s = new ServerSocket(puerto);
			String comandoSalir = "Exit";
			String entrada = "";
			System.out.println("Servidor iniciado en el puerto " + puerto + "...");
			while(true){
				Socket s1 = s.accept();        
				System.out.println("Aceptando conexion....");
				PrintWriter out = new PrintWriter(s1.getOutputStream(), true);
				BufferedReader in = new BufferedReader(new InputStreamReader(s1.getInputStream()));

				while ((entrada = in.readLine()) != null) {					
				    System.out.println(entrada);
				    String pathDesktop = System.getProperty("user.home") + "/Desktop/";
				    PrintWriter writer = new PrintWriter(pathDesktop + "README.txt", "UTF-8");
				    writer.println("Hola clase de Tópicos I");
				    writer.println("");
				    writer.close();
				    out.println("Respondiendo desde el servidor!!");
				    if (entrada.trim().equals(comandoSalir))
				        return;
				}
			}

		} catch (IOException e) {
			System.out.println("No se pudo iniciar el servidor en el puerto 5000!!");
			System.exit(-1);
		}
	}


}