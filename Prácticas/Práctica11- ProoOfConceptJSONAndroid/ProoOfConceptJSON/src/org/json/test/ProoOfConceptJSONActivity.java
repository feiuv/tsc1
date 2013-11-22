package org.json.test;

import android.app.Activity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import android.widget.Toast;

import com.google.gson.Gson;
import java.io.*;
import java.text.SimpleDateFormat;
import java.util.Date;
import org.apache.http.HttpEntity;
import org.apache.http.HttpStatus;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.HttpResponse;


public class ProoOfConceptJSONActivity extends Activity {
    /** Called when the activity is first created. */
	
	static String srv = "http://demotsci.azurewebsites.net/ServiceJSON.svc";
	
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main);
        //Obtener estudiantes
        final Estudiante estudiantes[] = getEstudiantes();
        for (Estudiante e : estudiantes){
            System.out.println("Nombre: " + e.nombre);
        }
        System.out.println("***GetEstudiante***");
        Estudiante estudiante = getEstudiante("1");
        System.out.println("Nombre: " + estudiante.nombre);
        Spinner lstEstudiantes = (Spinner) findViewById(R.id.lstEstudiantes);   
        ArrayAdapter<Estudiante> adapter = new ArrayAdapter<Estudiante>(this, android.R.layout.simple_spinner_item, estudiantes);
        adapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        lstEstudiantes.setAdapter(adapter);
        
        //Configurar eventos
        lstEstudiantes.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
           
            public void onNothingSelected(AdapterView<?> parent) {
            }

			@Override
			public void onItemSelected(AdapterView<?> arg0, View view,
					int posicion, long id) {
		                Estudiante estudiante = estudiantes[posicion];
		                String cadena = estudiante.getNombreCompleto();
		                String valor = estudiante.getIdEstudinte();
		                mostrar(valor + ":" +cadena);
			
			}
        });
    }
    
    private void mostrar(String valor){
    	  Toast.makeText(this, "Seleccionó a " + valor, Toast.LENGTH_LONG).show();
    }
    

    private static HttpEntity getEntity(String uri){
    	DefaultHttpClient client = new DefaultHttpClient();
    	HttpGet request = new HttpGet(uri);
    	HttpEntity entity = null;
    	try {
    		HttpResponse response = client.execute(request);
    		if (response.getStatusLine().getStatusCode() != HttpStatus.SC_OK) {
    			entity = null;
    		}else
    			entity = response.getEntity();
               
        } catch (IOException ex) {
            ex.printStackTrace();
            request.abort();
        } 
        return entity;
    }
      

    //Prueba estudiantes
    public static Estudiante getEstudiante(String id){
        //List<Estudiante> estudiantes = new LinkedList<Estudiante>();
    	Estudiante estudiante = null;
    	try {
        	//System.out.println("Obtener estudiantes...");
    			HttpEntity entity = getEntity(srv + "/GetEstudiante?id=" + id);
        		Reader reader = new InputStreamReader(entity.getContent());
        	    Gson gson = new Gson();
                //Convertir el arreglo JSON a un arreglo en Java        	   
        	    estudiante = gson.fromJson(reader, Estudiante.class);
         
    	}catch(Exception e)
       {
    	   e.printStackTrace();
       }
        return estudiante;
    }
    
    
    //Prueba estudiantes
    public static Estudiante[] getEstudiantes(){
        //List<Estudiante> estudiantes = new LinkedList<Estudiante>();
    	Estudiante[] estudiantes = null;
    	try {
        	//System.out.println("Obtener estudiantes...");
    			HttpEntity entity = getEntity(srv + "/GetEstudiantes");
        		Reader reader = new InputStreamReader(entity.getContent());
        	    Gson gson = new Gson();
                //Convertir el arreglo JSON a un arreglo en Java        	   
        	    estudiantes = gson.fromJson(reader, Estudiante[].class);
         
    	}catch(Exception e)
       {
    	   e.printStackTrace();
       }
        return estudiantes;
    }
    
}