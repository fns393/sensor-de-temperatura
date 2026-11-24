#include <Wire.h>
#include <LiquidCrystal_I2C.h>
#include <DHT.h>

DHT dht(2, DHT11);
LiquidCrystal_I2C lcd(0x27, 16, 2);

float temp;
float old_temp = -999;

float hum;
float old_hum = -999;

void setup() {
  Serial.begin(9600);
  dht.begin();
  lcd.init();
  lcd.backlight();
}

void loop() {
  temp = dht.readTemperature();
  hum = dht.readHumidity();
  Serial.println("Temp: " + String(temp) + "C | Hum: " + String(hum) + " %");

  if (temp != old_temp || hum != old_hum) {

    


    lcd.clear();
    lcd.setCursor(1, 0);
    lcd.print("Temp: " + String(temp) + " C");

    lcd.setCursor(1, 1);
    lcd.print("Hum:  " + String(hum) + " %");

    old_temp = temp;
    old_hum = hum;
  }

  delay(2000);
}
