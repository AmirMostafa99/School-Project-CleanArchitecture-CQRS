using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Bases;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Data.Entities.Identity;

namespace SchoolProject.Core.Features.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler,
         IRequestHandler<AddUserCommand, Response<string>>

    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _sharedResources;
        private readonly UserManager<User> _userManager;

        #endregion

        #region Constructors
        public UserCommandHandler(IStringLocalizer<SharedResources> stringLocalizer,
                                  IMapper mapper,
                                  UserManager<User> userManager) : base(stringLocalizer)

        {
            _mapper = mapper;
            _sharedResources = stringLocalizer;
            _userManager = userManager;

        }
        #endregion

        #region Handle Functions
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            // if email is exist 
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                return BadRequest<string>(_sharedResources[SharedResourcesKeys.EmailIsExist]);
            }
            // if username is exist
            var userName = await _userManager.FindByNameAsync(request.UserName);
            if (userName != null)
            {
                return BadRequest<string>(_sharedResources[SharedResourcesKeys.UserNameIsExist]);
            }
            // mapping
            var identityUser = _mapper.Map<User>(request);

            // create user
            var result = await _userManager.CreateAsync(identityUser, request.Password);

            // check result
            if (!result.Succeeded)
            {
                return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            }

            return Created("");
        }

        #endregion
    }
}
