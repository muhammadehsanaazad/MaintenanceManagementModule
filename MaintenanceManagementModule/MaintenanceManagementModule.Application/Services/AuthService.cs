namespace MaintenanceManagementModule.Application.Services
{
    public class AuthService : IAuthService
    {
        #region Properties

        private readonly AppSetting _appSetting;
        private readonly IMapper _mapper;
        private readonly IResponseService _responseService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        private readonly UserManager<UserEntity> _userManager;
        #endregion

        #region Constructor
        public AuthService(
            IOptions<AppSetting> appSetting,
            IMapper mapper,
            IResponseService responseService,
            IUnitOfWork unitOfWork,
            IUserService userService,
            UserManager<UserEntity> userManager
            )
        {
            _appSetting = appSetting.Value;
            _mapper = mapper;
            _responseService = responseService;
            _unitOfWork = unitOfWork;
            _userService = userService;
            _userManager = userManager;
        }
        #endregion

        #region Public Methods
        public async Task<ResponseDTO> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email.ToLower());
            if (user is not null && await _userManager.CheckPasswordAsync(user, loginDTO.Password))
            {
                var securityDescriptor = new SecurityTokenDescriptor { Subject = new ClaimsIdentity(new Claim[] { new Claim("Id", user.Id.ToString()), new Claim(ClaimTypes.Name, user.UserName) }), Expires = DateTime.Now.AddDays(90), SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSetting.JWTSecret)), SecurityAlgorithms.HmacSha256) };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(securityDescriptor);
                var roles = await _userService.GetUserRoles(loginDTO.Email);

                return _responseService.Success(new { token = tokenHandler.WriteToken(securityToken), user.Id, user.Email, user.FullName, roles, });
            }
            return _responseService.Failure(ResponseMessage.InvalidCredentials);
        }
        #endregion
    }
}
