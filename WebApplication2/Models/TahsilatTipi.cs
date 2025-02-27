﻿using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class TahsilatTipi
{
    public int TahsilatTipiId { get; set; }

    public string TahilatTipi { get; set; } = null!;

    public virtual ICollection<Tahsilat> Tahsilats { get; } = new List<Tahsilat>();
}
