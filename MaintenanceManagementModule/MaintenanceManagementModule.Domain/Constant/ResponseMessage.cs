namespace MaintenanceManagementModule.Domain.Constant
{
    public static class ResponseMessage
    {
        public static string InvalidInput = "Input is not valid";
        public static string AccountNotFound = "Account not found";
        public static string InvalidCredentials = "Email or password is incorrect";
        public static string Error = "An error occurred while performing this operation, try again later";

        public static string ServiceCreated = "Service created successfully";
        public static string ServiceUpdated = "Service updated successfully";
        public static string ServiceDeleted = "Service deleted successfully";
        public static string ServiceNotCreated = "An error occurred while creating new service";
        public static string ServiceNotUpdated = "An error occurred while updating the service";
        public static string ServiceNotFound = "Service not found";

        public static string TaskCreated = "Task created successfully";
        public static string TaskUpdated = "Task updated successfully";
        public static string TaskDeleted = "Task deleted successfully";
        public static string TaskNotCreated = "An error occurred while creating new task";
        public static string TaskNotUpdated = "An error occurred while updating the task";
        public static string TaskNotFound = "Task not found";
    }
}
