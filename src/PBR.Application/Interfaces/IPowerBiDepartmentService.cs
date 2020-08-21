using PBR.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PBR.Application.Interfaces
{
  public interface IPowerBiDepartmentService
    {
        Task<IEnumerable<DepartmentModel>> GetDepartmentList();

    }
}
