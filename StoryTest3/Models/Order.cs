//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace StoryTest3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.AccountsMapping = new HashSet<AccountsMapping>();
            this.OrderMapping = new HashSet<OrderMapping>();
        }

        [DisplayName("訂單編號")]
        public string OrdID { get; set; }

        [DisplayName("訂單金額")]
        [Required(ErrorMessage = "請輸入金額")]
        [Range(1, 9999, ErrorMessage = "請輸入1-9999之內的金額")]

        public decimal OrdAmount { get; set; }

        [DisplayName("訂單數量")]
        [Required(ErrorMessage = "請輸入數量")]
        [Range(1, 999, ErrorMessage = "請輸入1-999之內的數量")] 
        public string OrdTotal { get; set; }

        [DisplayName("運送方式")]
        [Required(ErrorMessage = "請輸入正確的運送方式：海運ˋ陸運ˋ空運等")]

        public string Transport { get; set; }

        [DisplayName("下訂日期")]
        //[Required(ErrorMessage = "請輸入正確的格式：年/月/日")]
        //[DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public System.DateTime OrdDate { get; set; }

        //public Nullable<System.DateTime> InitDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountsMapping> AccountsMapping { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderMapping> OrderMapping { get; set; }
    }
}