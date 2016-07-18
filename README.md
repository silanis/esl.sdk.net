esl.sdk.net
===========

eSignlive (eSignature) SDK for .Net. Add e-signatures to your .Net-based apps. For detailed documentation, see https://developer.esignlive.com.

After cloning the eSignLive .NET SDK you will notice the signers.json file is missing in sdk\Silanis.ESL.SDK\SDK.Examples.Tester. You will need to add this file with the following information, replacing {your_api_key} and {eSignLive_instance_url} with the correct values for your testing environment.

```json
{
    "api.key": "{your_api_key}",
    "api.url": "{eSignLive_instance_url}",
    "sender.email": "bob1@e-signlive.com",
    "sender.sms": "15005550006",
    "webpage.url": "https://eslx.silanis.com",
    "1.email": "auto1.silanis@gmail.com",
    "1.sms": "15005550006",
    "2.email": "auto2.silanis@gmail.com",
    "2.sms": "15005550006",
    "3.email": "auto3.silanis@gmail.com",
    "3.sms": "15005550006",
    "4.email": "auto4.silanis@gmail.com",
    "4.sms": "15005550006",
    "5.email": "auto5.silanis@gmail.com",
    "5.sms": "15005550006",
    "6.email": "auto6.silanis@gmail.com",
    "6.sms": "15005550006"
}
```
