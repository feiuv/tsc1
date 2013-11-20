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
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.HttpResponse;


public class ProoOfConceptJSONActivity extends Activity {
    /** Called when the activity is first created. */
	static String srv = "http://10.116.92.84/wcfTest/SrvSROSI.svc";
	
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
        HttpClient httpClient = new DefaultHttpClient();
        HttpEntity entity = null;
        try {
            HttpGet httpget = new HttpGet(uri);
            HttpResponse response = httpClient.execute(httpget);
            entity = response.getEntity();
        } catch (IOException ex) {
            //Hacer algo
        } 
        return entity;
    }
    
    public static Estudiante getEstudiante(String idEstudiante){
        Estudiante estudiante = null;
        try {
            
            HttpEntity entity = getEntity(srv + "/GetEstudiante/1");

            if (entity != null) {
                InputStream instream = entity.getContent();
                try {
                    BufferedReader reader = new BufferedReader(new InputStreamReader(instream));
                    String str = reader.readLine();
                    
                    Gson gson = new Gson();
                    
                    estudiante = gson.fromJson(str, Estudiante.class);
                } catch (IOException ex) {
                    throw ex;
                 }finally {
                    instream.close();
                }
            }
        }catch(Exception e1){}
        return estudiante;
    }
    
    
    public static Estudiante[] getEstudiantes(){
        Estudiante estudiantes[] = null;
        try {
            
            HttpEntity entity = getEntity(srv + "/GetEstudiantes");

            if (entity != null) {
                InputStream instream = entity.getContent();
                try {
                    BufferedReader reader = new BufferedReader(new InputStreamReader(instream));
                    String str = reader.readLine();
                    //Crear una instancia de Gson
                    Gson gson = new Gson();
                    //Convertir el arreglo JSON a un arreglo en Java
                    estudiantes = (Estudiante[]) gson.fromJson(str, Estudiante[].class);
                } catch (IOException ex) {
                    throw ex;
                 }finally {
                    instream.close();
                }
            }
        }catch(Exception e1){}
        return estudiantes;
    }
    
}