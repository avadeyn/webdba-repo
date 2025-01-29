//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using System;
//using System.Collections.Generic;
//using Twilio;
//using Twilio.Rest.Api.V2010.Account;
//using Twilio.Rest.Verify.V2.Service;
//using Twilio.Types;


//[HttpPost]
//class VerificationCode
//{
//	static void Main(string[] args)
//	{
//		var accountSid = "ACf318bccd2b7b397279659c101a85ef4a";
//		var authToken = "db8a952cd3fbc05d0cea3aac0e3d836d";
//		TwilioClient.Init(accountSid, authToken);

//		var verification = VerificationResource.Create(
//			to: "+639274669009",
//			channel: "sms",
//			pathServiceSid: "VA03960829216dedab8d7ae3e4794fdf74"
//		);

//		Console.WriteLine(verification.Sid);
//	}
//}