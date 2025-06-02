namespace MaintenanceManagementModule.Application.Services
{
    public class ServiceService : IServiceService
    {
        #region Properties

        private readonly IMapper _mapper;
        private readonly IResponseService _responseService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;
        #endregion

        #region Constructor
        public ServiceService(
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
        public async Task<ResponseDTO> Add(ServiceDTO serviceDTO)
        {
            var validation = await new ServiceValidator().ValidateAsync(serviceDTO);

            if (!validation.IsValid)
                return _responseService.Failure(validation.Errors[0].ErrorMessage, validation.Errors);

            var userId = _userService.GetUserId();
            var service = _mapper.Map<ServiceEntity>(serviceDTO);
            service.CreatedBy = userId;

            var repository = _unitOfWork.GetRepository<ServiceEntity>();
            await repository.AddAsync(service);

            await _unitOfWork.SaveAsync();

            return _responseService.Success(ResponseMessage.ServiceCreated);
        }

        public async Task<ResponseDTO> GetAll()
        {
            var repository = _unitOfWork.GetRepository<ServiceEntity>();
            var serviceList = await repository.GetAllAsync(e => e.IsDeleted == false);

            if (serviceList is null || serviceList.Count == 0)
                return _responseService.Failure(ResponseMessage.ServiceNotFound);

            var service = new List<ServiceDTO>();
            for (int e = 0; e < serviceList.Count; e++)
            {
                service.Add(_mapper.Map<ServiceDTO>(serviceList[e]));
            }

            return _responseService.Success(service);
        }

        public async Task<ResponseDTO> Get(Guid id)
        {
            var repository = _unitOfWork.GetRepository<ServiceEntity>();
            var service = await repository.GetAsync(e => e.Id == id && e.IsDeleted == false);

            if (service is null)
                return _responseService.Failure(ResponseMessage.TaskNotFound);
            return _responseService.Success(service);
        }

        public async Task<ResponseDTO> Update(ServiceDTO serviceDTO)
        {
            var validation = await new ServiceValidator().ValidateAsync(serviceDTO);
            if (!validation.IsValid)
                return _responseService.Failure(validation.Errors[0].ErrorMessage, validation.Errors);

            var repository = _unitOfWork.GetRepository<ServiceEntity>();
            var service = await repository.GetAsync(e => e.Id == serviceDTO.Id && e.IsDeleted == false);
            var userId = _userService.GetUserId();

            if (service is null)
                return _responseService.Failure(ResponseMessage.ServiceNotFound);

            service.ServiceName = serviceDTO.ServiceName;
            service.ServiceDate = serviceDTO.ServiceDate;
            service.UpdatedBy = userId;
            service.UpdatedOn = DateTime.UtcNow;

            await repository.UpdateAsync(service);
            await _unitOfWork.SaveAsync();

            return _responseService.Success(ResponseMessage.ServiceUpdated);
        }

        public async Task<ResponseDTO> Delete(Guid id)
        {
            var repository = _unitOfWork.GetRepository<ServiceEntity>();
            var service = await repository.GetAsync(e => e.Id == id && e.IsDeleted == false);
            var userId = _userService.GetUserId();

            if (service is null)
                return _responseService.Failure(ResponseMessage.ServiceNotFound);

            service.IsDeleted = true; // Soft delete
            service.DeletedBy = userId;
            service.DeletedOn = DateTime.UtcNow;

            await repository.UpdateAsync(service);
            await _unitOfWork.SaveAsync();

            return _responseService.Success(ResponseMessage.ServiceDeleted);
        }
        #endregion
    }
}
