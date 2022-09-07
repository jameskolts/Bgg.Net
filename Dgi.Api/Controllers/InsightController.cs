using Dgi.Api.Models;
using Dgi.Api.Services;
using Dgi.Api.Validation;
using Microsoft.AspNetCore.Mvc;
using ILogger = Serilog.ILogger;

namespace Dgi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsightController : ControllerBase
    {
        private readonly IInsightRequestValidator _validator;
        private readonly IInsightManager _insightManager;
        private readonly ILogger _logger;

        public InsightController(ILogger logger, IInsightRequestValidator validator, IInsightManager manager)
        {
            _logger = logger;
            _validator = validator;
            _insightManager = manager;
        }

        [HttpGet]
        public async Task<ActionResult<InsightResponse>> GetInsights(InsightRequest request) 
        {
            var response = new InsightResponse
            {
                IsSuccessful = true
            };

            var validationResult = _validator.Validate(request);

            if (!validationResult.IsValid)
            {
                _logger.Error(string.Join('.', validationResult.Errors));
                response.Errors = validationResult.Errors;
                return BadRequest(response);
            }

            try
            {
                response.Insights = _insightManager.GetInsights(request);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                response.Errors.Add(ex.Message);
                response.IsSuccessful = false;

                return UnprocessableEntity(response);
            }

            return Ok(response);
        }
    }
}
