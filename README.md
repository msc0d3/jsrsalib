<a href="https://tienichmmo.net"><img src="https://user-images.githubusercontent.com/44217992/166666269-6e21588a-29a6-4d51-af1e-d50496d768d6.png" align="top" height="400" /></a>
# jsrsalib
JavaScript RSA Library writen in c#

## Documentation
1 : you need find public key and exponent to encrypt ( debug js to find it )

## Example at : sso.garena.com

 ```
 publickey : D1EC51E7CEA07CB3233ADA6009006EF3EBF89EFD5CF77AAD211051D008077DC7142872B8C36EE971D4B368C79C13A6BBCB89B551A8308C68F71764C1519DEAD90B560E126B365375700CC5A2E6CF81E2A0FEEA31B53C1F8D3F3AE522DF9AB19B5C0C391D997D6DE56807328B9BBD5F6D08EA47614060177E12F65BDB95D5D6E3
 ```
  ```
 exponent : 10001
 ```
 
 ## Call
 -  Create new RSA object
 ```js
 JavaScriptRSA jsRSA = new JavaScriptRSA();
 ```
 #### OR
 ```js
 JavaScriptRSA jsRSA = new JavaScriptRSA(publickey,exponent);
 ```
 - Set RSASetPublic
 ```js
 jsRSA.RSASetPublic(publickey, exponent);
 ```
 ## create encrypted pwd default
 ```js
 string ecryptedPassword = jsRSA.RSAEncrypt("PasswordToEncrypt");
 ```
 ## create encrypted pwd with timestamp
 ```js
 string ecryptedPasswordTs = jsRSA.RSAEncrypt(JavaScriptRSA.AddTimeStamp("PasswordToEncrypt"));
 ```
 ## Result
 - without timestamp pwd : 9b09a726b26e90d4ba242d03af9419f1fd9eff8a4d998cd3ec796f7ad025565591f5ed3d6a34089f3ec69393f12c6d48a49cff0616fd0b0f9256779bdfeee49a223b46d9cfa2459c24f55caf3662c4bbda134375ce0bce3362c1fa74a9e446ce8cf0826e2ae332aa67cdded6b0a8c1835996334c476b95396bcd32c3b3c6e807
- with timestamp pwd : 9661c5f102034eb03e5b27a3d825db24b2a70061abda9aff9fa5347582100cd0ea8d23e44c5755fad17e612e3ba1f9f26a7e10fc9d3f715f3a3675119e69c17c389d609b7f620eaeac7b52ca13bab2496b8bc31b6d84e6269d839c637e7b36b308d81181b381700e797c920b5e07168b3a94241c938dd090913794478291d838

### ❤️ Donate
if this project helpful you , you can donate me at :
## Bank
0369575678 / MB BANK / NGUYEN DAC TAI
## Paypal : nguyendactaidn@gmail.com or [Link Paypal](https://www.paypal.com/paypalme/nguyendactai)
## BTC Addess : 12sNiCFoF31sfVZCuiTof1PfyDqAGt7YT7
