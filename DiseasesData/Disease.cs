using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DiseasesData
{
    public class Disease
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        public string StringName
        {
            get => this.StringNames.First();
        }
        
        public virtual ICollection<Name> Names { get; private set; }

        public ICollection<string> StringNames
        {
            get => Names?.Select(n => n.Value.Trim()).ToList();
        }

        public Disease()
        {
            this.Id = Guid.NewGuid();
        }
    }
}
