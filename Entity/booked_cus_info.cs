using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class booked_cus_info
    {
        public int reservation_id { get; set; }
        public int customer_id { get; set; }
        public string customer_first_name { get; set; }
        public string customer_last_name { get; set; }
        public string customer_contact_number { get; set; }
        public DateTime expected_check_in_date { get; set; }
        public int day_stay_number { get; set; }
        public string room_type_name { get; set; }
    }
}
