namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    [Serializable]
    public partial class Account
    {
        [Key]
        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(250)]
        public string Password { get; set; }

        [StringLength(250),NotMapped]
        public string ConfirmPassword { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public bool? Gender { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        public DateTime? Birthday { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool? Status { get; set; }
    }
}
