using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Web.Mvc.Authorization;
using Final1.Authorization;
using Final1.Authorization.Roles;
using Final1.Roles;
using Final1.Users;
using Final1.Web.Models.UserProfile;

namespace Final1.Web.Controllers
{
   // [AbpMvcAuthorize(PermissionNames.Pages_Users)]
   [AbpMvcAuthorize]
    public class UsersController : Final1ControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IRoleAppService _roleAppService;
        public UsersController(IRoleAppService roleAppService,IUserAppService userAppService)
        {
            _roleAppService = roleAppService;

            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index()
        {
            var output = await _userAppService.GetUsers();
            //ListResultDto<UserProfileViewModel> uListResultDto = new ListResultDto<UserProfileViewModel>();
            List<UserProfileViewModel> uListResultDto = new List<UserProfileViewModel>();

            foreach (var p in output.Items)
            {
               // uListResultDto.Items  p.MapTo<UserProfileViewModel>(); //todo ask qustion
               uListResultDto.Add(p.MapTo<UserProfileViewModel>());
            }
            return View(uListResultDto);
        }

        public IEnumerable<SelectListItem> UserRolesSelectList()
        {
            IQueryable<Role> roles = _roleAppService.GetAllRoles().Result;
            return roles.Select(x => new SelectListItem {Value = x.Id.ToString(), Text = x.Name});
            //return _stateAppService.GetSimpleList().Select(p => new SelectListItem { Value = p.StateAbbreviation, Text = p.Name }).ToList().AsEnumerable();
        }

        public async Task<ActionResult> UserProfile()
        {
            //await EmailConfirmation();
            UserProfileViewModel model = (await _userAppService.GetUserProfileAsync(AbpSession.UserId.Value)).MapTo<UserProfileViewModel>();
            return View(model);
        }
    }
}