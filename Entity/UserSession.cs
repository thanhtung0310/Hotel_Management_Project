using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
  public class UserSession
  {
    // to passing data between views/controllers

    [Required]
    public string acc_username { get; set; }
    
    [NotMapped]
    [DataType(DataType.Password)]
    public string acc_password { get; set; }

    //[NotMapped] // Does not effect the database
    //[Compare("acc_password")]
    //[DataType(DataType.Password)]
    //public string acc_new_password { get; set; }

    //[NotMapped] // Does not effect the database
    //[Compare("acc_new_password")]
    //[DataType(DataType.Password)]
    //public string acc_new_password2 { get; set; }

    public string acc_name { get; set; }
    public int acc_identity_code { get; set; }

    [NotMapped]
    public string acc_role { get; set; }
    [NotMapped]
    [DataType(DataType.DateTime)]
    public DateTime acc_dob { get; set; }
    [NotMapped]
    [DataType(DataType.PhoneNumber)]
    public string acc_contact_number { get; set; }

    [NotMapped]
    public string acc_session { get; set; }
  }
}
