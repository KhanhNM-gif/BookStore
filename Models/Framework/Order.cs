namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int ID { get; set; }

        public DateTime? CreateDate { get; set; }

        public int? CustomerID { get; set; }

        [Column(TypeName = "ntext")]
        public string Note { get; set; }

        [StringLength(250)]
        public string ShipEmail { get; set; }

        [StringLength(250)]
        public string ShipName { get; set; }

        [StringLength(20)]
        public string ShipMobile { get; set; }

        [StringLength(250)]
        public string ShipAddress { get; set; }

        public bool? Status { get; set; }
    }
}
