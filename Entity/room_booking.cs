using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public class room_booking
  {
    public int customer_id { get; set; }
    public DateTime expected_check_in_date { get; set; }
    public int day_stay_number { get; set; }
    public int room_type_id { get; set; }
    public int? payment_type_id { get; set; }
    public decimal? payment_amount { get; set; }
    public DateTime? payment_date { get; set; }
    public DateTime? expected_check_out_date { get; set; }
  }
}
