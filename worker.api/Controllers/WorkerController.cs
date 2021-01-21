using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using worker.api.Domain;
using worker.api.Service;

namespace worker.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerClient _worker;
        private readonly ILogger<WorkerController> _logger;

        public WorkerController(ILogger<WorkerController> logger, IWorkerClient worker)
        {
            _logger = logger;
            _worker = worker;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order command)
        {
            try
            {
                var jobId = BackgroundJob.Enqueue(() => _worker.Function1Async(command));

                var dto = new
                {
                    message = "Sua requisição já esta na fila",
                    details = jobId,
                };

                _logger.LogInformation(dto.message, dto.details);

                return Ok(dto);
            }
            catch (Exception e)
            {
                var dto = new
                {
                    message = "Não foi possível completar sua requisição",
                    details = e
                };

                _logger.LogError(dto.message, dto.details);

                return BadRequest(dto);
            }
        }

        [HttpGet("orderId")]
        public IActionResult Get(string orderId)
        {
            try
            {
                var jobId = BackgroundJob.Enqueue(() => _worker.Function2Async(orderId));

                var dto = new
                {
                    message = "Sua requisição já esta na fila",
                    details = jobId,
                };

                _logger.LogInformation(dto.message, dto.details);

                return Ok(dto);
            }
            catch (Exception e)
            {
                var dto = new
                {
                    message = "Não foi possível completar sua requisição",
                    details = e
                };

                _logger.LogError(dto.message, dto.details);

                return BadRequest(dto);
            }
        }

        [HttpGet("chain")]
        public IActionResult Chain()
        {
            try
            {
                var jobId = BackgroundJob.Enqueue(() => _logger.LogInformation("Primary Job"));
                
                var continuationJob1 = BackgroundJob.ContinueJobWith(jobId, () => _logger.LogInformation("Continuation Job 1"));
                var continuationJob2 = BackgroundJob.ContinueJobWith(continuationJob1, () => _logger.LogInformation("Continuation Job 2"));
                var continuationJob3 = BackgroundJob.ContinueJobWith(continuationJob2, () => _logger.LogInformation("Continuation Job 3"));
                var continuationJob4 = BackgroundJob.ContinueJobWith(continuationJob3, () => _logger.LogInformation("Continuation Job 4"));
                var continuationJob5 = BackgroundJob.ContinueJobWith(continuationJob4, () => _logger.LogInformation("Continuation Job 5"));

                var dto = new
                {
                    message = "Sua requisição já esta na fila",
                    details = jobId,
                };

                _logger.LogInformation(dto.message, dto.details);

                return Ok(dto);
            }
            catch (Exception e)
            {
                var dto = new
                {
                    message = "Não foi possível completar sua requisição",
                    details = e
                };

                _logger.LogError(dto.message, dto.details);

                return BadRequest(dto);
            }
        }
    }
}
