﻿using SchoolManagement.Data.Entities;

namespace SchoolManagement.Service.Interfaces
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentByIdAsync(int id);
    }
}
