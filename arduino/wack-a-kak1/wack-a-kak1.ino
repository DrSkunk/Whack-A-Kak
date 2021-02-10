
//sketch uploaded to arduino of player one
//include all the libraries
#include <Wire.h>
#include "Keyboard.h"
#include <FastLED.h>

//defining led parameters
//number of leds in strings
#define NUM_LEDS 10
//defining pins ledstrips
#define DATA_PIN 10
//defining pin start button
#define buttonPin 12

//set leds
CRGB leds[NUM_LEDS];

//set bools to track if button was pressed (make sure you can't keep pushing button and printing character)
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
//start button
bool pressedStart = false;

//array to keep led states in
int ledsOn[10];
//start millis to time leds later
long startMillis[10];

//set button state
int buttonState = 0;

void setup()
{
  //start up wire
  Wire.begin();         // join i2c bus (address optional for master)
  Serial.begin(115200); // start serial to get input

  //start up keyboard simulation
  Keyboard.begin();

  //add leds to fastleds with number of leds and datapins
  FastLED.addLeds<NEOPIXEL, DATA_PIN>(leds, NUM_LEDS);
  //set pinmode of start button
  pinMode(buttonPin, INPUT_PULLUP);

  //turn off all leds to start of empty
  FastLED.clear();
  FastLED.show();
}

void loop()
{
  //start button
  //read state of button
  buttonState = digitalRead(buttonPin);
  //if button state is high, and the button isn't pressed yet press right key on keyboard
  if (buttonState == HIGH && pressedStart == false)
  {
    Keyboard.press(32);
    Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
    pressedStart = true;
  }
  //if the button is low put pressed back to false because key has been released
  if (buttonState == LOW)
  {
    pressedStart = false;
  }

  //check if serial is available
  if (Serial.available())
  {
    char char1;
    char char2;

    while (Serial.available() > 0)
    {
      //read both characters coming through serial
      char1 = Serial.read();
      char2 = Serial.read();

      //depending on character set certain led in array on or off in ledOn array
      switch (char1)
      {
      case 'X':
        for (int i = 0; i < sizeof ledsOn / sizeof ledsOn[0]; i++)
        {
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
        switch (char2)
        {
        case '1':
          ledsOn[0] = 2;
          break;
        case '2':
          ledsOn[0] = 3;
          break;
        }
        break;

      case '1':
        switch (char2)
        {
        case '1':
          ledsOn[1] = 2;
          break;
        case '2':
          ledsOn[1] = 3;
          break;
        }
        break;
      case '2':
        switch (char2)
        {
        case '1':
          ledsOn[2] = 2;
          break;
        case '2':
          ledsOn[2] = 3;
          break;
        }
        break;
      case '4':
        switch (char2)
        {
        case '1':
          ledsOn[3] = 2;
          break;
        case '2':
          ledsOn[3] = 3;
          break;
        }
        break;
      case '3':
        switch (char2)
        {
        case '1':
          ledsOn[4] = 2;
          break;
        case '2':
          ledsOn[4] = 3;
          break;
        }
        break;
      case '5':
        switch (char2)
        {
        case '1':
          ledsOn[5] = 2;
          break;
        case '2':
          ledsOn[5] = 3;
          break;
        }
        break;
      case '6':
        switch (char2)
        {
        case '1':
          ledsOn[6] = 2;
          break;
        case '2':
          ledsOn[6] = 3;
          break;
        }
        break;
      case '7':
        switch (char2)
        {
        case '1':
          ledsOn[7] = 2;
          break;
        case '2':
          ledsOn[7] = 3;
          break;
        }
        break;
      case '9':
        switch (char2)
        {
        case '1':
          ledsOn[8] = 2;
          break;
        case '2':
          ledsOn[8] = 3;
          break;
        }
        break;
      case '8':
        switch (char2)
        {
        case '1':
          ledsOn[9] = 2;
          break;
        case '2':
          ledsOn[9] = 3;
          break;
        }
        break;
      }
    }
  }

  //clear all leds at beginning loop to start with clean slate
  FastLED.clear();
  //run over led array to see which led needs which color and turn leds on or off
  for (int i = 0; i < sizeof ledsOn / sizeof ledsOn[0]; i++)
  {
    if (ledsOn[i] == 1)
    {
      //if ledsOn on place i is 1, turn that led to white
      leds[i] = CRGB(225, 225, 255);
    }
    else if (ledsOn[i] == 2)
    {
      //if ledsOn on place i is 1, turn led to green (player 1 scored)
      leds[i] = CRGB(0, 255, 0);
      //set start value of millis if it's 0
      if (startMillis[i] == 0)
      {
        startMillis[i] = millis();
      }
    }
    else if (ledsOn[i] == 3)
    {
      //if ledsOn on place i is 1, turn led to red (player 2 scored)
      leds[i] = CRGB(225, 0, 0);
      //set start value of millis if it's 0
      if (startMillis[i] == 0)
      {
        startMillis[i] = millis();
      }
    }
  }

  //loop over millis array
  for (int i = 0; i < sizeof startMillis / sizeof startMillis[0]; i++)
  {
    Serial.println("millis checken");
    //if any are over 0.3 seconds: turn led in that place off and reset start millis
    if (millis() - startMillis[i] >= 10 && startMillis[i] > 0)
    {
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
  Wire.write(255);              // sends five bytes
  Wire.endTransmission();

  Wire.requestFrom(0x3A, 1); // request 6 bytes from slave device #8

  while (Wire.available())
  {
    int c = Wire.read(); // receive a byte as character
    //see which button is pressed by reading the number
    if (c == 251 && pressed9 == false)
    {
      Keyboard.press('o');   //depending on character read, press right key on keyboard
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed9 = true;       //set pressed to true so you can't keep holding the key and printing the letter
    }
    else if (c != 251)
    {
      pressed9 = false; //set pressed back to false when character read is something else than the corresponding number
    }

    if (c == 247 && pressed10 == false)
    {
      Keyboard.press('p');
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed10 = true;
    }
    else if (c != 247)
    {
      pressed10 = false;
    }
  }
  //}

  //PCF8574 number4
  Wire.beginTransmission(0x38); // transmit to device #8
  Wire.write(255);              // sends five bytes
  Wire.endTransmission();

  Wire.requestFrom(0x38, 1); // request 6 bytes from slave device #8

  while (Wire.available())
  {
    int c = Wire.read(); // receive a byte as character

    //see which button is pressed by reading the number
    if (c == 1 && pressed == false)
    {
      Keyboard.press('e');   //depending on character read, press right key on keyboard
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed = true;        //set pressed to true so you can't keep holding the key and printing the letter
    }
    else if (c != 1)
    {
      pressed = false; //set pressed back to false when character read is something else than the corresponding number
    }

    if (c == 4 && pressed2 == false)
    {
      Keyboard.press('z');
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed2 = true;
    }
    else if (c != 4)
    {
      pressed2 = false;
    }

    if (c == 8 && pressed3 == false)
    {
      Keyboard.press('r');
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed3 = true;
    }
    else if (c != 8)
    {
      pressed3 = false;
    }

    if (c == 16 && pressed4 == false)
    {
      Keyboard.press('t');
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed4 = true;
    }
    else if (c != 16)
    {
      pressed4 = false;
    }

    if (c == 2 && pressed5 == false)
    {
      Keyboard.press('a');
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed5 = true;
    }
    else if (c != 2)
    {
      pressed5 = false;
    }

    if (c == 32 && pressed6 == false)
    {
      Keyboard.press('y');
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed6 = true;
    }
    else if (c != 32)
    {
      pressed6 = false;
    }

    if (c == 64 && pressed7 == false)
    {
      Keyboard.press('u');
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed7 = true;
    }
    else if (c != 64)
    {
      pressed7 = false;
    }

    if (c == 128 && pressed8 == false)
    {
      Keyboard.press('i');
      Keyboard.releaseAll(); // This is important after every Keyboard.press it will continue to be pressed
      pressed8 = true;
    }
    else if (c != 128)
    {
      pressed8 = false;
    }
  }
  delay(10);
}
