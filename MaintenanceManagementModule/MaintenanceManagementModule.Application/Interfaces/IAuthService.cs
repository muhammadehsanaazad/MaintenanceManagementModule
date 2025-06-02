namespace MaintenanceManagementModule.Application.Interfaces
{
    public interface IAuthService
    {
        Task<ResponseDTO> Login(LoginDTO loginDTO);
    }
}
