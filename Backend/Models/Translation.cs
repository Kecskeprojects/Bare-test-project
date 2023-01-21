using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Translation
{
    public int Id { get; set; }

    public string English { get; set; } = null!;

    public string Hungarian { get; set; } = null!;

    public string Spanish { get; set; } = null!;

    public string Chinese { get; set; } = null!;

    public string Portugese { get; set; } = null!;
}
