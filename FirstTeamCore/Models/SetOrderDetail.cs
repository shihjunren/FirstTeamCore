﻿using System;
using System.Collections.Generic;

namespace FirstTeamCore.Models
{
    public partial class SetOrderDetail
    {
        public SetOrderDetail()
        {
            SetOrders = new HashSet<SetOrder>();
        }

        public int 套裝行程id { get; set; }
        public int? 營地id { get; set; }
        public int? 營區細項編號 { get; set; }
        public int? 餐廳id { get; set; }
        public string? 套裝方案 { get; set; }
        public string? 套裝細項 { get; set; }
        public int? 露營天數 { get; set; }
        public int? 套裝行程價格 { get; set; }
        public string? 建立人 { get; set; }
        public DateTime? 建立時間 { get; set; }
        public string? 修改人 { get; set; }
        public DateTime? 修改時間 { get; set; }

        public virtual CampDetail? 營區細項編號Navigation { get; set; }
        public virtual Camp? 營地 { get; set; }
        public virtual SetFood? 餐廳 { get; set; }
        public virtual ICollection<SetOrder> SetOrders { get; set; }
    }
}
