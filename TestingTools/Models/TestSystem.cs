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
    
    public partial class TestSystem
    {
        public TestSystem()
        {
            this.DownTimes = new HashSet<DownTime>();
            this.TestCases = new HashSet<TestCas>();
            this.TestCases1 = new HashSet<TestCas>();
            this.TestCases2 = new HashSet<TestCas>();
            this.TestCases3 = new HashSet<TestCas>();
        }
    
        public int Id { get; set; }
        public string SystemName { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<DownTime> DownTimes { get; set; }
        public virtual ICollection<TestCas> TestCases { get; set; }
        public virtual ICollection<TestCas> TestCases1 { get; set; }
        public virtual ICollection<TestCas> TestCases2 { get; set; }
        public virtual ICollection<TestCas> TestCases3 { get; set; }
    }
}
