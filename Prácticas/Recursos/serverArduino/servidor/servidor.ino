
#include <SPI.h>
#include <Ethernet.h>

// Enter a MAC address and IP address for your controller below.
// The IP address will be dependent on your local network:
int led1 = 3;
int led2 = 4;
int led3 = 5;
int led4 = 6;
int led5 = 7;
int led6 = 8;
int led7 = 9;

byte mac[] = {0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED };
IPAddress ip(192,168,1,177);
EthernetServer server(80);

boolean onled1 = false;
boolean onled2 = false;
boolean onled3 = false;
boolean onled4 = false;
boolean onled5 = false;
boolean onled6 = false;
boolean onled7 = false;

boolean bled1 = false;
boolean bled2 = false;
boolean bled3 = false;
boolean bled4 = false;
boolean bled5 = false;
boolean bled6 = false;
boolean bled7 = false;

void onLeds(){
   if (onled1){
      if (!bled1)
      {
         digitalWrite(led1, HIGH);
         bled1 = true; 
      }
      else{ 
         digitalWrite(led1, LOW);
         bled1 = false;
      }
      onled1 = false;
   }else if (onled2){
      if (!bled2)
      {
         digitalWrite(led2, HIGH);
         bled2 = true; 
      }
      else{ 
         digitalWrite(led2, LOW);
         bled2 = false;
      }
      onled2 = false;
   }else if (onled3){
      if (!bled3)
      {
         digitalWrite(led3, HIGH);
         bled3 = true; 
      }
      else{ 
         digitalWrite(led3, LOW);
         bled3 = false;
      }
      onled3 = false;
   }else if (onled4){
      if (!bled4)
      {
         digitalWrite(led4, HIGH);
         bled4 = true; 
      }
      else{ 
         digitalWrite(led4, LOW);
         bled4 = false;
      }
      onled4 = false;
   }else if (onled5){
      if (!bled5)
      {
         digitalWrite(led5, HIGH);
         bled5 = true; 
      }
      else{ 
         digitalWrite(led5, LOW);
         bled5 = false;
      }
      onled5 = false;
   }else if (onled6){
      if (!bled6)
      {
         digitalWrite(led6, HIGH);
         bled6 = true; 
      }
      else{ 
         digitalWrite(led6, LOW);
         bled6 = false;
      }
      onled6 = false;
   }else if (onled7){
      if (!bled7)
      {
         digitalWrite(led7, HIGH);
         bled7 = true; 
      }
      else{ 
         digitalWrite(led7, LOW);
         bled7 = false;
      }
      onled7 = false;
   }
}

void setLeds(char c){
   switch(c){
      case '1':
        onled1 = true;
        break;
      case '2':
        onled2 = true;
        break;
      case '3':
        onled3 = true;
        break;
      case '4':
        onled4 = true;
        break;
      case '5':
        onled5 = true;
        break;
      case '6':
        onled6 = true;
        break;
      case '7':
        onled7 = true;
        break;
   }
}


void setup() {
  pinMode(led1, OUTPUT);     
  pinMode(led2, OUTPUT);     
  pinMode(led3, OUTPUT);     
  pinMode(led4, OUTPUT);    
  pinMode(led5, OUTPUT);    
  pinMode(led6, OUTPUT);    
  pinMode(led7, OUTPUT);    
  Serial.begin(9600);
  while (!Serial) {;}
  Ethernet.begin(mac, ip);
  server.begin();
  Serial.print("server is at ");
  Serial.println(Ethernet.localIP());
}

void loop() {
  // listen for incoming clients
  EthernetClient client = server.available();
  if (client) {
    Serial.println("new client");
    // an http request ends with a blank line
    boolean currentLineIsBlank = true;
    while (client.connected()) {
      if (client.available()) {
        char c = client.read();
        Serial.write(c);
        setLeds(c);    
        if (c == '\n' && currentLineIsBlank){
          onLeds();
          client.println();
          break;
        }
        if (c == '\n') {
          // you're starting a new line
          currentLineIsBlank = true;
        } 
        else if (c != '\r') {
          // you've gotten a character on the current line
          currentLineIsBlank = false;
        }
      }
    }
    // give the web browser time to receive the data
    delay(1);
    // close the connection:
    client.stop();
    Serial.println("client disonnected");
  }
}
