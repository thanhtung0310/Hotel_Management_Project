namespace DatabaseProvider
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using System.ComponentModel.DataAnnotations.Schema;
  using System.Data.Entity.Spatial;

  [Table("reservation")]
  public partial class reservation
  {
    [Key]
    public int reservation_id { get; set; }

    public int customer_id { get; set; }

    public DateTime expected_check_in_date { get; set; }

    public int day_stay_number { get; set; }

    public int expected_room_type_id { get; set; }
    [StringLength(50)]
    public string reservation_status { get; set; }
  }
}
