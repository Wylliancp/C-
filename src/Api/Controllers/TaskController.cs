using System.Collections.Generic;
using Domain.Commands;
using Domain.Entities;
using Domain.Handlers;
using Domain.interfaces.Commands;
using Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;

        public TaskController(ILogger<TaskController> logger)
        {
            _logger = logger;
        }

        [Route("GetTById")]
        [HttpGet]
        public Tasks GetById([FromBody] int id, [FromServices] ITasksRepository repository)
        {
            return repository.GetById(id);
        }

        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<Tasks> GetAll([FromServices] ITasksRepository repository)
        {
            return repository.GetAll();
        }

        [Route("Create")]
        [HttpPost]
        public ICommandResult Create([FromBody] CreateTaskCommand createTaskCommand, [FromServices] TasksHandler handler)
        {
             return handler.Handle(createTaskCommand);
        }

        [Route("Finish")]
        [HttpPut]
        public ICommandResult Finish([FromBody] FinishTaskCommand finishTaskCommand, [FromServices] TasksHandler handler)
        {
             return handler.Handle(finishTaskCommand);
        }

        [Route("ReOpen")]
        [HttpPut]
        public ICommandResult ReOpen([FromBody] ReOpenTaskCommand reOpenTaskCommand, [FromServices] TasksHandler handler)
        {
             return handler.Handle(reOpenTaskCommand);
        }

        [Route("Delete")]
        [HttpDelete]
        public ICommandResult Delete([FromQuery] DeleteTaskCommand deleteTaskCommand, [FromServices] TasksHandler handler)
        {
             return handler.Handle(deleteTaskCommand);
        }
    }
}
