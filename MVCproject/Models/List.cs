//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCproject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class List
    {
        public int ID { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int Page { get; set; }
        public string Type { get; set; }
        public bool IsRead { get; set; }
    }
}