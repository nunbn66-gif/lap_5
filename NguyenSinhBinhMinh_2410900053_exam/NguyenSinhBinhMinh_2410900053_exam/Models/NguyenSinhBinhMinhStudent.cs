using System;
using System.Collections.Generic;

namespace NguyenSinhBinhMinh_2410900053_exam.Models;

public partial class NguyenSinhBinhMinhStudent
{
    public long Id { get; set; }

    public string? NguyenSinhBinhMinhName { get; set; }

    public string? NguyenSinhBinhMinhGender { get; set; }

    public DateTime? NguyenSinhBinhMinhBirthday { get; set; }

    public string? NguyenSinhBinhMinhEmail { get; set; }

    public string? NguyenSinhBinhMinhPhone { get; set; }

    public bool? NguyenSinhBinhMinhActive { get; set; }
}
