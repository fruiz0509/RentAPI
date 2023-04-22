using System;
using System.Collections.Generic;

namespace RentAPI.Models;

public partial class Payment
{
    public int Id { get; set; }

    public decimal? Paid { get; set; }

    public int? RentId { get; set; }

    public DateTime? Created { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? Modified { get; set; }

    public int? ModifiedBy { get; set; }
}
