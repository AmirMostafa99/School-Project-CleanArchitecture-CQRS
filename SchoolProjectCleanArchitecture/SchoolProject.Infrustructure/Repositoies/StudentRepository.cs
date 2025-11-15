using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrustructure.Abstracts;
using SchoolProject.Infrustructure.Data;
using SchoolProject.Infrustructure.InfrustructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Repositoies
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        #region Fileds

        private readonly DbSet<Student> _students;

        #endregion

        #region Constracor
        public StudentRepository(ApplicationDBContext dBContext):base(dBContext)
        {
            _students = dBContext.Set<Student>();
        }

        #endregion

        #region Handels Funcitons
        public Task<List<Student>> GetStudentsListAsync()
         {
           return _students.Include(x=>x.Department).ToListAsync();
        }
        #endregion
    }
}
