//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MemeAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class upvote
    {
        public int postid { get; set; }
        public int userid { get; set; }
        public int id { get; set; }
    
        public virtual post post { get; set; }
        public virtual user user { get; set; }
    }
}