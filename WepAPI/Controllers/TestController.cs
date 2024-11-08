using Core.CrossCuttingConcerns.Caching;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ICacheManager _cacheManager;
        private readonly ILogger<TestController> _logger;

        public TestController(ICacheManager cacheManager, ILogger<TestController> logger)
        {
            _cacheManager = cacheManager;
            _logger = logger;
        }

        [HttpGet("memory-test")]
        public IActionResult TestMemoryCache()
        {
            try
            {
                var testData = new { name = "test", value = 123 };
                _cacheManager.Add("memory-test-key", testData, 1);

                var value = _cacheManager.Get<object>("memory-test-key");
                _logger.LogInformation($"Retrieved value from memory cache: {value}");

                return Ok(new { message = "Memory cache test successful", value });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Memory cache test failed");
                return BadRequest(new { message = "Memory cache test failed", error = ex.Message });
            }
        }

        [HttpGet("redis-test")]
        public IActionResult TestRedis()
        {
            try
            {
                var testData = new { name = "test", value = 123 };
                _cacheManager.Add("redis-test-key", testData, 1);

                var value = _cacheManager.Get<object>("redis-test-key");
                _logger.LogInformation($"Retrieved value from Redis: {value}");

                return Ok(new { message = "Redis test successful", value });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Redis test failed");
                return BadRequest(new { message = "Redis test failed", error = ex.Message });
            }
        }
    }
}
