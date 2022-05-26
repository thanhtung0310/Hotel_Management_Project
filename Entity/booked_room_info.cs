using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public class booked_room_info
  {
    public int room_id { get; set; }
    public string room_type_name { get; set; }
    public DateTime expected_check_in_date { get; set; }
    public DateTime expected_check_out_date { get; set; }
    public string customer_full_name { get; set; }
    public string customer_contact_number { get; set; }
  }
}
