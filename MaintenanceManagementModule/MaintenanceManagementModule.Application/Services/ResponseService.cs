namespace MaintenanceManagementModule.Application.Services
{
    public class ResponseService: IResponseService
    {
        public ResponseDTO Success()
        {
            return new ResponseDTO()
            {
                Success = true
            };
        }

        public ResponseDTO Success(string message)
        {
            return new ResponseDTO()
            {
                Success = true,
                Message = message
            };
        }

        public ResponseDTO Success(dynamic body)
        {
            return new ResponseDTO()
            {
                Success = true,
                Body = body
            };
        }

        public ResponseDTO Success(string message, dynamic body)
        {
            return new ResponseDTO()
            {
                Success = true,
                Message = message,
                Body = body
            };
        }

        public ResponseDTO Failure(string message, dynamic body = null)
        {
            return new ResponseDTO()
            {
                Message = message,
                Body = body
            };
        }

        public ResponseDTO Error(string message, int errorCode = 0)
        {
            return new ResponseDTO()
            {
                ErrorCode = errorCode,
                Message = message
            };
        }

        public ResponseDTO Error(string message, dynamic body, int errorCode = 0)
        {
            return new ResponseDTO()
            {
                ErrorCode = errorCode,
                Message = message,
                Body = body
            };
        }
    }
}
