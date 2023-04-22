using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RentAPI.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Rol { get; set; }

    public DateTime? Created { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public int? ModifiedBy { get; set; }
    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
