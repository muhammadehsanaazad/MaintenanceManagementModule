namespace MaintenanceManagementModule.Application.Helpers
{
    public class ProfileMapper : AutoMapper.Profile
    {
        public ProfileMapper()
        {
            // Task mapper
            CreateMap<TaskDTO, TaskEntity>()
               .ForMember(e => e.Id, h => h.MapFrom(e => Guid.NewGuid()))
               .ForMember(e => e.CreatedOn, s => s.MapFrom(e => DateTime.UtcNow));
            CreateMap<TaskEntity, TaskDTO>();

            // Service mapper
            CreateMap<ServiceDTO, ServiceEntity>()
               .ForMember(e => e.Id, h => h.MapFrom(e => Guid.NewGuid()))
               .ForMember(e => e.CreatedOn, s => s.MapFrom(e => DateTime.UtcNow));
            CreateMap<ServiceEntity, ServiceDTO>();
        }
    }
}
