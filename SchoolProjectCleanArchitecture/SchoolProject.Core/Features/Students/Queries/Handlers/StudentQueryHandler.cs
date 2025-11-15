using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.Students.Queries.Models;
using SchoolProject.Core.Features.Students.Queries.Results;
using SchoolProject.Core.Resources;
using SchoolProject.Core.Wrappers;
using SchoolProject.Data.Entities;
using SchoolProject.Service.Abstracts;
using System.Linq.Expressions;
using GetStudentListResponse = SchoolProject.Core.Features.Students.Queries.Results.GetStudentListResponse;


namespace SchoolProject.Core.Features.Students.Queries.Handlers
{
    public class StudentHandler : ResponseHandler,
         IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
         IRequestHandler<GetStudentByIDQuery, Response<GetSingleStudentResponse>>,
         IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>

    {
        #region Fileds
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringlocalizer;
        #endregion

        #region Constractor
        public StudentHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> stringlocalizer)
            : base(stringlocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringlocalizer = stringlocalizer;
        }
        #endregion

        #region Handele Funcation 
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentsListAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
            var result = Success(studentListMapper);
            result.Meta = new { count = studentListMapper.Count() };
            return result;
        }

        public async Task<Response<GetSingleStudentResponse>> Handle(GetStudentByIDQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentService.GetStudentByIDWithInculdeAsync(request.Id);
            if (student == null)
            {
                return NotFound<GetSingleStudentResponse>(_stringlocalizer[SharedResourcesKeys.NotFound]);
            }
            var result = _mapper.Map<GetSingleStudentResponse>(student);
            return Success(result);
        }

        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudentID, e.Localize(e.NameAr, e.NameEn), e.Address, e.Department.Localize(e.Department.DNameAr, e.Department.DNameEn));
            // var querable = _studentService.GetStudentsQuerable();
            var FilterQuery = _studentService.FilterStudentPaginatedQuerable(request.OrderBy, request.Search);
            var PaginatedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            PaginatedList.Meta = new { count = PaginatedList.Data.Count() };
            return PaginatedList;
        }
        #endregion 
    }
}
