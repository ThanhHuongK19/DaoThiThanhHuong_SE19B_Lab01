
namespace BusinessObjects.Models;

public partial class AccountMember
{
    public string? MemberId { get; set; }

    public string MemberPassword { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public int MemberRole { get; set; }
}
