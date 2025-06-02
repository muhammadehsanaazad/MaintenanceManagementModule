namespace MaintenanceManagementModule.Application.Services
{
    public class TaskService : ITaskService
    {
        #region Properties

        private readonly IMapper _mapper;
        private readonly IResponseService _responseService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public TaskService(
            IMapper mapper,
            IResponseService responseService,
            IUnitOfWork unitOfWork,
            IUserService userService
            )
        {
            _mapper = mapper;
            _responseService = responseService;
            _unitOfWork = unitOfWork;
            _userService = userService;
        }
        #endregion

        #region Public Methods
        public async Task<ResponseDTO> Add(TaskDTO taskDTO)
        {
            var validation = await new TaskValidator().ValidateAsync(taskDTO);

            if (!validation.IsValid)
                return _responseService.Failure(validation.Errors[0].ErrorMessage, validation.Errors);

            var userId = _userService.GetUserId();
            var task = _mapper.Map<TaskEntity>(taskDTO);
            task.CreatedBy = userId;

            var repository = _unitOfWork.GetRepository<TaskEntity>();
            await repository.AddAsync(task);

            await _unitOfWork.SaveAsync();

            return _responseService.Success(ResponseMessage.TaskCreated);
        }

        public async Task<ResponseDTO> GetAll(Guid serviceId)
        {
            var repository = _unitOfWork.GetRepository<TaskEntity>();
            var taskList = await repository.GetAllAsync(e => e.ServiceId == serviceId && e.IsDeleted == false);

            if (taskList is null || taskList.Count == 0)
                return _responseService.Failure(ResponseMessage.TaskNotFound);

            var task = new List<TaskDTO>();
            for (int e = 0; e < taskList.Count; e++)
            {
                task.Add(_mapper.Map<TaskDTO>(taskList[e]));
            }

            return _responseService.Success(task);
        }

        public async Task<ResponseDTO> Get(Guid id)
        {
            var repository = _unitOfWork.GetRepository<TaskEntity>();
            var task = await repository.GetAsync(e => e.Id == id && e.IsDeleted == false);

            if (task is null)
                return _responseService.Failure(ResponseMessage.TaskNotFound);
            return _responseService.Success(task);
        }

        public async Task<ResponseDTO> Update(TaskDTO taskDTO)
        {
            var validation = await new TaskValidator().ValidateAsync(taskDTO);
            if (!validation.IsValid)
                return _responseService.Failure(validation.Errors[0].ErrorMessage, validation.Errors);

            var repository = _unitOfWork.GetRepository<TaskEntity>();
            var task = await repository.GetAsync(e => e.Id == taskDTO.Id && e.IsDeleted == false);
            var userId = _userService.GetUserId();

            if (task is null)
                return _responseService.Failure(ResponseMessage.TaskNotFound);

            task.TaskName = taskDTO.TaskName;
            task.Description = taskDTO.Description;
            task.Remarks = taskDTO.Remarks;
            task.UpdatedBy = userId;
            task.UpdatedOn = DateTime.UtcNow;

            await repository.UpdateAsync(task);
            await _unitOfWork.SaveAsync();

            return _responseService.Success(ResponseMessage.TaskUpdated);
        }

        public async Task<ResponseDTO> Delete(Guid id)
        {
            var repository = _unitOfWork.GetRepository<TaskEntity>();
            var task = await repository.GetAsync(e => e.Id == id && e.IsDeleted == false);
            var userId = _userService.GetUserId();

            if (task is null)
                return _responseService.Failure(ResponseMessage.TaskNotFound);

            task.IsDeleted = true; // Soft delete
            task.DeletedBy = userId;
            task.DeletedOn = DateTime.UtcNow;

            await repository.UpdateAsync(task);
            await _unitOfWork.SaveAsync();

            return _responseService.Success(ResponseMessage.TaskDeleted);
        }
        #endregion
    }
}
