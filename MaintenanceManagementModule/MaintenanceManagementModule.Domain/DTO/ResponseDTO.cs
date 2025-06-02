namespace MaintenanceManagementModule.Domain.DTO
{
    public class ResponseDTO
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Body { get; set; }
        public int ErrorCode { get; set; }
    }
}
