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

    public partial class Member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Member()
        {
            this.Commodity = new HashSet<Commodity>();
            this.Favourite = new HashSet<Favourite>();
            this.MemberEvaluation = new HashSet<MemberEvaluation>();
            this.MemberReport = new HashSet<MemberReport>();
            this.MessageMapping = new HashSet<MessageMapping>();
            this.MessageReply = new HashSet<MessageReply>();
            this.OrderMapping = new HashSet<OrderMapping>();
            this.Photo = new HashSet<Photo>();
        }

        [DisplayName("會員編號")]
        public string MemID { get; set; }

        [DisplayName("帳號")]
        [Required(ErrorMessage = "帳號為必填欄位")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "帳號的長度需再6~12個字元內！")]
        [RegularExpression(@"[a-zA-Z]+[a-zA-Z0-9]*$", ErrorMessage = "帳號僅能有英文或數字，且開頭需為英文字母！")]
        public string Account { get; set; }

        [DisplayName("密碼")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "密碼的長度需再6~12個字元內！")]
        [RegularExpression(@"[a-zA-Z]+[a-zA-Z0-9]*$", ErrorMessage = "密碼僅能有英文或數字，且開頭需為英文字母！")]
        [Required(ErrorMessage = "密碼為必填欄位")]
        public string Password { get; set; }

        [DisplayName("再次確認密碼")]
        [StringLength(12, MinimumLength = 6, ErrorMessage = "密碼的長度需再6~12個字元內！")]
        [RegularExpression(@"[a-zA-Z]+[a-zA-Z0-9]*$", ErrorMessage = "密碼僅能有英文或數字，且開頭需為英文字母！")]
        [Required(ErrorMessage = "必填欄位")]
        [System.Web.Mvc.Compare("Password", ErrorMessage = "兩次輸入的密碼必須相符！")]
        public string Password2 { get; set; }

        [DisplayName("姓名")]
        [Required(ErrorMessage = "姓名為必填欄位")]
        public string Name { get; set; }

        [DisplayName("電話")]
        [Required(ErrorMessage = "電話為必填欄位")]
        public string Phone { get; set; }

        [DisplayName("地址")]
        [Required(ErrorMessage = "地址為必填欄位")]
        public string Address { get; set; }

        [DisplayName("性別")]
        public string Gender { get; set; }

        [DisplayName("生日")]
        [DataType(DataType.Date, ErrorMessage = "請輸入正確的生日日期")]
        [Required(ErrorMessage = "生日為必填欄位")]
        public System.DateTime Birthday { get; set; }

        [DisplayName("信箱")]
        [Required(ErrorMessage = "信箱為必填欄位")]
        [EmailAddress(ErrorMessage = "信箱格式錯誤")]
        public string E_mail { get; set; }

        [DisplayName("身份證字號")]
        [Required(ErrorMessage = "身份證字號為必填欄位")]
        public string ID { get; set; }
        public Nullable<System.DateTime> InitDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Commodity> Commodity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favourite> Favourite { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberEvaluation> MemberEvaluation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MemberReport> MemberReport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageMapping> MessageMapping { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MessageReply> MessageReply { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderMapping> OrderMapping { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Photo> Photo { get; set; }
    }
}
