using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public class room_check_in
  {
    public int customer_id { get; set; }
    public int room_id { get; set; }
    public int room_type_id { get; set; }
    public DateTime check_in_date { get; set; }
    public DateTime expected_check_out_date { get; set; }
  }
}
