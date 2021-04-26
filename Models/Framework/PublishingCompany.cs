namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PublishingCompany")]
    public partial class PublishingCompany
    {
        public int? ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        public string CreateBy { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? ModifieldDate { get; set; }

        [StringLength(250)]
        public string ModifileBy { get; set; }

        public bool? Status { get; set; }
    }
}
