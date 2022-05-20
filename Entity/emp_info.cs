using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public class emp_info
  {
    [Required]
    public int emp_id { get; set; }
    [Required]
    public string emp_name { get; set; }
    [Required]
    public string acc_username { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string acc_password { get; set; }
    [Required]
    public int role_id { get; set; }
    [Required]
    public string emp_position { get; set; }
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime emp_dob { get; set; }
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string emp_contact_number { get; set; }
  }
}
