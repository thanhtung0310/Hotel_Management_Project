using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public class cus_info
  {
    [Required]
    public int customer_id { get; set; }
    [Required]
    public string customer_first_name { get; set; }
    [Required]
    public string customer_last_name { get; set; }
    [Required]
    public string customer_address { get; set; }
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string customer_contact_number { get; set; }
  }
}
