﻿using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class SiparisDurumu
{
    public int SiparisDurumuId { get; set; }

    public string SiparisDurumu1 { get; set; } = null!;

    public virtual ICollection<Sipari> Siparis { get; } = new List<Sipari>();
}
