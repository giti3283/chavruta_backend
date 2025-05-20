using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Schedule
{
    public int Code { get; set; }

    public string DayInWeek { get; set; } = null!;

    public TimeSpan FromTime { get; set; }

    public TimeSpan ToTime { get; set; }

    public bool? Available { get; set; }

    public string PersonId { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
