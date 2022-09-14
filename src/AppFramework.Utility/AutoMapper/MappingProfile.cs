using AppFramework.Domain.ApiModel.Admin;
using AppFramework.Domain.ApiModel.CitizenManagement;
using AppFramework.Domain.ApiModel.EmployeeManagement;
using AppFramework.Domain.ApiModel.EmployeeRoleMapping;
using AppFramework.Domain.ApiModel.Feature;
using AppFramework.Domain.ApiModel.Module;
using AppFramework.Domain.ApiModel.Navigation;
using AppFramework.Domain.ApiModel.Relieving;
using AppFramework.Domain.ApiModel.Role;
using AppFramework.Domain.ApiModel.RoleNavigation;
using AppFramework.Domain.ApiModel.RolePermissions;
using AppFramework.Domain.ApiModel.WorkflowProcess;
using AppFramework.Domain.ApiModel.WorkflowStage;
using AppFramework.Domain.ApiModel.WorkflowStageAction;
using AppFramework.Domain.Model;
using AutoMapper;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using static AppFramework.Domain.Model.NavigationMaster;

namespace AppFramework.Utility.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddRole, RoleMaster>();
            CreateMap<UpdateRole, RoleMaster>();
            CreateMap<RoleMaster, UpdateRole>();

            CreateMap<AddFeature, FeatureMaster>();
            CreateMap<UpdateFeature, FeatureMaster>();
            CreateMap<AddModule, ModuleMaster>();
            CreateMap<UpdateModule, ModuleMaster>();
            CreateMap<AddCitizen, CitizenMaster>().
                //ForMember(d => d.CommunicationAddressBlockId, o => o.MapFrom(s => s.CommunicationAddressBlockId == 0 ? null : s.CommunicationAddressBlockId)).
                //ForMember(d => d.CommunicationAddressDistrictId, o => o.MapFrom(s => s.CommunicationAddressDistrictId == 0 ? null : s.CommunicationAddressDistrictId)).
                //ForMember(d => d.CommunicationAddressTehsilId, o => o.MapFrom(s => s.CommunicationAddressTehsilId == 0 ? null : s.CommunicationAddressTehsilId)).
                //ForMember(d => d.CommunicationAddressVillageId, o => o.MapFrom(s => s.CommunicationAddressVillageId == 0 ? null : s.CommunicationAddressVillageId)).
                //ForMember(d => d.PermanentAddressBlockId, o => o.MapFrom(s => s.PermanentAddressBlockId == 0 ? null : s.PermanentAddressBlockId)).
                ForMember(d => d.PermanentAddressDistrictId, o => o.MapFrom(s => s.PermanentAddressDistrictId == 0 ? null : s.PermanentAddressDistrictId));
            //ForMember(d => d.PermanentAddressTehsilId, o => o.MapFrom(s => s.PermanentAddressTehsilId == 0 ? null : s.PermanentAddressTehsilId)).
            //ForMember(d => d.PermanentAddressVillageId, o => o.MapFrom(s => s.PermanentAddressVillageId == 0 ? null : s.PermanentAddressVillageId));
            CreateMap<UpdateCitizen, CitizenMaster>().
                //ForMember(d => d.CommunicationAddressBlockId, o => o.MapFrom(s => s.CommunicationAddressBlockId == 0 ? null : s.CommunicationAddressBlockId)).
                //ForMember(d => d.CommunicationAddressDistrictId, o => o.MapFrom(s => s.CommunicationAddressDistrictId == 0 ? null : s.CommunicationAddressDistrictId)).
                //ForMember(d => d.CommunicationAddressTehsilId, o => o.MapFrom(s => s.CommunicationAddressTehsilId == 0 ? null : s.CommunicationAddressTehsilId)).
                //ForMember(d => d.CommunicationAddressVillageId, o => o.MapFrom(s => s.CommunicationAddressVillageId == 0 ? null : s.CommunicationAddressVillageId)).
                //ForMember(d => d.PermanentAddressBlockId, o => o.MapFrom(s => s.PermanentAddressBlockId == 0 ? null : s.PermanentAddressBlockId)).
                ForMember(d => d.PermanentAddressDistrictId, o => o.MapFrom(s => s.PermanentAddressDistrictId == 0 ? null : s.PermanentAddressDistrictId));
            //ForMember(d => d.PermanentAddressTehsilId, o => o.MapFrom(s => s.PermanentAddressTehsilId == 0 ? null : s.PermanentAddressTehsilId)).
            //ForMember(d => d.PermanentAddressVillageId, o => o.MapFrom(s => s.PermanentAddressVillageId == 0 ? null : s.PermanentAddressVillageId));
            CreateMap<AddEmployee, EmployeeMaster>().
                //ForMember(d => d.CommunicationAddressBlockId, o => o.MapFrom(s => s.CommunicationAddressBlockId == 0 ? null : s.CommunicationAddressBlockId)).
                //ForMember(d => d.CommunicationAddressDistrictId, o => o.MapFrom(s => s.CommunicationAddressDistrictId == 0 ? null : s.CommunicationAddressDistrictId)).
                //ForMember(d => d.CommunicationAddressTehsilId, o => o.MapFrom(s => s.CommunicationAddressTehsilId == 0 ? null : s.CommunicationAddressTehsilId)).
                //ForMember(d => d.CommunicationAddressVillageId, o => o.MapFrom(s => s.CommunicationAddressVillageId == 0 ? null : s.CommunicationAddressVillageId)).
                //ForMember(d => d.PermanentAddressBlockId, o => o.MapFrom(s => s.PermanentAddressBlockId == 0 ? null : s.PermanentAddressBlockId)).
                ForMember(d => d.PermanentAddressDistrictId, o => o.MapFrom(s => s.PermanentAddressDistrictId == 0 ? null : s.PermanentAddressDistrictId));
            // ForMember(d => d.PermanentAddressTehsilId, o => o.MapFrom(s => s.PermanentAddressTehsilId == 0 ? null : s.PermanentAddressTehsilId)).
            // ForMember(d => d.PermanentAddressVillageId, o => o.MapFrom(s => s.PermanentAddressVillageId == 0 ? null : s.PermanentAddressVillageId)); 
            CreateMap<UpdateEmployee, EmployeeMaster>().
                //ForMember(d => d.CommunicationAddressBlockId, o => o.MapFrom(s => s.CommunicationAddressBlockId == 0 ? null : s.CommunicationAddressBlockId)).
                //ForMember(d => d.CommunicationAddressDistrictId, o => o.MapFrom(s => s.CommunicationAddressDistrictId == 0 ? null : s.CommunicationAddressDistrictId)).
                //ForMember(d => d.CommunicationAddressTehsilId, o => o.MapFrom(s => s.CommunicationAddressTehsilId == 0 ? null : s.CommunicationAddressTehsilId)).
                //ForMember(d => d.CommunicationAddressVillageId, o => o.MapFrom(s => s.CommunicationAddressVillageId == 0 ? null : s.CommunicationAddressVillageId)).
                //ForMember(d => d.PermanentAddressBlockId, o => o.MapFrom(s => s.PermanentAddressBlockId == 0 ? null : s.PermanentAddressBlockId)).
                ForMember(d => d.PermanentAddressDistrictId, o => o.MapFrom(s => s.PermanentAddressDistrictId == 0 ? null : s.PermanentAddressDistrictId));
            //ForMember(d => d.PermanentAddressTehsilId, o => o.MapFrom(s => s.PermanentAddressTehsilId == 0 ? null : s.PermanentAddressTehsilId)).
            //ForMember(d => d.PermanentAddressVillageId, o => o.MapFrom(s => s.PermanentAddressVillageId == 0 ? null : s.PermanentAddressVillageId)); 

            CreateMap<CitizenMaster, AddCitizen>();
            CreateMap<CitizenMaster, UpdateCitizen>();
            CreateMap<CitizenLogin, CitizenLoginMaster>();

            CreateMap<EmployeeMaster, AddEmployee>();
            CreateMap<EmployeeMaster, UpdateEmployee>();
            CreateMap<EmployeeLogin, EmployeeLoginMaster>();

            CreateMap<AddWorkflowStage, WorkflowStageMaster>();
            CreateMap<UpdateWorkflowStage, WorkflowStageMaster>();
            CreateMap<WorkflowStageMaster, AddWorkflowStage>();
            CreateMap<WorkflowStageMaster, UpdateWorkflowStage>();

            CreateMap<AddWorkflowProcess, WorkflowProcessMaster>().ForMember(d => d.ParentProcessIdFk, o => o.MapFrom(s => s.ParentProcessIdFk == 0 ? null : s.ParentProcessIdFk));
            CreateMap<UpdateWorkflowProcess, WorkflowProcessMaster>();
            CreateMap<WorkflowProcessMaster, AddWorkflowProcess>();
            CreateMap<WorkflowProcessMaster, UpdateWorkflowProcess>();

            CreateMap<UpdateWorkflowStageAction, WorkflowStageActionMaster>();
            CreateMap<AddWorkflowStageAction, WorkflowStageActionMaster>();
            CreateMap<WorkflowStageActionMaster, AddWorkflowStageAction>();
            CreateMap<WorkflowStageActionMaster, UpdateWorkflowStageAction>();
            CreateMap<AdminLogin, AdminLoginMaster>();


            CreateMap<NavigationMaster, AddNavigation>();
            CreateMap<AddNavigation, NavigationMaster>();

            CreateMap<UpdateNavigation, NavigationMaster>();
            CreateMap<NavigationMaster, UpdateNavigation>();

            CreateMap<AddRolePermission, RolePermissionMaster>();
            CreateMap<UpdateRolePermission, RolePermissionMaster>();
            CreateMap<RolePermissionMaster, AddRolePermission>();
            CreateMap<RolePermissionMaster, UpdateRolePermission>();
            CreateMap<AddRoleNavigation, RoleNavigationMaster>();
            CreateMap<UpdateRoleNavigation, RoleNavigationMaster>();
            CreateMap<RoleNavigationMaster, AddRoleNavigation>();
            CreateMap<RoleNavigationMaster, UpdateRoleNavigation>();
            CreateMap<AddEmployeeRoleMapping, EmployeeRoleMappingMaster>();
            CreateMap<UpdateEmployeeRoleMapping, EmployeeRoleMappingMaster>();
            CreateMap<EmployeeRoleMappingMaster, AddEmployeeRoleMapping>();
            CreateMap<EmployeeRoleMappingMaster, UpdateEmployeeRoleMapping>();

            CreateMap<UpdateEmployeeProfile, EmployeeMaster>();
            CreateMap<EmployeeMaster, UpdateEmployeeProfile>();
            CreateMap<UpdateCitizenProfile, CitizenMaster>();
            CreateMap<CitizenMaster, UpdateCitizenProfile>();

            CreateMap<RelievingMaster, AddRelieving>();
            CreateMap<AddRelieving, RelievingMaster>();

            CreateMap<AddRoleNavigation, RoleNavigationMapping>();
            
        }
        private List<int> GetRole(string model)
        {
            if (string.IsNullOrEmpty(model))
            {
                return null;
            }
            else
            {
                return model.Split(',').Select(int.Parse).ToList();
            }
        }
    }
}
