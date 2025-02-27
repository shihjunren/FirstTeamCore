﻿using System;
using System.Collections.Generic;

namespace FirstTeamCore.Models
{
    public partial class ActDetail
    {
        public ActDetail()
        {
            CampDetails = new HashSet<CampDetail>();
        }

        public int 活動編號 { get; set; }
        public int? 營區編號 { get; set; }
        public string? 活動方式 { get; set; }
        public string? 活動種類 { get; set; }
        public string? 活動名稱 { get; set; }
        public DateTime? 開始日期 { get; set; }
        public DateTime? 結束日期 { get; set; }
        public int? 預計人數 { get; set; }
        public string? 活動介紹 { get; set; }
        public int? 門票價格 { get; set; }
        public string? 活動圖片 { get; set; }
        public string? 建立人 { get; set; }
        public DateTime? 建立時間 { get; set; }
        public string? 修改人 { get; set; }
        public DateTime? 修改時間 { get; set; }

        public virtual Camp? 營區編號Navigation { get; set; }
        public virtual ICollection<CampDetail> CampDetails { get; set; }
    }
}
