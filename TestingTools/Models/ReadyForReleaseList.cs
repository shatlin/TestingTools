//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Testing.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ReadyForReleaseList
    {
        public ReadyForReleaseList()
        {
            this.Allocations = new HashSet<Allocation>();
        }
    
        public int Id { get; set; }
        public string ReadyForReleaseValue { get; set; }
        public string ReadyForReleaseDescription { get; set; }
    
        public virtual ICollection<Allocation> Allocations { get; set; }
    }
}
