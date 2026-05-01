using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectName.Models
{
    [Table("vehicle")]
    public partial class Vehicle
    {
        [Key]
        [Column("vin")]
        public string VIN { get; set; }

        [Column("user_id")]
        public string UserID {get;set;}

        [Column("model_year")]
        public int ModelYear { get; set; }

        [Column("colour")]
        public string Colour { get; set; }

        [Column("manufacturer")]
          public string Manufacturer { get; set; }
      
        [Column("model")]
          public string Model { get; set; }

        [Column("purchase_date")]
        public DateOnly PurchaseDate {get; set;}

        [Column("sale_date")]
        public DateOnly SaleDate {get; set;}
    }
}