using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop.Blazor.DataTransferObjects;

public class SeatDto
{
  public int Id { get; set; }

  public decimal Price { get; set; }

  public int Row { get; set; }

  public int Number { get; set; }
}

