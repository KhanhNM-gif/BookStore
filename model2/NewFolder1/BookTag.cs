namespace model2.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookTag")]
    public partial class BookTag
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Tag { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDBook { get; set; }
    }
}
