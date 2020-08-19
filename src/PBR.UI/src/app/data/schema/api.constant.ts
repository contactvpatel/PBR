export const UserAPI = {
  GetUser: 'api/user',
  SaveUser: 'api/user'
};

export const AccountAPI = {
  GetAllAccounts: '/PowerBiAccount/Index',
  GetAccountById: '/PowerBiAccount/GetAccountById/',
  UpdateAccount: '/PowerBiAccount/Edit',
  CreateAccount: '/PowerBiAccount/Create',
  DeleteAccount: '/PowerBiAccount/Delete/'
};

export const ApplicationAPI = {
  GetAllApplications: '/PowerBiApplicationAccount/Index',
  GetApplicationById: '/PowerBiApplicationAccount/GeApplicationAccountById/',
  UpdateApplication: '/PowerBiApplicationAccount/Edit',
  CreateApplication: '/PowerBiApplicationAccount/Create',
  DeleteApplication: '/PowerBiApplicationAccount/delete/',

  GetAccountList: '/PowerBiApplicationAccount/GetAccountList',
  GetApplicationList: '/PowerBiApplicationAccount/GetApplicationList'
};
export const DepartmentAPI = {
  CreateApplicationDepartment: '/PowerBiApplicationDepartment/Create',
  DeleteApplicationDepartment: '/PowerBiApplicationDepartment/Delete/',
  UpdateApplicationDepartment: '/PowerBiApplicationDepartment/Edit',
  GetAllApplicationDepartments: '/PowerBiApplicationDepartment/Index',
  GetAllDepartments: '/PowerBiApplicationDepartment/GetDepartmentList',
  GetApplicationDepartmentById:
    '/PowerBiApplicationDepartment/GeApplicationAccounttById/',
  GetApplicationNameAndAccountName:
    '/PowerBiApplicationDepartment/GetApplicationNameAndAccountName'
};
