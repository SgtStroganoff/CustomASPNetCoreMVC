using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CustomASPNetCoreMVC.Areas.Identity.Data;

public class AppUser : IdentityUser
{
    [ProtectedPersonalData]
    public override string? UserName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(50)")]
    public required string FirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(50)")]
    public required string LastName { get; set; }

    [ProtectedPersonalData]
    public override string? Email { get; set; }

    [ProtectedPersonalData]
    public override string? PhoneNumber { get; set; }

    public int UsernameChangeLimit { get; set; } = 10;

    public byte[]? ProfilePicture { get; set; }
}

