using Core.Exceptions.User.Create;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Core.Features.Commands.User.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        readonly UserManager<Entities.Concreate.Identity.User> userManager;

        public CreateUserCommandHandler(UserManager<Entities.Concreate.Identity.User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult identityResult =  await userManager.CreateAsync(new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Age = request.Age,
            }, request.Password);

            if(identityResult.Succeeded)
            {
                return new()
                {
                    Succeeded = true,
                    Message = "Kullanıcı başarılı bir şekilde oluşturulmuştur."
                };
            }

            throw new UserCreateFailedException("Kullanıcı oluşturma sırasında bir sorun ile karşılaşıldı.");
        }
    }
}
