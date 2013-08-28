//Un simple servidor que responde html
//Tópicos Selectos de Computación I
//Luis Gerardo Montané Jiménez 
//Trabaja en el puerto 8000
import java.net.*;
import java.io.*;
class AtenderCliente extends Thread {
	private Socket conexionCliente;
	
	private static int nCliente = 0;
	//Etiquetas HTML
	private	String html = "<HTML>\n"
					+ "<HEAD>\n"
					+ "<TITLE>Respuesta del Servidor</TITLE>\n"
					+ "<SCRIPT language=\"javascript\">\n"
					+ "	alert(\"Incrustando javascript!!\");\n"
					+ "</SCRIPT>\n"
					+ "</HEAD>\n"
					+ "<BODY>\n"
					+ "<MARQUEE><H1>Respondiendo desde el servidor =)</H1></MARQUEE>\n"
					+ "<H1>Clase Tópicos Selectos de Computación I: " + nCliente  + "</H1>\n"
					+ "</BODY>\n"
					+ "</HTML>\n";
	//Etiquetas HTTP
	private String respuestaHTTP = "HTTP/1.1 200 OK\r\n"
					      + "Content-Type: text/html\r\n"
					      + "Server: Personalizado\r\n"							
					      + "Date: Fri, 31 Dec 2012 00:00:01 GMT\r\n"
					      + "Content-Length: "+ html.length() + "\r\n"
					      + "\r\n"
					      + html;
	
	public AtenderCliente(Socket conexionCliente){
		this.conexionCliente = conexionCliente;		
	}
	
	//Método que es llamado para la ejecución del hilo
	public void run(){
		try{
			System.out.println("Aceptando conexion....");

			PrintWriter out = new PrintWriter(conexionCliente.getOutputStream(), true);
			BufferedReader in = new BufferedReader(new InputStreamReader(conexionCliente.getInputStream()));

			System.out.println("**Pertición HTTP -> " + ++nCliente + "\n");	
			//Leer lo que sea y responder 
			System.out.println(in.readLine());

			System.out.println("Respondiendo....\n\n\n");	

			out.println(respuestaHTTP);			
			out.close();
		}catch(IOException e){
			System.out.println("Error desde el servidor!!");
		}
	}
}


//Servidor que reacciona enviado HTTP simple
public class ServerHTTP{
	public static void main(String args[]){
		int puerto = 8000;
		try {

			ServerSocket s = new ServerSocket(puerto);
			String comandoSalir = "Exit";
			String entrada = "";
			System.out.println("Servidor iniciado en el puerto " + puerto + "...");
			while(true){
				Socket s1 = s.accept(); 
				new AtenderCliente(s1).start();
			}

		} catch (IOException e) {
			System.out.println("No se pudo iniciar el servidor en el puerto " + puerto + "!!");
			System.exit(-1);
		}
	}


}