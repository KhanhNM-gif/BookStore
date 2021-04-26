namespace model2.NewFolder1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public int? IDRootCategory { get; set; }

        [StringLength(500)]
        public string IDCategorys { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [Column(TypeName = "money")]
        public decimal? PromotionPrice { get; set; }

        public bool? IncludeVAT { get; set; }

        public int? IDAuthor { get; set; }

        public int? IDPublishingCompany { get; set; }

        public DateTime? PublicationDate { get; set; }

        public int? DisplayOrder { get; set; }

        public int? Quantity { get; set; }

        public int? QuantitySoled { get; set; }

        [Column(TypeName = "ntext")]
        public string Detail { get; set; }

        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifieldDate { get; set; }

        [StringLength(250)]
        public string ModifileBy { get; set; }

        public bool? Status { get; set; }

        public bool? TopHot { get; set; }

        [StringLength(500)]
        public string Tags { get; set; }
    }
}
