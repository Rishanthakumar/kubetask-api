using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kubetask_api.DTO;
using kubetask_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace kubetask_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            this._taskService = taskService;
        }

        [Route("{taskID}"), HttpGet]
        public async Task<IActionResult> Get([FromRoute]Guid taskID)
        {
            var result = await _taskService.GetTask(taskID);
            return Ok(result);
        }

        [Route("list"), HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await _taskService.ListTasks();
            return Ok(result);
        }

        [Route("add"), HttpPost]
        public async Task<IActionResult> Add([FromBody]TaskData taskData)
        {
            await this._taskService.AddTask(taskData);
            return Ok("Success");
        }

        [Route("{taskID}"), HttpPut]
        public async Task<IActionResult> Update([FromRoute]Guid taskID, [FromBody]TaskData taskData)
        {
            await this._taskService.Update(taskID, taskData);
            return Ok("Success");
        }

        [Route("{taskID}"), HttpDelete]
        public async Task<IActionResult> Delete([FromRoute]Guid taskID)
        {
            await this._taskService.DeleteTask(taskID);
            return Ok("Success");
        }
    }
}
