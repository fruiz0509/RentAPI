using System;
using System.Collections.Generic;

namespace RentAPI.Models;

public partial class Visit
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? VisitDate { get; set; }

    public TimeSpan? VisitHour { get; set; }

    public DateTime? Created { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();

    public virtual User? User { get; set; }
}
