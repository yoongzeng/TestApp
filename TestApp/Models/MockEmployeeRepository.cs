﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class MockEmployeeRepository: EmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = 
                new List<Employee>() {
                    new Employee() { Id = 1, Name = "Mary", Department = Dept.HR, Email = "mary@pragimtech.com" },
                    new Employee() { Id = 2, Name = "John", Department = Dept.IT, Email = "john@pragimtech.com" },
                    new Employee() { Id = 3, Name = "Sam", Department = Dept.IT, Email = "sam@pragimtech.com" }, };
        }
        public Employee GetEmployee(int Id)
        {
            return this._employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

     
        public Employee Delete(int Id)
        {
            Employee employee =
                this._employeeList.FirstOrDefault(e => e.Id == Id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public Employee Update(int Id, Employee employeeChanges)
        {
            Employee employee =
                this._employeeList.FirstOrDefault(e => e.Id == Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
            }
            return employeeChanges;
        }


    }


}
