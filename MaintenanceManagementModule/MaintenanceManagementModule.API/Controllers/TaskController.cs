namespace MaintenanceManagementModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        #region Properties

        private readonly IResponseService _responseService;
        private readonly ITaskService _taskService;
        #endregion

        #region Constructor

        public TaskController(
             IResponseService responseService,
             ITaskService taskService
            )
        {
            _responseService = responseService;
            _taskService = taskService;
        }
        #endregion

        #region Public Methods

        [HttpPost]
        public async Task<IActionResult> Add([CustomizeValidator(Skip = true)] TaskDTO taskDTO)
        {
            // Validation check
            if (taskDTO is null)
                return Ok(_responseService.Failure(ResponseMessage.InvalidInput));

            return Ok(await _taskService.Add(taskDTO));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(Guid serviceId)
        {
            return Ok(await _taskService.GetAll(serviceId));
        }

        [HttpPut]
        public async Task<IActionResult> Update([CustomizeValidator(Skip = true)] TaskDTO taskDTO)
        {
            // Validation check
            if (taskDTO is null)
                return Ok(_responseService.Failure(ResponseMessage.InvalidInput));

            return Ok(await _taskService.Update(taskDTO));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            // Validation check
            if (id == Guid.Empty)
                return Ok(_responseService.Failure(ResponseMessage.InvalidInput));

            return Ok(await _taskService.Delete(id));
        }
        #endregion
    }
}
