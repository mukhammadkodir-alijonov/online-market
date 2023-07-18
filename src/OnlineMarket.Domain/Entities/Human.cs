using OnlineMarket.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.Domain.Entities;
public abstract class Human : Auditable
{
    [Required]
    public string FirstName { get; set; } = String.Empty;

    public string LastName { get; set; } = String.Empty;

    public string? ImagePath { get; set; }

    public string Description { get; set; } = String.Empty;

    public string Email { get; set; } = String.Empty;

    public bool EmailConfirmed { get; set; } = false;

    public string PhoneNumber { get; set; } = String.Empty;

    public bool PhoneNumberConfirmed { get; set; } = false;
}
