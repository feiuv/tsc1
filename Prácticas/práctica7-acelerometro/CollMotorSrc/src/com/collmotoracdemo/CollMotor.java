package com.collmotoracdemo;

import java.io.IOException;


import android.app.Activity;
import android.app.AlertDialog;
import android.content.ContentValues;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Configuration;
import android.os.Bundle;
import android.preference.PreferenceManager;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.Window;
import android.view.WindowManager;
import android.widget.TextView;
import android.widget.Toast;

public class CollMotor extends Activity  {
	DataBaseHelper myDbHelper;	
	static double[] accelerometerX = new double[200];
	static double[] accelerometerY = new double[200];
	static double[] accelerometerZ = new double[200];
	
	static int row = 0;
	static int col = 0;
	private static final String TAG = "Activity Recognition";
	TextView txtUbicacion;
 	TextView txtActividad;
	TextView txtLongitude;
 	TextView txtLatitude;
 	TextView txtTelefonia;
 	TextView txtEstadoLlamada;
 	TextView txtEstadoBateria;
	private AlertDialog alert;
	SharedPreferences prefs;

	@Override
	protected void onResume() {
		super.onResume();
	}
	
	
	public void onScreen(){
		Window myWindow = getWindow();	
		WindowManager.LayoutParams lp = myWindow.getAttributes();
		lp.screenBrightness = (.8f);
    	myWindow.setAttributes(lp);
    	
	}
	public void offScreen(){
		Window myWindow = getWindow();	
		WindowManager.LayoutParams lp = myWindow.getAttributes();
		lp.screenBrightness = 0.04f;
    	myWindow.setAttributes(lp);
	}


	@Override
	public void onCreate(Bundle savedInstanceState) {		
		super.onCreate(savedInstanceState);
   		setContentView(R.layout.collmotor);
    	prefs  = PreferenceManager.getDefaultSharedPreferences(this);
	    txtUbicacion = (TextView) findViewById(R.id.txtUbicacion);
	    txtActividad = (TextView) findViewById(R.id.txtActividad);
	    txtTelefonia = (TextView) findViewById(R.id.txtTelefonia);
	    txtEstadoLlamada = (TextView) findViewById(R.id.txtEstadoLlamada);
	    txtEstadoBateria = (TextView) findViewById(R.id.txtEstadoBateria);
	    txtLongitude = (TextView) findViewById(R.id.txtLongitude);
	    txtLatitude = (TextView) findViewById(R.id.txtLatitude);
	    
		Log.d(TAG, "onCreate()");
		startService(new Intent(this, Main.class));
		Main.setCollMotor(this);
	}
		   
	public void settingDatabase(){
		myDbHelper = new DataBaseHelper(this);
	    try {
		   myDbHelper.createDataBase();
		   try {				 
		 		myDbHelper.openDataBase();
		 	}catch(Exception sqle){	 
		 		Toast.makeText(this, sqle.toString(),
				Toast.LENGTH_LONG).show();
		 	}		
	   }catch (IOException ioe) {
	  	   throw new Error("No se pudo crear la base de datos");
	   }
	 
	}
	
	  @Override
	    public boolean onCreateOptionsMenu(Menu menu) {
	        MenuInflater inflater = getMenuInflater();
	        inflater.inflate(R.menu.collmotor, menu);
	        return true;
	    }
	    
	    @Override
	    public boolean onOptionsItemSelected(MenuItem item) {
	        // Manejar eventos del menu
	        switch (item.getItemId()) {	        
			
	        case R.id.ub_info:	        	 
	        	Main.myDbHelper.delete("ubication_gps_info");
	        	Toast.makeText(this, "Datos de ubicación eliminados", Toast.LENGTH_LONG).show();
	            return true;
	        case R.id.wn_info:	        	 
				Main.myDbHelper.delete("wireless_network_info");
				Main.myDbHelper.delete("wireless_network_connect_info");
				Toast.makeText(this, "Datos de conexión eliminados", Toast.LENGTH_LONG).show();
	            return true;
	        case R.id.ac_info:	        	 
	        	Main.myDbHelper.delete("accelerometer_info");
	        	Toast.makeText(this, "Datos del acelerómetro eliminados", Toast.LENGTH_LONG).show();
	            return true;
	        case R.id.poi_info:	        	 
	        	Main.myDbHelper.delete("poi_info");
	        	Toast.makeText(this, "Datos de realidad aumentada eliminados", Toast.LENGTH_LONG).show();
	            return true;	            
	        case R.id.add_poi:
	         	return true;	        	
	        case R.id.del_sites:
	        	//launchARView();
	        	return true;	        	
	        case R.id.start_ar:
	      
	        	//launchARView();
	        	return true;	        	
	        case R.id.preferences:
	        	Intent i = new Intent(this, Preferences.class); 	
    			startActivity(i);
	            return true;
	        case R.id.quit:
	        {
	        	
	        	AlertDialog.Builder builder = new AlertDialog.Builder(this);
	  	        
	  	        builder.setMessage("¿Está seguro de salir?")
	  	               .setCancelable(false)
	  	               .setPositiveButton("Si", new DialogInterface.OnClickListener() {
	  	                   public void onClick(DialogInterface dialog, int id) {
	  	                        CollMotor.this.finish();
	  	                   }
	  	               })
	  	               .setNegativeButton("No", new DialogInterface.OnClickListener() {
	  	                   public void onClick(DialogInterface dialog, int id) {
	  	                        dialog.cancel();
	  	                   }
	  	        });
	  	        	  	        
	  	        alert = builder.create();
	  	        alert.setTitle("Bon Voyage");
	  	        alert.setIcon(R.drawable.color_exit1);
	  	    	alert.show();	  	    	
	        }
	        default:
	            return super.onOptionsItemSelected(item);
	        }
	    }
			
	@Override 
    public void onConfigurationChanged(Configuration newConfig) { 
      //Ignorar cuando la orientación cambia 
      super.onConfigurationChanged(newConfig); 
    } 
	
	//Ejemplo para insertar datos en la bd interna
	public void insertData(){
 		ContentValues values = new ContentValues();
        values.put("x", 1.2);
        values.put("y", 4.2);
        values.put("z", 3.2);
        values.put("date", android.text.format.DateFormat.format("yyyy-MM-dd hh:mm:ss", new java.util.Date()).toString());
        myDbHelper.delete("accelerometer_info");
 		myDbHelper.insert("accelerometer_info", values);
 		
 	    values = new ContentValues();
        values.put("x", 3.2);
        values.put("y", 5.2);
        values.put("z", 12.2);
        values.put("date", android.text.format.DateFormat.format("yyyy-MM-dd hh:mm:ss", new java.util.Date()).toString());
 		myDbHelper.insert("accelerometer_info", values);

	}
	
}
