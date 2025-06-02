namespace MaintenanceManagementModule.Application.Services
{
    public class UserService : IUserService
    {
        #region Properties

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<UserEntity> _userManager;
        #endregion

        #region Constructor

        public UserService(
             IHttpContextAccessor httpContextAccessor,
             UserManager<UserEntity> userManager
            )
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        #endregion

        #region Public Methods

        public Guid? GetUserId()
        {
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(e => e.Type == "Id")?.Value;
                if (!string.IsNullOrWhiteSpace(userId))
                    return Guid.Parse(userId);
                else return null;
            }
            return null;
        }

        public async Task<UserEntity?> GetUser(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IList<string>> GetUserRoles(string email)
        {
            var user = await GetUser(email);
            if (user is null)
                return null;

            return await _userManager.GetRolesAsync(user);
        }
        #endregion
    }
}
