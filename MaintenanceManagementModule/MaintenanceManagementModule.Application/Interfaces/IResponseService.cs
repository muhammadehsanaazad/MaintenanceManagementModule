namespace MaintenanceManagementModule.Application.Interfaces
{
    public interface IResponseService
    {
        public ResponseDTO Success();
        public ResponseDTO Success(string message);
        public ResponseDTO Success(dynamic body);
        public ResponseDTO Success(string message, dynamic body);
        public ResponseDTO Failure(string message, dynamic? body = null);
        public ResponseDTO Error(string message, int errorCode = 0);
        public ResponseDTO Error(string message, dynamic body, int errorCode = 0);
    }
}
