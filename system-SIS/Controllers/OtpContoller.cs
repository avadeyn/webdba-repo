//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using System;
//using System.Collections.Generic;
//using Twilio;
//using Twilio.Clients;
//using Twilio.Rest.Api.V2010.Account;
//using Twilio.Rest.Verify.V2.Service;
//using Twilio.Types;



//namespace system_SIS.Controllers
//{
//	[ApiController]


//	public class OtpContoller : Controller
//	{
//		private readonly ITwilioRestClient _client;
//		public OtpContoller(ITwilioRestClient client)
//		{
//			_client = client;
//		}

//		[HttpPost]
//		public IActionResult SendOtp()
//		{
//			var accountSid = "[AccountSid]";
//			var authToken = "[AuthToken]";
//			TwilioClient.Init(accountSid, authToken);

//			var verification = VerificationResource.Create(
//				to: "+639274669009",
//				channel: "sms",
//				pathServiceSid: "VA03960829216dedab8d7ae3e4794fdf74"
//			);

//			Console.WriteLine(verification.Sid);
//		}



//	}
//}
