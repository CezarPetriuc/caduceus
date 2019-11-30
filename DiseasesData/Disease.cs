using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Linq;

namespace DiseasesData
{
    public class Disease
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        public virtual ICollection<Name> Names { get; private set; }

        public ICollection<string> StringNames
        {
            get => Names.Select(n => n.Value).ToList();
        }

        public Disease()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
