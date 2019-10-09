using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreReact.Enums;
using NetCoreReact.Helpers;
using NetCoreReact.Models;
using NetCoreReact.Models.ML;
using NetCoreReact.Services.Business;
using NetCoreReact.Services.ML.Interfaces;

namespace NetCoreReact.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
		private readonly ISampleService _sampleService;
		private readonly IPredictionService _predictionService;

		public SampleController(ISampleService santaService, IPredictionService predictionService)
		{
			this._sampleService = santaService;
			this._predictionService = predictionService;
		}

		[HttpGet("[action]")]
		public async Task<ParticipantsModel> UnauthenticatedSampleGet()
		{
			try
			{
				return await _sampleService.UnauthenticatedSampleGet();
			}
			catch (Exception ex)
			{
				LoggerHelper.Log(ex);
				return new ParticipantsModel();
			}
		}

		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpPost("[action]")]
		public async Task<PresentModel> AuthenticatedSampleGet(string name)
		{
			try
			{
				return await _sampleService.AuthenticatedSampleGet(name);
			}
			catch (Exception ex)
			{
				LoggerHelper.Log(ex);
				return new PresentModel();
			}
		}

		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		[HttpPost("[action]")]
		public async Task<eResponse> AuthenticatedSamplePost([FromBody] InputModel user)
		{
			try
			{
				// Example ML predictions:
				var result1 = _predictionService.Predict(new PredictionInput() { Sentiment = "I hated this so much" });

				var result2 = _predictionService.Predict(new PredictionInput() { Sentiment = "I loved this a lot it was absolutely amazing, great job!" });

				var result3 = _predictionService.Predict(new PredictionInput() { Sentiment = "I dont think that was fun" });

				var result4 = _predictionService.Predict(new PredictionInput() { Sentiment = "I'm sort of indifferent about it" });

				var result5 = _predictionService.Predict(new PredictionInput() { Sentiment = "This sucked worst experience ever, never coming back." });

				var result6 = _predictionService.Predict(new PredictionInput() { Sentiment = "This was so awesome I loved it!" });

                var inputResult = _predictionService.Predict(new PredictionInput() { Sentiment = user.Wishlist });

                return await _sampleService.AuthenticatedSamplePost(user);
			}
			catch (Exception ex)
			{
				LoggerHelper.Log(ex);
				return eResponse.Failure;
			}
		}
	}
}