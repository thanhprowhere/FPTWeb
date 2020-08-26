namespace Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Topic")]
    public partial class Topic
    {
        public long ID { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        public long? IdCourse { get; set; }

        public virtual Course Course { get; set; }
    }
}
