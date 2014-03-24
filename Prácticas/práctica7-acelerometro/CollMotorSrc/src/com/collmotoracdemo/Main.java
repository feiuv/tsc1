package com.collmotoracdemo;
import java.io.IOException;
import java.util.List;
import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.app.Service;
import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.hardware.Sensor;
import android.hardware.SensorEvent;
import android.hardware.SensorEventListener;
import android.hardware.SensorManager;
import android.os.IBinder;
import android.preference.PreferenceManager;
import android.util.Log;
import android.util.LogPrinter;
import android.widget.Toast;

public class Main extends Service {
	static String ADDRESS_NAME = "Desconocida";
	static SharedPreferences prefs;
	static DataBaseHelper myDbHelper;
	static Context context;
    private static Main service; 
	static CollMotor collmotor = null;
	private static final String TAG = "CollmotorService";
	public static String ip = "10.116.94.217";
	private static final int COLLMOTOR_ID = 1;
	static SensorManager mSensorManager1;
	//static BroadcastReceiver receiver;
	Toast t;
	static SensorView mVista; 
	static boolean STARTED = false;
	static boolean STOPED = false;
	

	public static Main getInstance(){
		return service;
	}
	@Override
	public IBinder onBind(Intent intent) {
		return null;
	}

	public static void setCollMotor(CollMotor cm) {
		collmotor = cm;
	}

	@Override
	public void onCreate() {
		Log.d(TAG, "onCreate");		
		prefs = PreferenceManager.getDefaultSharedPreferences(this);
		
		showMessage("Creating service!!");
		t = new Toast(this);
		mVista = new SensorView();
		
		settingSensors();
		settingDatabase();
		createNotificationOutgoing();
		service = this;		
	}
	
	public void createNotificationOutgoing(){
		String ns = Context.NOTIFICATION_SERVICE;
		NotificationManager mNotificationManager = (NotificationManager) getSystemService(ns);
		int icon = R.drawable.activity_monitor;
		CharSequence tickerText = "Monitor contextual";
		long when = System.currentTimeMillis();
		Notification notification = new Notification(icon, tickerText, when);
		CharSequence contentTitle = "Sensor Activity Recognition";
		CharSequence contentText = "Recognizing Activities by accelerometer";
		Intent notificationIntent = new Intent(this, CollMotor.class);
		PendingIntent contentIntent = PendingIntent.getActivity(this, 0, notificationIntent, 0);
		notification.setLatestEventInfo(this, contentTitle, contentText, contentIntent);
		mNotificationManager.notify(COLLMOTOR_ID, notification);
	}
	
	public void showMessage(String text){
		Toast.makeText(this, text, Toast.LENGTH_LONG).show();
	}
	@Override
	public void onDestroy() {
		Toast.makeText(this, "Stopping...", Toast.LENGTH_LONG).show();
		STOPED = true;
		Log.d(TAG, "onDestroy");
		
		try{
			Main.myDbHelper.close();
		}catch(Exception e){	
		}
	}
	

	@Override
	public void onStart(Intent intent, int startid) {
		Log.d(TAG, "onStart");
		if (!STARTED){
			STARTED = true;
			showMessage( "Starting Activity Recognition....");				
		}			
	}

	public void settingDatabase(){
		try{
			myDbHelper = new DataBaseHelper(this);
			try {
				myDbHelper.createDataBase();
				try {
					myDbHelper.openDataBase();					
				} catch (Exception sqle) {
				}
			} catch (IOException ioe){
			}				
		}catch(Exception e){	
		}
	}

	
	public void settingSensors() {
		SensorManager mSensorManager = (SensorManager) getSystemService(SENSOR_SERVICE);
		List<Sensor> listSensors = mSensorManager.getSensorList(Sensor.TYPE_ACCELEROMETER);
		Sensor acelerometerSensor = listSensors.get(0);
		mSensorManager.registerListener(mVista, acelerometerSensor, SensorManager.SENSOR_DELAY_UI);
		mSensorManager1 = (SensorManager) getSystemService(SENSOR_SERVICE);
	}
}

class SensorView implements SensorEventListener {

	public SensorView() {
		super();
		tiempo_inicial = System.currentTimeMillis();
		
	}

	private float mAccelerometerValues[] = new float[3];
	public static long tiempo_inicial;
	public static long tiempo_final;
	
	
	// En este ejemplo no necesitamos enterarnos de las variaciones de precisión del sensor
	@Override
	public void onAccuracyChanged(Sensor sensor, int accuracy) {
		
	}

	
	//Algoritmo inicial  
	public String physicalActivityRecognition(double x[], double y[], double z[]){
		String result = "Nothing...";
		//TODO: Realizar análisis de los datos x, y, z...
		return result;
	}
	
	
	
	
	@Override
	public void onSensorChanged(SensorEvent event) {
		// Cada sensor puede provocar que un thread pase por aquí, así que
		// hay que sincronizar el acceso 
		
		synchronized (this) {
			switch (event.sensor.getType()) {
			case Sensor.TYPE_ACCELEROMETER:	
				//La lectora del acelerómetro debe llenar la tabla de lecturas
				//La ventana podría ser de 200 lecturas aprox., los valores son colocados en una matriz de 200 filas (lecturas) 3 columnas (x,y,z).
			
				for (int i = 0; i < mAccelerometerValues.length; i++) 
					mAccelerometerValues[i] = event.values[i];
				
				CollMotor.accelerometerX[CollMotor.row] = mAccelerometerValues[0];
				CollMotor.accelerometerY[CollMotor.row] = mAccelerometerValues[1];
				CollMotor.accelerometerZ[CollMotor.row] = mAccelerometerValues[2];				
				CollMotor.row++;
				
				tiempo_final = System.currentTimeMillis();
				long diff = tiempo_final - tiempo_inicial;
				
				if (diff > 12000){
					android.util.Log.d("Collmotor", "Ventana (12 segs.)... " + CollMotor.row);
					CollMotor.row = 0;
					tiempo_inicial = System.currentTimeMillis();
					//Llamar método que interpreta la actividad, aproximadamente con 180 lecturas del acelerómetro
					String activity = physicalActivityRecognition(CollMotor.accelerometerX, CollMotor.accelerometerY, CollMotor.accelerometerZ);
					Main.collmotor.txtActividad.setText(activity);
				}
				break;
			
			default:
				
			}
		}
	}
}

class ProxyDataAxis extends Thread {
	private int idActor, idDevice;
	private float x, y, z;

	public ProxyDataAxis(int idActor, int idDevice, float x, float y, float z) {
		this.idActor = idActor;
		this.idDevice = idDevice;
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public void run() {
		try {
			AccelerometerWebService testWS = new AccelerometerWebService(Main.ip);
			testWS.AccelerometerInfo(idActor, idDevice, x, y, z);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
}
