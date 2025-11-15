using SchoolProject.Data.Entities;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Service.Abstracts
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentByIDAsync(int id);
        public Task<Student> GetStudentByIDWithInculdeAsync(int id);

        public Task<string> AddAsync(Student student);
        public Task<bool> IsNameExistExcludeSelf(string name, int Id);
        public Task<bool> IsNameExist(string name);
        public Task<string> EditAsync(Student student);
        public Task<string> DeleteAsync(Student student);
        public IQueryable<Student> GetStudentsQuerable();
        public IQueryable<Student> GetStudentsByDepartmentIDQuerable(int DID);
        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum oerderingEnum, string search);


    }
}
