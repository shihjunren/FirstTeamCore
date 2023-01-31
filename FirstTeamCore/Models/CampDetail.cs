using System;
using System.Collections.Generic;

namespace FirstTeamCore.Models
{
    public partial class CampDetail
    {
        public CampDetail()
        {
            SelfOrders = new HashSet<SelfOrder>();
            SetOrderDetails = new HashSet<SetOrderDetail>();
        }

        public int 營區細項編號 { get; set; }
        public int? 營區編號 { get; set; }
        public int? 活動編號 { get; set; }
        public int? 項目id { get; set; }
        public string? 詳細內容 { get; set; }
        public string? 圖片 { get; set; }
        public int? 單價 { get; set; }
        public string? 建立人 { get; set; }
        public DateTime? 建立時間 { get; set; }
        public string? 修改人 { get; set; }
        public DateTime? 修改時間 { get; set; }

        public virtual ActDetail? 活動編號Navigation { get; set; }
        public virtual Camp? 營區編號Navigation { get; set; }
        public virtual CampStyle? 項目 { get; set; }
        public virtual ICollection<SelfOrder> SelfOrders { get; set; }
        public virtual ICollection<SetOrderDetail> SetOrderDetails { get; set; }
    }
}
