using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Offer
{
    public int Code { get; set; }

    public string PersonId { get; set; } = null!;

    public string? Book { get; set; }

    public string Subject { get; set; } = null!;

    public string? Mode { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
}
