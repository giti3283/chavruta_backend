using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Person
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string Gender { get; set; } = null!;

    public string Status { get; set; } = null!;

    public string CellularTelephone { get; set; } = null!;

    public string? Telephone { get; set; }

    public string Country { get; set; } = null!;

    public string? City { get; set; }

    public string? Email { get; set; }

    public string Role { get; set; } = null!;

    public string? Denomination { get; set; }

    public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
