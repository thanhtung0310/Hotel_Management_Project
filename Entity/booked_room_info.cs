using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class booked_room_info
    {
        public int reservation_id { get; set; }
        public int customer_id { get; set; }
        public int room_id { get; set; }
        public DateTime expected_check_in_date { get; set; }
        public DateTime expected_check_out_date { get; set; }
    }
}
