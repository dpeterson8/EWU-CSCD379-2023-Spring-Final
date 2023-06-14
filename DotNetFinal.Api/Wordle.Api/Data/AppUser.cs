using Microsoft.AspNetCore.Identity;
namespace Wordle.Api.Data;

public class AppUser : IdentityUser
{
    public required string Name { get; set; }
    public ICollection<Scores> Scores { get; set; } = null!;

}