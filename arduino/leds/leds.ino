
#include <FastLED.h>

//defining led parametersyyyyyyu
//number of leds in strings
#define NUM_LEDS 20
//defining pins ledstrips
#define DATA_PIN 5
//#define DATA_PIN2 10
//defining pin start button
//#define buttonPin 12

//set leds
CRGB leds[NUM_LEDS];
//CRGB leds2[NUM_LEDS];

//set bools to track if button was pressed (make sure you can't keep pushing button and printing character)
//start button*/
//bool pressedStart = false;

//array to keep led states in
int ledsOn[10];
//start millis to time leds later
long startMillis[10];

void setup() {
  Serial.begin(115200);  // start serial to get input

  //add leds to fastleds with number of leds and datapinsaaaaaaaaaqqyyyyqqqwwwwwwwwwwwwwwww
  FastLED.addLeds<NEOPIXEL, DATA_PIN>(leds, NUM_LEDS);
  //FastLED.addLeds<NEOPIXEL, DATA_PIN2>(leds2, NUM_LEDS);
  //set pinmode of start button
  //pinMode(buttonPin, INPUT_PULLUP);

  //turn off all leds to start of empty
  //FastLED.clear(); 
  //FastLED.show(); 
}

void loop() {
  
//check if serial is available
if(Serial.available())
  {
     char char1;
     char char2;
    //Serial.println(msg);
    while (Serial.available() > 0)
    {
      delay(10);
      //Serial.println("in while");
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

//clear all leds at beginning yyyyloop to start with clean slate uuuuuououopuppuuuuqwertyuiop
//for (int i=0; i<sizeof ledsOn/sizeof ledsOn[0]; i++) {
 // leds[i] = CRGB::Black;
 // leds2[i] = CRGB::Black;
//}

  //run over led array to see which led needs which color
  for (int i=0; i<sizeof ledsOn/sizeof ledsOn[0]; i++) {
    if(ledsOn[i] == 1){
      //if ledsOn on place i is 1, turn that led to white
       leds[i] = CRGB( 255, 255, 255);
       leds[i+10] = CRGB( 255, 255, 255);
       
    }else if (ledsOn[i] == 2){
      //if ledsOn on place i is 1, turn led to green (player 1 scored)
      leds[i] = CRGB( 0, 255, 0);
      leds[i+10] = CRGB( 0, 255, 0);
      //set start value of millis if it's 0
      if(startMillis[i] == 0){
        startMillis[i] = millis();
      }
    }else if (ledsOn[i] == 3){
      //if ledsOn on place i is 1, turn led to green (player 2 scored)
      leds[i] = CRGB( 255, 0,0);
      leds[i+10] = CRGB( 255, 0,0);
      
      //set start value of millis if it's 0
      if(startMillis[i] == 0){
        startMillis[i] = millis();
      }
    }
      //show led changes
      FastLED.show();
      FastLED.clear();
  }
      
  //run over millis array
  for (int i=0; i<sizeof startMillis/sizeof startMillis[0]; i++) {
    //Serial.println("millis checken");
    //if any are over 0.3 seconds: turn led in that place off and reset start millis
    if(millis() - startMillis[i] >= 300 && startMillis[i]>0){
      //Serial.println("millis zijn groter dan wat ze moeten zijn");
      ledsOn[i] = 0;
      startMillis[i] = 0;
    }
  }
  //delay(10);ooooo


}
