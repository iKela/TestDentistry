namespace Dentistry.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Number { get; set; }

        public string Adress { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public byte[] Photo { get; set; }

        public int? Policy_PolicyId { get; set; }

        public virtual Policies Policies { get; set; }
    }
}
