//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VirusHackServerLib
{
    using System;
    using System.Collections.Generic;
    
    public partial class Research
    {
        public int ResearchId { get; set; }
        public int UserId { get; set; }
        public string ResearchName { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string ResearchResult { get; set; }
    
        public virtual UserProfile UserProfile { get; set; }
    }
}
