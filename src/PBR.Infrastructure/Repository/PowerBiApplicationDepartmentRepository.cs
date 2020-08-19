using Microsoft.EntityFrameworkCore;
using PBR.Core.Entities;
using PBR.Core.Entities.Base;
using PBR.Core.Repositories;
using PBR.Core.Specifications;
using PBR.Infrastructure.Data;
using PBR.Infrastructure.Repository.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBR.Infrastructure.Repository
{
public class PowerBiApplicationDepartmentRepository: Repository<ApplicationDepartment>, IPowerBiApplicationDepartmentRepository
    {
        private readonly DataContext dataContext;
        public PowerBiApplicationDepartmentRepository(DataContext dbContext) : base(dbContext)
        {
            dataContext = dbContext;
            
        }

       
        public async Task<IEnumerable<ApplicationDepartment>> CheckApplicatioIdAndDepartmentIdExists(int ApplicationId,int DepartmentId)
        {
        
                var spec = new PowerBiApplicationDepartmentSpecification(ApplicationId, DepartmentId);
            var ApplicationIdExists = (await GetAsync(spec)).ToList();
            return ApplicationIdExists;
        }

        public async Task<IEnumerable<ApplicationDepartment>> GetApplicationAccountListAsync()
        {
            var spec = new PowerBiApplicationDepartmentSpecification();
            var account = (await GetAsync(spec)).ToList();
            return account;

        }
        public  IList ApplicationDepartmentListAsync()
        {
            var innerJoin = from ApplicationDepartment in dataContext.applicationDepartments// outer sequence
                            join applicationAccounts in dataContext.applicationAccounts//inner sequence 
                            on ApplicationDepartment.ApplicationAccountId equals applicationAccounts.Id
                            join Accounts in dataContext.Accounts
                            on applicationAccounts.AccountId equals Accounts.Id
                            join Application in dataContext.application
                            on applicationAccounts.ApplicationId equals Application.ApplicationId
                            join Department in dataContext.departments
                            on ApplicationDepartment.DepartmentId equals Department.DepartmentId

                            select new
                            { // result selector 
                                Id=ApplicationDepartment.Id,
                                ApplicationAccountName = Application.ApplicationName + ' ' +  Accounts.AccountName,
                                DepartmentName = Department.Name,
                                LastUpdatedDate = ApplicationDepartment.LastUpdatedDate,
                                IsActive = ApplicationDepartment.IsActive
                            };
            return innerJoin.ToList();
           }


    }
}
