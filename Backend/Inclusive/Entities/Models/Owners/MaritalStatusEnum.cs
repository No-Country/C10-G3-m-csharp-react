using System.ComponentModel;

namespace Entities.Models.Owners;

public enum MaritalStatusEnum
{
    [Description("Soltero/a")]
    Soltero,
    [Description("Casado/a")]
    Casado,
    [Description("Divorciado/a")]
    Divorciado,
    [Description("Viudo/a")]
    Viudo,
    [Description("Separado/a")]
    Separado,
    [Description("Union Libre")]
    UnionLibre
}

/*
 Married,
 Single,
 Divorced,
 Widowed,
 Separated,
 Other
 * 
  Casado,
  Soltero,
  Divorciado,
  Viudo,
  Apartado,
  Otro
 * 
Soltero/a
Casado/a
Divorciado/a
Viudo/a
Separado/a
Union libre

Comprometido/a
Anulado/a
Separado/a judicialmente
Casado/a por lo civil y por la iglesia
 */