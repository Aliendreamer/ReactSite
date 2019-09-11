using AcademyData;
using AcademyModels;
using Microsoft.AspNetCore.Identity;

namespace DomainUtility.Factories
{
    public class CommandHandlerFactory:ICommandHandlerFactory
    {
        private readonly AcademyDbContext _context;
        private readonly UserManager<AcademyUser> _userManager;
        private readonly RoleManager<AcademyRole> _roleManager;


        public CommandHandlerFactory(AcademyDbContext context,
                                    UserManager<AcademyUser>userManager,
                                    RoleManager<AcademyRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
      
            //public static ICommandHandler<SaveWidgetCommand, CommandResponse> Build(SaveWidgetCommand command)
            //{
            //    return new SaveWidgetCommandHandler(command);
            //}
        
    }
}
