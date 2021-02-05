// Wire Master Reader
// by Nicholas Zambetti <http://www.zambetti.com>

// Demonstrates use of the Wire library
// Reads data from an I2C/TWI slave device
// Refer to the "Wire Slave Sender" example for use with this

// Created 29 March 2006wwwwj

// This example code is in the public domain.   weqqqqasdfghjkl,qqqtriuypotewqqweewtrqiuyopiewqqqqrqqqqqw

#include <Wire.h>
#include "Keyboard.h"
#include <FastLED.h>

//defining led parameters
//number of leds in strings
#define NUM_LEDS 10
//defining pins ledstrips
#define DATA_PIN 5
#define DATA_PIN2 10
//defining pin start buttonhewq
#define buttonPin 12

//set leds
CRGB leds[NUM_LEDS];
CRGB leds2[NUM_LEDS];

//set bools to track if button was pressed (make sure you can't keep pushing button and printing character)
//player1
bool pressed = false;
bool pressed2 = false;
bool pressed3 = false;
bool pressed4 = false;
bool pressed5 = false;
bool pressed6 = false;
bool pressed7 = false;
bool pressed8 = false;
bool pressed9 = false;
bool pressed10 = false;
//player2
bool pressed11 = false;
bool pressed12 = false;
bool pressed13 = false;
bool pressed14 = false;
bool pressed15 = false;
bool pressed16 = false;
bool pressed17 = false;
bool pressed18 = false;
bool pressed19 = false;
bool pressed20 = false;
//start button
bool pressedStart = false;

//array to keep led states in
int ledsOn[10];
//start millis to time leds later
long startMillis[10];

//set button state  opiuyyyyytrqwelhjk,gsfad
int buttonState = 0;

void setup() {
  //start up wire
  Wire.begin();        // join i2c bus (address optional for master)
  Serial.begin(115200);  // start serial to get input

  //start up keyboard simulation hfasgdiitryupoweqqeeeewwt
  Keyboard.begin();

  //add leds to fastleds with number of leds and datapins
  FastLED.addLeds<NEOPIXEL, DATA_PIN>(leds, NUM_LEDS);
  FastLED.addLeds<NEOPIXEL, DATA_PIN2>(leds2, NUM_LEDS);
  //set pinmode of start button
  pinMode(buttonPin, INPUT_PULLUP);

  //turn off all leds to start of empty
  FastLED.clear(); 
  FastLED.show(); 
}

void loop() {
  //start button 
  //read state of button  
  buttonState = digitalRead(buttonPin);
  //if button state is high, and the button isn't pressed yet press right key on keyboard
  if (buttonState == HIGH && pressedStart == false) {
    Keyboard.press(32); 
    delay(10);
    Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
    pressedStart = true;
  }
  //if the button is low put pressed back to false because key has been released
  if(buttonState == LOW) {
    pressedStart = false;
    delay(10);
  }
  
//check if serial is available
if(Serial.available())
  {
     char char1;
     char char2;
    //Serial.println(msg);
    while (Serial.available() > 0)
    {
      Serial.println("in while");
      //add characters comming through serial into msg string
     char1 = Serial.read();
     char2 = Serial.read();
     Serial.print("char1: ");
     Serial.println(char1);
     Serial.print("char2: ");
     Serial.println(char2);
    
   
     //read first character of msg, depending on character set certain led in array on or off
     switch (char1)
    {
        case 'X':
            for (int i=0; i<sizeof ledsOn/sizeof ledsOn[0]; i++) {
              ledsOn[i] = 0;
            }
            break;
        case 'A':
            ledsOn[2] = 1;
            break;
        case 'Z':
            ledsOn[1] = 1; 
            break;
        case 'E':
            ledsOn[0] = 1;
            break;
        case 'R':
            ledsOn[3] = 1; 
            break;
        case 'T':
            ledsOn[4] = 1;
            break;
        case 'Y':
            ledsOn[5] = 1; 
            break;
        case 'U':
            ledsOn[6] = 1;
            break;
        case 'I':
            ledsOn[7] = 1; 
            break;
        case 'O':
            ledsOn[8] = 1;
            break;
        case 'P':
            ledsOn[9] = 1; 
            break;
        case 'Q':
            ledsOn[2] = 0;
            break;
        case 'S':
            ledsOn[1] = 0; 
            break;
        case 'D':
            ledsOn[0] = 0;
            break;
        case 'F':
            ledsOn[3] = 0; 
            break;
        case 'G':
            ledsOn[4] = 0;
            break;
        case 'H':
            ledsOn[5] = 0; 
            break;
        case 'J':
            ledsOn[6] = 0;
            break;
        case 'K':
            ledsOn[7] = 0; 
            break;
        case 'L':
            ledsOn[8] = 0; 
            break;
        case 'M':
            ledsOn[9] = 0; 
            break;
        case '0':
            //if character 1 is number, check character 2 to see which player scored a point
            switch (char2) {
              case '1':
                ledsOn[0] = 2;
                break;
              case '2':
                ledsOn[0] = 3;
                break;
            }
            break;
            
        case '1':
            switch (char2) {
              case '1':
                ledsOn[1] = 2;
                break;
              case '2':
                ledsOn[1] = 3;
                break;
            }
            break;
        case '2':
            switch (char2) {
              case '1':
                ledsOn[2] = 2;
                break;
              case '2':
                ledsOn[2] = 3;
                break;
            }
            break;
        case '4':
            switch (char2) {
              case '1':
                ledsOn[3] = 2;
                break;
              case '2':
                ledsOn[3] = 3;
                break;
            }
            break;
        case '3':
            switch (char2) {
              case '1':
                ledsOn[4] = 2;
                break;
              case '2':
                ledsOn[4] = 3;
                break;
            }
            break;
        case '5':
            switch (char2) {
              case '1':
                ledsOn[5] = 2;
                break;
              case '2':
                ledsOn[5] = 3;
                break;
            }
            break;
        case '6':
            switch (char2) {
              case '1':
                ledsOn[6] = 2;
                break;
              case '2':
                ledsOn[6] = 3;
                break;
            }
            break;
        case '7':
            switch (char2) {
              case '1':
                ledsOn[7] = 2;
                break;
              case '2':
                ledsOn[7] = 3;
                break;
            }
            break;
        case '9':
            switch (char2) {
              case '1':
                ledsOn[8] = 2;
                break;
              case '2':
                ledsOn[8] = 3;
                break;
            }
            break;
        case '8':
            switch (char2) {
              case '1':
                ledsOn[9] = 2;
                break;
              case '2':
                ledsOn[9] = 3;
                break;
            }
            break;
        
    }}
  }

//clear all leds at beginning loop to start with clean slate 
FastLED.clear();
  //run over led array to see which led needs which color
  for (int i=0; i<sizeof ledsOn/sizeof ledsOn[0]; i++) {
    if(ledsOn[i] == 1){
      //if ledsOn on place i is 1, turn that led to white
       leds[i] = CRGB( 0, 0, 255);
       leds2[i] = CRGB( 0, 0, 255);
    }else if (ledsOn[i] == 2){
      //if ledsOn on place i is 1, turn led to green (player 1 scored)
      leds[i] = CRGB( 0, 255, 0);
      leds2[i] = CRGB( 0, 255, 0);
      //set start value of millis if it's 0
      if(startMillis[i] == 0){
        startMillis[i] = millis();
      }
    }else if (ledsOn[i] == 3){
      //if ledsOn on place i is 1, turn led to green (player 2 scored)
      leds2[i] = CRGB( 255, 0,0);
      leds[i] = CRGB( 255, 0, 0);
      //set start value of millis if it's 0
      if(startMillis[i] == 0){
        startMillis[i] = millis();
      }
    }
  }

  //run over millis array
  for (int i=0; i<sizeof startMillis/sizeof startMillis[0]; i++) {
    Serial.println("millis checken");
    //if any are over 0.3 seconds: turn led in that place off and reset start millis
    if(millis() - startMillis[i] >= 10 && startMillis[i]>0){
      Serial.println("millis zijn groter dan wat ze moeten zijn");
      ledsOn[i] = 0;
      startMillis[i] = 0;
    }
  }

  //show led changes
  FastLED.show();
  delay(10);


  //PCF8574 number1
  Wire.beginTransmission(0x3A); // transmit to device #8
  Wire.write(255);        // sends five bytes
  Wire.endTransmission();  
  
  Wire.requestFrom(0x3A, 1);    // request 6 bytes from slave device #8

  while (Wire.available()) { // slave may send less than requested
    Serial.println("in while buttons");
    int c = Wire.read(); // receive a byte as character
    //Serial.println(c);         // print the character
    //if c is right character, and the button isn't pressed yet press right key on keyboard
    if(c >0){
    if(c == 1 && pressed == false) {
      Keyboard.press('e');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed = true;
      //if the button is wrong character, put pressed back to false because button has been released
    }else if (c!=1) { 
      pressed = false;
      delay(10);
    }

    if(c == 4 && pressed2 == false) {
      Keyboard.press('z');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed2 = true;
    }else if (c!=4) { 
      pressed2 = false;
      delay(10);
    }
    
     if(c == 8 && pressed3 == false) {
      Keyboard.press('r');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed3 = true;
    }else if (c!=8) { 
      pressed3 = false;
      delay(10);
    }
    
     if(c == 16 && pressed4 == false) {
      Keyboard.press('t');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed4 = true;
    }else if (c!=16) { 
      pressed4 = false;
      delay(10);
    }
    
     if(c == 2 && pressed5 == false) {
      Keyboard.press('a');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed5 = true;
    }else if (c!=2) { 
      pressed5 = false;
      delay(10);
    }
    
     if(c == 32 && pressed6 == false) {
      Keyboard.press('y');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed6 = true;
    }else if (c!=32) { 
      pressed6 = false;
      delay(10);
    }
    
     if(c == 64 && pressed7 == false) {
      Keyboard.press('u');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed7 = true;
    }else if (c!=64) { 
      pressed7 = false;
      delay(10);
    }
    
     if(c == 128 && pressed8 == false) {
      Keyboard.press('i');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed8 = true;
    }else if (c!=128) { 
      pressed8 = false;
      delay(10);
    }
  }}

  //PCF8574 number2
  Wire.beginTransmission(0x39); // transmit to device #8
  Wire.write(255);        // sends five bytes
  Wire.endTransmission();  
  
  Wire.requestFrom(0x39, 1);    // request 6 bytes from slave device #8

  while (Wire.available()) { // slave may send less than requested
    int c = Wire.read(); // receive a byte as character
    //Serial.println(c);         // print the character

    if(c > 0){
     if(c == 251 && pressed9 == false) {
      Keyboard.press('o');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed9 = true;
    }else if (c!=251) { 
      pressed9 = false;
      delay(10);
    }

     if(c == 247 && pressed10 == false) {
      Keyboard.press('p');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed10 = true;
    }else if (c!=247) { 
      pressed10 = false;
      delay(10);
    }}
 

  //PCF8574 number3
  Wire.beginTransmission(0x3B); // transmit to device #8
  Wire.write(255);        // sends five bytes
  Wire.endTransmission();  
  
  Wire.requestFrom(0x3B, 1);    // request 6 bytes from slave device #8

  while (Wire.available()) { // slave may send less than requested
    int c = Wire.read(); // receive a byte as character
    //Serial.println(c);         // print the character
    if(c>0){
     if(c == 251 && pressed11 == false) {
      Keyboard.press('m');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed11 = true;
    }else if (c!=251) { 
      pressed11 = false;
      delay(10);
    }

     if(c == 247 && pressed12 == false) {
      Keyboard.press('l');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed12 = true;
    }else if (c!=247) { 
      pressed12 = false;
      delay(10);
    }}
  }

  //PCF8574 number4
  Wire.beginTransmission(0x3E); // transmit to device #8
  Wire.write(255);        // sends five bytes
  Wire.endTransmission();  
  
  Wire.requestFrom(0x3E, 1);    // request 6 bytes from slave device #8

  while (Wire.available()) { // slave may send less than requested
    int c = Wire.read(); // receive a byte as character
    //Serial.println(c);         // print the character
    if(c>0){
    if(c == 1 && pressed13 == false) {
      Keyboard.press('f');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed13 = true;
    }else if (c!=1) { 
      pressed13 = false;
      delay(10);
    }

    if(c == 4 && pressed14 == false) {
      Keyboard.press('j');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed14 = true;
    }else if (c!=4) { 
      pressed14 = false;
      delay(10);
    }
    
     if(c == 8 && pressed15 == false) {
      Keyboard.press('k');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed15 = true;
    }else if (c!=8) { 
      pressed15 = false;
      delay(10);
    }
    
     if(c == 16 && pressed16 == false) {
      Keyboard.press('q');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed16 = true;
    }else if (c!=16) { 
      pressed16 = false;
      delay(10);
    }
    
     if(c == 2 && pressed17 == false) {
      Keyboard.press('h');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed17 = true;
    }else if (c!=2) { 
      pressed17 = false;
      delay(10);
    }
    
     if(c == 32 && pressed18 == false) {
      Keyboard.press('s');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed18 = true;
    }else if (c!=32) { 
      pressed18 = false;
      delay(10);
    }
    
     if(c == 64 && pressed19 == false) {
      Keyboard.press('d');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed19 = true;
    }else if (c!=64) { 
      pressed19 = false;
      delay(10);
    }
    
     if(c == 128 && pressed20 == false) {
      Keyboard.press('g');
      delay(10);
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed20 = true;
    }else if (c!=128) { 
      pressed20 = false;
      delay(10);
    }

  }}
  }
  delay(10);
}
