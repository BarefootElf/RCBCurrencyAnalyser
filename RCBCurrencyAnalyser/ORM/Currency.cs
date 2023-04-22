using System;
using System.Collections.Generic;

namespace RCBCurrencyAnalyser.ORM;

public partial class Currency
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? EngName { get; set; }

    public int Nominal { get; set; }

    public string ParentCode { get; set; } = null!;
}
