//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class option_choices
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public option_choices()
        {
            this.answers = new HashSet<answers>();
        }
    
        public int Id { get; set; }
        public int Question_id { get; set; }
        public string Option_choices_name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<answers> answers { get; set; }
        public virtual questions questions { get; set; }
    }
}