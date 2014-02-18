package PCControlApp;


/**
* PCControlApp/PCControlPOA.java .
* Generated by the IDL-to-Java compiler (portable), version "3.2"
* from PCControl.idl
* martes 11 de febrero de 2014 11:34:31 AM CST
*/

public abstract class PCControlPOA extends org.omg.PortableServer.Servant
 implements PCControlApp.PCControlOperations, org.omg.CORBA.portable.InvokeHandler
{

  // Constructors

  private static java.util.Hashtable _methods = new java.util.Hashtable ();
  static
  {
    _methods.put ("getPcs", new java.lang.Integer (0));
    _methods.put ("registrar", new java.lang.Integer (1));
  }

  public org.omg.CORBA.portable.OutputStream _invoke (String $method,
                                org.omg.CORBA.portable.InputStream in,
                                org.omg.CORBA.portable.ResponseHandler $rh)
  {
    org.omg.CORBA.portable.OutputStream out = null;
    java.lang.Integer __method = (java.lang.Integer)_methods.get ($method);
    if (__method == null)
      throw new org.omg.CORBA.BAD_OPERATION (0, org.omg.CORBA.CompletionStatus.COMPLETED_MAYBE);

    switch (__method.intValue ())
    {
       case 0:  // PCControlApp/PCControl/getPcs
       {
         PCControlApp.PCControlPackage.Pc $result[] = null;
         $result = this.getPcs ();
         out = $rh.createReply();
         PCControlApp.PCControlPackage.PcsHelper.write (out, $result);
         break;
       }

       case 1:  // PCControlApp/PCControl/registrar
       {
         PCControlApp.PCControlPackage.Pc pc = PCControlApp.PCControlPackage.PcHelper.read (in);
         boolean $result = false;
         $result = this.registrar (pc);
         out = $rh.createReply();
         out.write_boolean ($result);
         break;
       }

       default:
         throw new org.omg.CORBA.BAD_OPERATION (0, org.omg.CORBA.CompletionStatus.COMPLETED_MAYBE);
    }

    return out;
  } // _invoke

  // Type-specific CORBA::Object operations
  private static String[] __ids = {
    "IDL:PCControlApp/PCControl:1.0"};

  public String[] _all_interfaces (org.omg.PortableServer.POA poa, byte[] objectId)
  {
    return (String[])__ids.clone ();
  }

  public PCControl _this() 
  {
    return PCControlHelper.narrow(
    super._this_object());
  }

  public PCControl _this(org.omg.CORBA.ORB orb) 
  {
    return PCControlHelper.narrow(
    super._this_object(orb));
  }


} // class PCControlPOA
