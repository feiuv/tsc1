//Cliente CORBA 
//Tópicos Selectos de Computación I
//Luis Gerardo Montané Jiménez


import PCControlApp.*;
import PCControlApp.PCControlPackage.*;
import javax.swing.*;
import java.awt.*;
import java.io.*;
import org.omg.CosNaming.*;
import org.omg.CosNaming.NamingContextPackage.*;
import org.omg.CORBA.*;
import java.awt.event.*;

public class ClientTest extends JFrame
{
  static PCControl pcControlImpl;
  private JTextField  txtIP = new JTextField(10);
  private JTextField  txtResultado = new JTextField(10);
  private JButton btn = new JButton("Enviar características");

  public ClientTest(){	
	super();
	setTitle("Prueba de un cliente CORBA");
	setSize(500,100);
	setDefaultCloseOperation(EXIT_ON_CLOSE);
	setLayout(new FlowLayout());

	JPanel pnl = new JPanel();
	add(pnl);

	pnl.add(new JLabel("IP"));
	txtIP.setText("127.0.0.1");
	pnl.add(txtIP);

	
	btn.addActionListener(new ActionListener(){
		public void actionPerformed(ActionEvent e){
			invocarComponente();
			for (Pc pc1 : pcControlImpl.getPcs()){
				if (pc1 != null){
					System.out.println("**** PC ***");	
					System.out.println("Hostname: " + pc1.hostname);
					System.out.println("S.O.: " + pc1.sonombre);
					System.out.println("IP: " + pc1.ip);
					System.out.println("RAM: " + pc1.ram);	
					System.out.println("Disco Duro: " + pc1.disco);	
					System.out.println("Dirmac: " + pc1.dirmac);	
				}
			}
		}
	});
	pnl.add(btn);
	addWindowListener(new WindowAdapter(){
		public void windowClosing(WindowEvent e){
			System.exit(0);
		}
	});
  }

  public void invocarComponente(){
      try{
        // crear e inicializar el ORB
	ClientTest.args[3] = txtIP.getText();
	ORB orb = ORB.init(ClientTest.args, null);

        // obtener la raiz del nombre del contexto
        org.omg.CORBA.Object objRef = 
	orb.resolve_initial_references("NameService");
        // Usar NamingContextExt para instanciar NamingContext. Esto es parte de la interoperabilidad del servicio de nombres.
        NamingContextExt ncRef = NamingContextExtHelper.narrow(objRef);
		
        // resolver la referencia del objeto con el nombre
        String name = "PCControl";
        pcControlImpl = PCControlHelper.narrow(ncRef.resolve_str(name));
      }catch (Exception e) {
         System.out.println("ERROR : " + e) ;
	 e.printStackTrace(System.out);
      }
  }

  static String args[];
  public static void main(String args[])
    {
	ClientTest.args = args;
	ClientTest c =  new ClientTest();

	c.setVisible(true);	
        
    }

}

