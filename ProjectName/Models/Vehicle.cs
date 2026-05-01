using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectName.Models
{
    [Table("vehicle")]
    public partial class Vehicle
    {
        [Key]
        [Column("vin")]
        [StringLength(17, MinimumLength = 17)]
        public string VIN { get; set; }

        [Column("user_id")]
        public string UserID {get;set;}

        [Column("model_year")]
        [Range(1900,2050)]
        public int ModelYear { get; set; }

        [Column("colour")]
        [StringLength(50, MinimumLength =3)]
        public string Colour { get; set; }

        [Column("manufacturer")]
        [StringLength(50, MinimumLength =3)]
        [RegularExpression("^[a-zA-Z0-9 -]+$")]
          public string Manufacturer { get; set; }
      
        [Column("model")]
                [StringLength(50, MinimumLength =1)]
          public string Model { get; set; }

        [Column("purchase_date")]
        public DateOnly PurchaseDate {get; set;}

        [Column("sale_date")]
        public DateOnly? SaleDate {get; set;}
    }
}