//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace STORY_New.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccountsMapping
    {
        public string ActID { get; set; }
        public string OrdID { get; set; }
        public string IndustryID { get; set; }
        public System.DateTime TransactionTime { get; set; }
    
        public virtual Accounts Accounts { get; set; }
        public virtual Industry Industry { get; set; }
        public virtual Order Order { get; set; }
    }
}
