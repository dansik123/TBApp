//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZapTS.WebApi
{
    using System;
    using System.Collections.Generic;
    
    public partial class LogIn
    {
        public long Id { get; set; }
        public Nullable<long> UserId { get; set; }
        public string SessionId { get; set; }
        public Nullable<System.DateTime> SessionTimeOut { get; set; }
    
        public virtual Users Users { get; set; }
    }
}