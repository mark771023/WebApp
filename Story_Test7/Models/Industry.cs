//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Story_Test7.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Industry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Industry()
        {
            this.AccountsMapping = new HashSet<AccountsMapping>();
        }
    
        public string IndustryID { get; set; }
        public string IndustryName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string ContactPhone { get; set; }
        public string E_mail { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountsMapping> AccountsMapping { get; set; }
    }
}
