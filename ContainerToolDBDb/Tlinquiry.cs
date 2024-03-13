﻿using ContainerToolDB;
using System;
using System.Collections.Generic;

namespace ContainerToolDBDb;

public partial class Tlinquiry
{
    public int Id { get; set; }
    public string Sped { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string AcceptingPort { get; set; } = null!;
    public DateTime? ExpectedRetrieveWeek { get; set; }
    public DateTime? InvoiceOn { get; set; }
    public DateTime? RetrieveDate { get; set; }
    public string RetrieveLocation { get; set; } = null!;
    public int SCGeneral { get; set; }
    public int SCMainRun { get; set; }
    public int SCTrail { get; set; }
    public string PortOfDeparture { get; set; } = null!;
    public DateTime? Ets { get; set; }
    public DateTime? Eta { get; set; }
    public string Boat { get; set; } = null!;
    public bool ApprovedByCrTl { get; set; }
    public DateTime? ApprovedByCrTlTime { get; set; }
    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
