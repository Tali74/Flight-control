export interface IFlightHistory {
  id: number;
  flightId: number;
  enterTime: Date;
  exitTime: Date;
  state: string;
}

// public int Id { get; set; }
// public int FlightId { get; set; }
// public DateTime EnterTime { get; set; }
// public DateTime ExitTime { get; set; }
// public string State { get; set; }
