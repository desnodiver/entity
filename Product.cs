//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp5
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public string About { get; set; }
        public int Price { get; set; }
        public Nullable<int> IsAvailable { get; set; }
        public string Description { get; set; }
    
        public virtual category category { get; set; }
    }
}