package org.smarthome;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.UnknownHostException;

public class Conexion {
	private String ip = "192.168.1.177";
	private int port = 80;
	private Socket s;
	BufferedReader in;
	PrintWriter out;
	public Conexion(String value) throws UnknownHostException, IOException{
		 ip = value;
		 s =  new Socket(ip, port);
		 //s.setSoTimeout(4000);
		 out = new PrintWriter(s.getOutputStream(),true);
		 in = new BufferedReader(new InputStreamReader(s.getInputStream(), "UTF8"));
	}

	public String read() throws IOException{	
		return  new String(in.readLine().getBytes(), "UTF-8");
	}
	
	public void send(String command) throws IOException{		
		out.println(command);
		
		//out.flush();
		//out.close();
	}
	
	public void close() throws IOException{	
		out.flush();
		out.close();
	}
	
}
