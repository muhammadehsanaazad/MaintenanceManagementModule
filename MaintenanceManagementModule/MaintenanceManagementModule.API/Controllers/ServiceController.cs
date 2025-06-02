namespace MaintenanceManagementModule.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        #region Properties

        private readonly IResponseService _responseService;
        private readonly IServiceService _serviceService;
        #endregion

        #region Constructor

        public ServiceController(
             IResponseService responseService,
             IServiceService serviceService
            )
        {
            _responseService = responseService;
            _serviceService = serviceService;
        }
        #endregion

        #region Public Methods

        [HttpPost]
        public async Task<IActionResult> Add([CustomizeValidator(Skip = true)] ServiceDTO serviceDTO)
        {
            // Validation check
            if (serviceDTO is null)
                return Ok(_responseService.Failure(ResponseMessage.InvalidInput));

            return Ok(await _serviceService.Add(serviceDTO));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _serviceService.GetAll());
        }

        [HttpPut]
        public async Task<IActionResult> Update([CustomizeValidator(Skip = true)] ServiceDTO serviceDTO)
        {
            // Validation check
            if (serviceDTO is null)
                return Ok(_responseService.Failure(ResponseMessage.InvalidInput));

            return Ok(await _serviceService.Update(serviceDTO));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            // Validation check
            if (id == Guid.Empty)
                return Ok(_responseService.Failure(ResponseMessage.InvalidInput));

            return Ok(await _serviceService.Delete(id));
        }
        #endregion
    }
}
