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
    
    public partial class CycleDate
    {
        public int Id { get; set; }
        public int CycleId { get; set; }
        public System.DateTime DateInCycle { get; set; }
        public string DayName { get; set; }
    
        public virtual Cycle Cycle { get; set; }
    }
}