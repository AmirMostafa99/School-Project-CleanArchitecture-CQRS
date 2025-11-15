using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Department.Queries.Models;
using SchoolProject.Core.Features.Department.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System.Linq.Expressions;

namespace SchoolProject.Core.Features.Department.Queries.Handlers
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetDepartmentByIDQuery, Response<GetDepartmentByIDResponse>>
    {

        #region Fields
        private readonly IStringLocalizer<SharedResources> _stringlocalizer;
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        #endregion


        #region Constructor
        public DepartmentQueryHandler(IStringLocalizer<SharedResources> stringlocalizer,
                                        IDepartmentService departmentService,
                                        IMapper mapper,
                                        IStudentService studentService) : base(stringlocalizer)
        {
            _departmentService = departmentService;
            _stringlocalizer = stringlocalizer;
            _mapper = mapper;
            _studentService = studentService;
        }
        #endregion

        #region Handle Functions
        public async Task<Response<GetDepartmentByIDResponse>> Handle(GetDepartmentByIDQuery request, CancellationToken cancellationToken)
        {
            // TODO: Implement the logic to get department by ID
            // service get by id include manager, students, subjects, instructors
            var response = await _departmentService.GetDepartmentById(request.Id);

            // check is not exist 
            if (response == null)
            {
                return NotFound<GetDepartmentByIDResponse>(_stringlocalizer[SharedResourcesKeys.NotFound]);
            }
            // Mapping
            var mapper = _mapper.Map<GetDepartmentByIDResponse>(response);
            //pagination
            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.StudentID, e.Localize(e.NameAr, e.NameEn));
            var studentQuerable = _studentService.GetStudentsByDepartmentIDQuerable(request.Id);
            var PaginatedList = await studentQuerable.Select(expression).ToPaginatedListAsync(request.StudentPageNumber, request.StudentPageSize);
            mapper.StudentList = PaginatedList;
            // return success response
            return Success(mapper);
        }
        #endregion
    }
}
