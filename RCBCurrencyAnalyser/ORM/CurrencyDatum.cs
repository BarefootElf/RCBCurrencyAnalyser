using System;
using System.Collections.Generic;

namespace RCBCurrencyAnalyser.ORM;

public partial class CurrencyDatum
{
    public DateOnly Date { get; set; }

    public string CurrencyId { get; set; } = null!;

    public int NumCode { get; set; }

    public string CharCode { get; set; } = null!;

    public int Nominal { get; set; }

    public string Name { get; set; } = null!;

    public float Value { get; set; }

    public long Id { get; set; }

    public virtual Currency Currency { get; set; } = null!;
}
