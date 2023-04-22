using System;
using System.Collections.Generic;

namespace RentAPI.Models;

public partial class Rent
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? VisitId { get; set; }

    public DateTime? RentStartDate { get; set; }

    public DateTime? RentEndDate { get; set; }

    public TimeSpan? RentStartHour { get; set; }

    public TimeSpan? RentEndHour { get; set; }

    public decimal? Amount { get; set; }

    public string? Comments { get; set; }

    public DateTime? Created { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public int? ModifiedBy { get; set; }

    public virtual User? User { get; set; }

    public virtual Visit? Visit { get; set; }
}
