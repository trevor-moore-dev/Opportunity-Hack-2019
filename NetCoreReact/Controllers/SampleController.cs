using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetCoreReact.Enums;
using NetCoreReact.Helpers;
using NetCoreReact.Models;
using NetCoreReact.Services.Business;

namespace NetCoreReact.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SampleController : ControllerBase
    {
		private readonly ISampleService _sampleService;

		public SampleController(ISampleService santaService)
		{
			this._sampleService = santaService;
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