using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class emp_info
    {
        public int emp_id { get; set; }
        public string emp_name { get; set; }
        public string acc_username { get; set; }
        public string acc_password { get; set; }        
        public int role_id { get; set; }
        public string emp_position { get; set; }
        public DateTime emp_dob { get; set; }
        public string emp_contact_number { get; set; }
    }
}
