using System;
using System.Collections.Generic;

namespace NsbmLesson10_EFDB.Models;

public partial class NsbmMember
{
    public long Id { get; set; }

    public string? NsbmUserName { get; set; }

    public string? NsbmPassword { get; set; }

    public string? NsbmFullName { get; set; }

    public string? NsbmEmail { get; set; }

    public string? NsbmPhone { get; set; }

    public bool? NsbmStartus { get; set; }
}
