#include <stdlib.h>

#include "dht.h"
#define dht_apin A5 // Analog Pin sensor is connected to

dht DHT; // DHT sensor, temperature and humidity sensor

const int DHT_reading_interval = 3000;

// Output pins
const int pin_A = 2;
const int pin_B = 3;  // ~
const int pin_C = 4; 
const int pin_D = 5;  // ~ 
const int pin_E = 6;  // ~
const int pin_F = 7;
const int pin_G = 8;
const int pin_H = 9;  // ~
const int pin_I = 10;  // ~
const int pin_J = 11; // ~
const int pin_K = 12;
const int pin_L = 13;

// Receiving data
String inputString = "";
String inputValueString = "";
bool stringComplete = false;

// Sending data
unsigned int DHT_time = 0;
float temperature_read = 0.0;
float humidity_read = 0.0;

bool is_connected = false;

void setup() {
  Serial.begin(9600);
  pinMode(pin_A, OUTPUT);
  pinMode(pin_B, OUTPUT);
  pinMode(pin_C, OUTPUT);
  pinMode(pin_D, OUTPUT);
  pinMode(pin_E, OUTPUT);
  pinMode(pin_F, OUTPUT);
  pinMode(pin_G, OUTPUT);
  pinMode(pin_H, OUTPUT);
  pinMode(pin_I, OUTPUT);
  pinMode(pin_J, OUTPUT);
  pinMode(pin_K, OUTPUT);
  pinMode(pin_L, OUTPUT);
  delay(1500); // let the system boot before accessing sensor
}

void send_DHT_data()
{
  if (DHT_time >= DHT_reading_interval)
  {
    DHT.read11(dht_apin);
    temperature_read = DHT.temperature;
    humidity_read = DHT.humidity;
    
    Serial.print((String)temperature_read + " " + (String)humidity_read);
    
    DHT_time = 0;
  }
}

void loop() {
  // Sending sensor data if arduino is connected
  if (is_connected)
  {    
    send_DHT_data();
    delay(1);
    DHT_time++;
  }
}


void serialEvent() {
  while (Serial.available()) {
    // get the new byte
    char inChar = (char)Serial.read();
    // if it's a newline char, string is complete
    if (inChar == '\n') {
      stringComplete = true;
    }
    else if (isalpha(inChar))
    {
      inputString += inChar; 
    }
    else if (isdigit(inChar))
    {
      inputValueString += inChar;
    }
  }

  // Receiving data
  if (stringComplete)
  {
    const char* inValConsStr = inputValueString.c_str();
    int inputValue = atoi(inValConsStr);

    // handshake
    if (inputString == "h")
    {
      Serial.print("ARDUINO"); // respond to handshake and connect
      is_connected = true;
      delay(1000);
    }

    // ANALOG
    if (inputString == "analogB")
    {
      analogWrite(pin_B, inputValue);
    }
    else if (inputString == "analogD")
    {
      analogWrite(pin_D, inputValue);
    }
    else if (inputString == "analogE")
    {
      analogWrite(pin_E, inputValue);
    }
    else if (inputString == "analogH")
    {
      analogWrite(pin_H, inputValue);
    }
    else if (inputString == "analogI")
    {
      analogWrite(pin_I, inputValue);
    }
    else if (inputString == "analogJ")
    {
      analogWrite(pin_J, inputValue);
    }
    
    // DIGITAL
    else if (inputString == "digitalA")
    {
       digitalWrite(pin_A, inputValue);
    }
    else if (inputString == "digitalB")
    {
       digitalWrite(pin_B, inputValue);
    }
    else if (inputString == "digitalC")
    {
       digitalWrite(pin_C, inputValue);
    }
    else if (inputString == "digitalD")
    {
       digitalWrite(pin_D, inputValue);
    }
    else if (inputString == "digitalE")
    {
       digitalWrite(pin_E, inputValue);
    }
    else if (inputString == "digitalF")
    {
       digitalWrite(pin_F, inputValue);
    }
    else if (inputString == "digitalG")
    {
       digitalWrite(pin_G, inputValue);
    }
    else if (inputString == "digitalH")
    {
       digitalWrite(pin_H, inputValue);
    }
    else if (inputString == "digitalI")
    {
       digitalWrite(pin_I, inputValue);
    }
    else if (inputString == "digitalJ")
    {
       digitalWrite(pin_J, inputValue);
    }
    else if (inputString == "digitalK")
    {
      digitalWrite(pin_K, inputValue);
    }
    else if (inputString == "digitalL")
    {
      digitalWrite(pin_L, inputValue);
    }

    // prepare for new command
    inputString = "";
    inputValueString = "";
    stringComplete = false;
  }
}
