namespace DatabaseProvider
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("account")]
  public partial class account
  {
    [Key]
    public int acc_id { get; set; }

    public int? emp_id { get; set; }

    [StringLength(60)]
    public string acc_username { get; set; }

    [StringLength(60)]
    public string acc_password { get; set; }

    public int? role_id { get; set; }
    [StringLength(300)]
    public string acc_session { get; set; }
  }
}
