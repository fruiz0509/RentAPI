using System;
using System.Collections.Generic;

namespace RentAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Pass { get; set; }

    public int? RolId { get; set; }

    public DateTime? Created { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();

    public virtual Role? Rol { get; set; }

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
