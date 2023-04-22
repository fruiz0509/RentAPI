using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
    [JsonIgnore]
    public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();
    [JsonIgnore]
    public virtual Role? Rol { get; set; }
    [JsonIgnore]
    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
}
