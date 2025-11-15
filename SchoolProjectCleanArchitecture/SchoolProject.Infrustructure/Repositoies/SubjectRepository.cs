using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrustructure.Abstracts;
using SchoolProject.Infrustructure.Data;
using SchoolProject.Infrustructure.InfrustructureBases;

namespace SchoolProject.Infrustructure.Repositoies
{
    public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
    {
        #region Fields
        private DbSet<Subject> subjects;
        #endregion

        #region Constructors
        public SubjectRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            subjects = dbContext.Set<Subject>();
        }
        #endregion

        #region Handle Functions

        #endregion
    }
}
