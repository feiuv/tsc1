package com.collmotoracdemo;

import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteException;
import android.database.sqlite.SQLiteOpenHelper;

public class DataBaseHelper extends SQLiteOpenHelper{    
     private static String DB_PATH = "/data/data/com.collmotoracdemo/databases/"; 
     private static String DB_NAME = "dbcollmotor";
     private SQLiteDatabase myDataBase; 
     private final Context myContext;
    static boolean OPENED = false;
 
    /**
     * Constructor
     * Takes and keeps a reference of the passed context in order to access to the application assets and resources.
     * @param context
     */
    public DataBaseHelper(Context context) {
    	super(context, DB_NAME, null, 1);
        this.myContext = context;
    }	
 
    /**
     * Creates a empty database on the system and rewrites it with your own database.
     * */
    public void createDataBase() throws IOException{
 
    	boolean dbExist = checkDataBase();
 
    	if(!dbExist){
    		this.getReadableDatabase();
 
        	try {
 
    			copyDataBase();
 
    		} catch (IOException e) {
 
        		throw new Error("Error copying database");
 
        	}
    	}
 
    }
 
    /**
     * Check if the database already exist to avoid re-copying the file each time you open the application.
     * @return true if it exists, false if it doesn't
     */
    private boolean checkDataBase(){
 
    	SQLiteDatabase checkDB = null;
 
    	try{
    		String myPath = DB_PATH + DB_NAME;
    		checkDB = SQLiteDatabase.openDatabase(myPath, null, SQLiteDatabase.OPEN_READONLY);
 
    	}catch(SQLiteException e){
 
    		//database does't exist yet.
 
    	}
 
    	if(checkDB != null){
 
    		checkDB.close();
 
    	}
 
    	return checkDB != null ? true : false;
    }
 
    /**
     * Copies your database from your local assets-folder to the just created empty database in the
     * system folder, from where it can be accessed and handled.
     * This is done by transfering bytestream.
     * */
    private void copyDataBase() throws IOException{
 
    	//Open your local db as the input stream
    	InputStream myInput = myContext.getAssets().open(DB_NAME);
 
    	// Path to the just created empty db
    	String outFileName = DB_PATH + DB_NAME;
 
    	//Open the empty db as the output stream
    	OutputStream myOutput = new FileOutputStream(outFileName);
 
    	//transfer bytes from the inputfile to the outputfile
    	byte[] buffer = new byte[1024];
    	int length;
    	while ((length = myInput.read(buffer))>0){
    		myOutput.write(buffer, 0, length);
    	}
 
    	//Close the streams
    	myOutput.flush();
    	myOutput.close();
    	myInput.close();
 
    }
 
    public void openDataBase() throws SQLException{
 
    	//Open the database
    	OPENED = true;
        String myPath = DB_PATH + DB_NAME;
    	myDataBase = SQLiteDatabase.openDatabase(myPath, null, SQLiteDatabase.OPEN_READWRITE);
 
    }
    
    private boolean isOpened(){
    	if (OPENED)
    		return true;
    	return false;
    }
 
    @Override
	public synchronized void close() {
    	try{
    	    if(myDataBase != null)
    		    myDataBase.close();
 
    	    super.close();
    	}catch(Exception e){
    		
    	}
 
    	
	}
 
    public boolean deleteWhere(String table,int _id){    		
    	String where = "_id =  " + _id;    	
    	return  ((myDataBase.delete(table, where, null)) > 0 )? true: false;
    	
    }
    
    public boolean updateWhere(String table, int id,  ContentValues values){
    	String where = " _id = " + id;
    	return  ((myDataBase.update(table, values, where, null) > 0))? true: false;
    }
    
    public void delete(String tableName){
    	myDataBase.delete(tableName, "", null);
    }
    public boolean insert(String tableName, ContentValues values){
    	boolean result = false;
    	try{
    		 result = true;
    	}catch(SQLException e){
    		 throw e;
    	} 
    	return result;
    }
 
    public Cursor selectPoi(){
    	Cursor cursor = null;
    	try{
    	
    	if (!isOpened())
    		openDataBase();
    	
    	cursor = myDataBase.query("poi_info", null, null, null, null,
    				null, null);   
    	
    	}catch(Exception e){}
    	return cursor;
    }
	@Override
	public void onCreate(SQLiteDatabase db) {
 
	}
 
	@Override
	public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {
 
	}
}