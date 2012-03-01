using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Castle.ActiveRecord;

namespace WindowsFormsApplication1
{
    [ActiveRecord("Teams")]
    public class Team : ActiveRecordBase<Team>
    {
        public Team()
        {
            Members = new List<Member>();
        }

        [PrimaryKey]
        public int Id { get; set; }

        [Property("TeamName")]
        public string Name { get; set; }

        [Property]
        public string Description { get; set; }

        [HasMany(//Inverse = true,
                 Lazy = true,
                 Cascade = ManyRelationCascadeEnum.AllDeleteOrphan)]
        public virtual IList<Member> Members { get; set; }
    }

    [ActiveRecord("Members")]
    public class Member : ActiveRecordBase<Member>
    {
        [PrimaryKey]
        public int Id { get; set; }

        [Property]
        public string FirstName { get; set; }

        [Property]
        public string Lastname { get; set; }

        [Property]
        public string Address { get; set; }

        [BelongsTo("TeamId")]
        public Team Team { get; set; }
    }
}
