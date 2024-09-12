#define Rled 2 
#define Yled 3 
#define Gled 4 
#define buzzer 10 
#define door 9 
#define delaytime 1000 // === Second run, change to 100 
 
void setup() { 
Serial.begin(9600); // Set the baud rate 
Serial.println("CEIS101 Course Project Module 4");
Serial.println("Name: Charles "); //replace xxxxx with your name

pinMode(Rled, OUTPUT); 
pinMode(Yled, OUTPUT); 
pinMode(Gled, OUTPUT); 
pinMode(buzzer, OUTPUT); 
digitalWrite(buzzer, LOW); 
pinMode(door, INPUT_PULLUP);  //door sensor
} 
 
void loop() {   
int value=digitalRead(door); 
if(value == 0) {// Door closed, no security threat
digitalWrite(Rled, LOW); 
digitalWrite(Yled, LOW); 
digitalWrite(Gled, HIGH);  
digitalWrite(buzzer, LOW); 
} 
else{ // Door open, security threat
Serial.println("Door is open. Security Alert! ");
digitalWrite(Rled, HIGH); 
digitalWrite(Yled, HIGH); 
digitalWrite(buzzer, HIGH); 
digitalWrite(Gled, LOW); 
delay(delaytime); 
digitalWrite(Rled, LOW); 
digitalWrite(Yled, LOW); 
digitalWrite(buzzer, LOW); 
delay(delaytime);   
}  // end of else 
} //end of loop   
