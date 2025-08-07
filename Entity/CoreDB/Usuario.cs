using System;
using System.Collections.Generic;

namespace Entity.CoreDB;

public partial class Usuario
{
    public int UsuId { get; set; }

    public string? UsuNombre { get; set; }

    public int? EmpresaId { get; set; }

    public int? Estado { get; set; }

    public string? FechaHoraReg { get; set; }

    public string? FechaHoraAct { get; set; }

    public int? UsuIdReg { get; set; }

    public int? UsuIdAct { get; set; }

    public string Clave { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<MovimientoCab> MovimientoCabs { get; set; } = new List<MovimientoCab>();

    public virtual ICollection<UsuarioPermiso> UsuarioPermisos { get; set; } = new List<UsuarioPermiso>();

    public virtual ICollection<UsuarioRol> UsuarioRols { get; set; } = new List<UsuarioRol>();
}
