namespace AppFramework.Utility.DataConfig
{
    public static class Procedure
    {
        #region Employee Management
        public const string SaveEmployee = "SaveEmployee";
        public const string UpdateEmployee = "UpdateEmployee";
        public const string DeleteEmployee = "DeleteEmployee";
        public const string GetAllEmployee = "GetAllEmployee";
        public const string GetEmployeeById = "GetEmployeeById";
        public const string GetEmployeeByEmail = "GetEmployeeByEmail";
        public const string ForgotPassword = "ForgotPassword";
        public const string ResetPassword = "ResetPassword";
        public const string EmployeeLogin = "Employee_Login";
        public const string EmployementType = "EmployementType";
        #endregion

        #region Citizen Management
        public const string SaveCitizen = "SaveCitizen";
        public const string UpdateCitizen = "UpdateCitizen";
        public const string DeleteCitizen = "DeleteCitizen";
        public const string GetAllCitizen = "GetAllCitizen";
        public const string GetCitizenById = "GetCitizenById";
        public const string CitizenChangePassword = "Citizen_ChangePassword";
        public const string CitizenLogin = "Citizen_Login";
        #endregion

        #region Role Management
        public const string SaveRole = "SaveRole";
        public const string UpdateRole = "UpdateRole";
        public const string DeleteRole = "DeleteRole";
        public const string GetAllRole = "GetAllRole";
        public const string GetRoleById = "GetRoleById";
        #endregion

        #region Feature Management
        public const string SaveFeature = "SaveFeature";
        public const string UpdateFeature = "UpdateFeature";
        public const string DeleteFeature = "DeleteFeature";
        public const string GetAllFeature = "GetAllFeature";
        public const string GetFeatureById = "GetFeatureById";
        #endregion

        #region Module Management
        public const string SaveModule = "SaveModule";
        public const string UpdateModule = "UpdateModule";
        public const string DeleteModule = "DeleteModule";
        public const string GetAllModule = "GetAllModule";
        public const string GetModuleById = "GetModuleById";
        public const string GetModuleByFeatureId = "GetModuleByFeatureId";
        #endregion

        #region State Management
        public const string GetAllStates = "GetAllStates";
        #endregion

        #region Citizen Management
        public const string GetDistrictsByStateId = "GetDistrictsByStateId";
        #endregion

        #region WorkFlow Process
        public const string SaveWorkflowProcess = "Md_Workflow_Process_Insert_Update";
        public const string UpdateWorkflowProcess = "Md_Workflow_Process_Insert_Update";
        public const string DeleteWorkflowProcess = "Md_Workflow_Process_Delete";
        public const string GetAllWorkflowProcess = "Md_Workflow_Process_Select";
        public const string GetWorkflowProcessById = "Md_WorkFlow_Process_SelectById";
        #endregion

        #region WorkFlow Stage
        public const string SaveWorkflowStage = "Md_Workflow_Stage_INSERT";
        public const string UpdateWorkflowStage = "Md_Workflow_Stage_UPDATE";
        public const string DeleteWorkflowStage = "Md_Workflow_Stage_Delete";
        public const string GetAllWorkflowStage = "Md_Workflow_Stage_SELECT";
        public const string GetWorkflowStageById = "Md_Workflow_Stage_SELECT";
        #endregion

        #region WorkFlow Stage Action
        public const string SaveWorkflowStageAction = "Md_Workflow_Stage_Actions_Insert_Update";
        public const string UpdateWorkflowStageAction = "Md_Workflow_Stage_Actions_Insert_Update";
        public const string DeleteWorkflowStageAction = "Md_Workflow_Stage_Actions_Delete";
        public const string GetAllWorkflowStageAction = "Md_Workflow_Stage_Actions_Select";
        public const string GetWorkflowStageActionById = "Md_Workflow_Stage_Actions_Select";
        #endregion

        #region Department Management
        public const string GetAllDepartment = "GetAllDepartment";

        #endregion

        #region Admin Login
        public const string AdminLogin = "Admin_Login";
        public const string ChangePassword = "ChangePassword";
        public const string ResetEmployeePassword = "ResetEmployeePassword";

        #endregion


        #region Navigation
        public const string SaveNavigation = "SaveNavigation";
        public const string UpdateNavigation = "UpdateNavigation";
        public const string DeleteNavigation = "DeleteNavigation";
        public const string GetAllNavigations = "GetAllNavigation";
        public const string GetNavigationById = "GetNavigationById";
        public const string GetNavigation = "GetNavigation";

        #endregion

        #region RolePermission Management
        public const string SaveRolePermission = "SaveRolePermission";
        public const string UpdateRolePermission = "UpdateRolePermission";
        public const string DeleteRolePermission = "DeleteRolePermission";
        public const string GetAllRolePermission = "GetAllRolePermission";
        public const string GetRolePermissionById = "GetRolePermissionById";
        #endregion

        #region RoleNavigation Management
        public const string SaveRoleNavigation = "SaveRoleNavigation";
        public const string UpdateRoleNavigation = "UpdateRoleNavigation";
        public const string DeleteRoleNavigation = "DeleteRoleNavigation";
        public const string GetAllRoleNavigation = "GetAllRoleNavigation";
        public const string GetRoleNavigationById = "GetRoleNavigationById";
        #endregion


        #region Employee Role Mappipng Management
        public const string SaveEmployeeRoleMapping = "SaveEmployeeRoleMapping";
        public const string UpdateEmployeeRoleMapping = "UpdateEmployeeRoleMapping";

        public const string GetEmployeeRoleMappingById = "GetEmployeeRoleMappingById";
        public const string GetAllEmployeeRoleMapping = "GetAllEmployeeRoleMapping";
        #endregion

        #region Profile
        public const string GetProfile = "GetProfile";
        public const string UpdateProfile = "UpdateProfile";
        public const string UploadProfileImage = "UploadProfileImage";
        public const string UploadProfileImageById = "UploadProfileImageById";

        #endregion

        #region Relieving
        public const string SaveRelieving = "SaveRelieving";
        #endregion

        #region LogError
        public const string SaveLog= "SaveError";
        public const string GetAllLog= "GetAllLog";

        #endregion

    }
}
