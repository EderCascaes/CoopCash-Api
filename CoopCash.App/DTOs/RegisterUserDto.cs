using CoopCash.Domain.Enums;

namespace CoopCash.App.DTOs
{
    public record RegisterUserDto(Guid? Id,string Name, string Password, string Role, string[] Permissions, UserType Type );
}
