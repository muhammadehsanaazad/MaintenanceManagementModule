namespace MaintenanceManagementModule.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Properties

        private readonly IAuthService _authService;
        private readonly IResponseService _responseService;
        #endregion

        #region Constructor

        public AuthController(
             IAuthService authService,
             IResponseService responseService
            )
        {
            _authService = authService;
            _responseService = responseService;
        }
        #endregion

        #region Public Methods

        [HttpPost]
        public async Task<IActionResult> Login([CustomizeValidator(Skip = true)] LoginDTO loginDTO)
        {
            // Validation check
            if (loginDTO is null)
                return Ok(_responseService.Failure(ResponseMessage.InvalidInput));

            return Ok(await _authService.Login(loginDTO));
        }
        #endregion
    }
}
