using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Request
{
    public int Code { get; set; }

    public string PersonId { get; set; } = null!;

    public string? Book { get; set; }

    public string Subject { get; set; } = null!;

    public string? Mode { get; set; }

    public int? ChavrutaCode { get; set; }

    public virtual Offer? ChavrutaCodeNavigation { get; set; }

    public virtual Person Person { get; set; } = null!;
}
