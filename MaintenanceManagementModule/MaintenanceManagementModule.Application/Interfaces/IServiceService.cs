namespace MaintenanceManagementModule.Application.Interfaces
{
    public interface IServiceService
    {
        Task<ResponseDTO> Add(ServiceDTO serviceDTO);
        Task<ResponseDTO> GetAll();
        Task<ResponseDTO> Get(Guid id);
        Task<ResponseDTO> Update(ServiceDTO serviceDTO);
        Task<ResponseDTO> Delete(Guid id);
    }
}
