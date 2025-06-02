namespace MaintenanceManagementModule.API.ExceptionFilter
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            try
            {
                var response = new ResponseDTO
                {
                    Success = false,
                    Message = ResponseMessage.Error,
                    Body = context.Exception.InnerException is null ? context.Exception.Message : context.Exception.InnerException.Message,
                    ErrorCode = (int)HttpStatusCode.InternalServerError
                };

                context.Result = new JsonResult(response)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
            catch (Exception exception)
            {
                var response = new ResponseDTO
                {
                    Success = false,
                    Message = ResponseMessage.Error,
                    Body = exception.InnerException is null ? exception.Message : exception.InnerException.Message,
                    ErrorCode = (int)HttpStatusCode.InternalServerError
                };

                context.Result = new JsonResult(response)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

    }
}
