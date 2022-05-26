using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public class checked_cus_info
  {
    public int customer_id { get; set; }
    public string customer_first_name { get; set; }
    public string customer_last_name { get; set; }
    public string customer_contact_number { get; set; }
    public string room_number { get; set; }
    public string room_type_name { get; set; }
    public string room_status_name { get; set; }
    public DateTime check_in_date { get; set; }
    public DateTime expected_check_out_date { get; set; }
  }
}
