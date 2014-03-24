package com.collmotoracdemo;

import org.ksoap2.*;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;
public class AccelerometerWebService extends WebServiceBase{
	
	public AccelerometerWebService(String ip){
		URL = "http://" + ip +  URL;   	 	
		METHOD_NAME = "InsertAccelerometerInfo";
		SOAP_ACTION = NAMESPACE + METHOD_NAME;
	}
	
	public boolean AccelerometerInfo(int idActor, int idDevice, float x, float y, float z) throws Exception {		
		boolean r = false;
		String result = "false";
		SoapObject request = new SoapObject(NAMESPACE, METHOD_NAME);     
		request.addProperty("idActor", String.valueOf(idActor));
		request.addProperty("idDevice", String.valueOf(idDevice));
		request.addProperty("x", String.valueOf(x));
		request.addProperty("y", String.valueOf(y));
		request.addProperty("z", String.valueOf(z));
		
	    final SoapSerializationEnvelope envelope =
		new SoapSerializationEnvelope(SoapEnvelope.VER11);
		envelope.dotNet = true;
		envelope.setOutputSoapObject(request);
		HttpTransportSE androidHttpTransport = new HttpTransportSE(URL);
	
		try
		{
			androidHttpTransport.call(SOAP_ACTION, envelope);
			result = ((SoapPrimitive)envelope.getResponse()).toString();
			
		}catch(Exception e) 
		{
			throw e;
		}
		
		r = result.equals("true")?true:false;
		return r;
	
	}
}
