namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Enrollment")]
    public partial class Enrollment
    {
        public long ID { get; set; }

        public long? IdUser { get; set; }

        public long? IdCourse { get; set; }

        public virtual Course Course { get; set; }

        public virtual User User { get; set; }
    }
}
