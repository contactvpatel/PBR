export const UserAPI = {
  GetUser: 'api/user',
  SaveUser: 'api/user'
};

export const AccountAPI = {
  GetAllAccounts: '/Account/Index',
  GetAccountById: '/Account/GetAccountById/',
  UpdateAccount: '/Account/Edit',
  CreateAccount: '/Account/Create',
  DeleteAccount: '/Account/Delete/'
};

export const ApplicationAPI = {
  GetAllApplications: '/ApplicationAccount/Index',
  GetApplicationById: '/ApplicationAccount/GeApplicationAccountById/',
  UpdateApplication: '/ApplicationAccount/Edit',
  CreateApplication: '/ApplicationAccount/Create',
  DeleteApplication: '/ApplicationAccount/delete/',

  GetAccountList: '/ApplicationAccount/GetAccountList',
  GetApplicationList: '/ApplicationAccount/GetApplicationList'
};
export const DepartmentAPI = {
  CreateApplicationDepartment: '/ApplicationDepartment/Create',
  DeleteApplicationDepartment: '/ApplicationDepartment/Delete/',
  UpdateApplicationDepartment: '/ApplicationDepartment/Edit',
  GetAllApplicationDepartments: '/ApplicationDepartment/Index',
  GetAllDepartments: '/ApplicationDepartment/GetDepartmentList',
  GetApplicationDepartmentById:
    '/ApplicationDepartment/GeApplicationAccounttById/',
  GetApplicationNameAndAccountName:
    '/ApplicationDepartment/GetApplicationNameAndAccountName'
};
