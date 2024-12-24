//using Employees.model;
//using Microsoft.EntityFrameworkCore;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Employees.data
//{
//    public class EmployeeRepository : IEmployeeRepository
//    {
//        private readonly EmployeesDbContext _context;

//        public EmployeeRepository(EmployeesDbContext context)
//        {
//            _context = context;
//        }

//      //  public async Task<IEnumerable<employees>> GetAllEmployees()
//        {
//            return await _context.employees.ToListAsync();
//        }

//        public async Task<employees> GetEmployeeById(int id)
//        {
//            return await _context.employees.FindAsync(id);
//        }

//        public async Task<employees> CreateEmployee(employees employee)
//        {
//            _context.employees.Add(employee);
//            await _context.SaveChangesAsync();
//            return employee;
//        }

//        public async Task<bool> UpdateEmployee(employees employee)
//        {
//            try
//            {
//                _context.Entry(employee).State = EntityState.Modified;
//                await _context.SaveChangesAsync();
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        public async Task<bool> DeleteEmployee(int id)
//        {
//            var employee = await _context.employees.FindAsync(id);
//            if (employee == null) return false;

//            _context.employees.Remove(employee);
//            await _context.SaveChangesAsync();
//            return true;
//        }
//    }
//}
