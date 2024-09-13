This Arduino code sets up an ultrasonic sensor to measure distance and control LEDs and a buzzer based on the measured distance. The setup function initializes serial communication and configures the pins for the ultrasonic sensor, LEDs, and buzzer. In the loop function, the code sends a pulse from the ultrasonic sensor and measures the time it takes for the echo to return, calculating the distance in inches. Depending on the distance, it lights up different LEDs: red for close range (<= 6 inches), yellow for mid-range (6-12 inches), and green for safe range (> 12 inches). The buzzer beeps at a rate proportional to the distance when an object is detected within 12 inches. The measured distance is printed to the serial monitor if it is less than 156 inches.
#define trigPin 8
#define echoPin 7
#define Rled 2
#define Yled 3
#define Gled 4
#define buzzer 10

void setup() {
Serial.begin(9600); 
Serial.println("CEIS101 Course Project Module 5");
Serial.println("Name: charles "); //replace xxxxx with your name

pinMode(trigPin, OUTPUT);
pinMode(echoPin, INPUT);
pinMode(Rled, OUTPUT);
pinMode(Yled, OUTPUT);
pinMode(Gled, OUTPUT);
pinMode(buzzer, OUTPUT);
}

void loop() {
long duration, distance, inches;

digitalWrite(trigPin, LOW);
delayMicroseconds(2);
digitalWrite(trigPin, HIGH);
delayMicroseconds(10);
digitalWrite(trigPin, LOW);

// Read the echo signal
duration = pulseIn(echoPin, HIGH); // Read duration for roundtrip distance
distance = (duration /2) * 0.0135 ; // Convert duration to one way distance in units of inches

if (distance <= 12) {  // Outer IF statement units of inches
  if (distance <=6){   // Alert range condition
    digitalWrite(Rled, HIGH); // Alert green LED on
    digitalWrite(Yled, LOW);
    digitalWrite(Gled, LOW);
    } 
  if (distance <12 and distance > 6){  // Warning range condition
  digitalWrite(Rled, LOW);
  digitalWrite(Yled, HIGH);  // Warning yellow LED on
  digitalWrite(Gled, LOW);
  }  

//==================== Beeping Rate Code Start ======
digitalWrite(buzzer,HIGH);
for (int i= distance; i>0; i--)
delay(10);

digitalWrite(buzzer,LOW);
for (int i= distance; i>0; i--)
delay(10);
//==================== Beeping Rate Code End =======
}
 else{ //Safe range condition 
  digitalWrite(Rled, LOW);
  digitalWrite(Yled, LOW);
  digitalWrite(Gled, HIGH);  // Safe distance green LED on
  digitalWrite(buzzer, LOW);
}// end of outer IF statement

if (distance < 156) // Filter noise to show readings only less than the sensor range of 13 ft = 156 inches 
  Serial.println(distance); // print distance to show in Serial Monitor

delay(100); //pause program to stabilize ultrasonic sensor readings

} //end of loop
