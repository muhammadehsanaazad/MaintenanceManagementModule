namespace MaintenanceManagementModule.Application.Interfaces
{
    public interface ITaskService
    {
        Task<ResponseDTO> Add(TaskDTO taskDTO);
        Task<ResponseDTO> GetAll(Guid serviceId);
        Task<ResponseDTO> Get(Guid id);
        Task<ResponseDTO> Update(TaskDTO taskDTO);
        Task<ResponseDTO> Delete(Guid id);
    }
}
