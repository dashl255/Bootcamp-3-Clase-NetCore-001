using System;
using System.Collections.Generic;

namespace ERP.CoreDB;

public partial class Impuesto
{
    public short? ImpuestoId { get; set; }

    public string? ImpuestoDescr { get; set; }

    public decimal? ImpuestoValor { get; set; }
}
