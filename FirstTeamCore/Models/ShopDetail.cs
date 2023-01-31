using System;
using System.Collections.Generic;

namespace FirstTeamCore.Models
{
    public partial class ShopDetail
    {
        public int 訂單編號 { get; set; }
        public int? 購物商店id { get; set; }
        public int? 會員編號 { get; set; }
        public string? 成立時間 { get; set; }
        public string? 細項 { get; set; }
        public int? 總價 { get; set; }
        public string? 購物評價 { get; set; }
        public int? 購物評分 { get; set; }
        public string? 建立人 { get; set; }
        public DateTime? 建立時間 { get; set; }
        public string? 修改人 { get; set; }
        public DateTime? 修改時間 { get; set; }

        public virtual MemberInfo? 會員編號Navigation { get; set; }
        public virtual Shop? 購物商店 { get; set; }
    }
}
