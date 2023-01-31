using System;
using System.Collections.Generic;

namespace FirstTeamCore.Models
{
    public partial class SelfOrder
    {
        public int 自選訂單編號id { get; set; }
        public int? 會員編號 { get; set; }
        public DateTime? 入住時間 { get; set; }
        public DateTime? 退住時間 { get; set; }
        public int? 露營天數 { get; set; }
        public int? 預計人數 { get; set; }
        public int? 營區細項編號 { get; set; }
        public int? 自選飲食 { get; set; }
        public int? 租賃商店 { get; set; }
        public int? 租借總價 { get; set; }
        public int? 自選訂單總價 { get; set; }
        public string? 評論 { get; set; }
        public int? 評分 { get; set; }
        public string? 建立人 { get; set; }
        public DateTime? 建立時間 { get; set; }
        public string? 修改人 { get; set; }
        public DateTime? 修改時間 { get; set; }

        public virtual MemberInfo? 會員編號Navigation { get; set; }
        public virtual CampDetail? 營區細項編號Navigation { get; set; }
        public virtual RentDetail? 租賃商店Navigation { get; set; }
        public virtual SelfFood? 自選飲食Navigation { get; set; }
    }
}
