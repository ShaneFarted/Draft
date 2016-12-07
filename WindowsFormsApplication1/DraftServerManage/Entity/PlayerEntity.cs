using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1.DraftServerManage.Entity
{
    class PlayerEntity
    {
        /// <summary>
        /// 球员编号
        /// </summary>
        public string id {get; set;}
        /// <summary>
        /// 球员英文名
        /// </summary>
        public string ename { get; set; }
        /// <summary>
        /// 球员中文名
        /// </summary>
        public string cname { get; set; }
        /// <summary>
        /// 球员总评能力值
        /// </summary>
        public int overall { get; set; }
        /// <summary>
        /// 球员位置
        /// </summary>
        public string position { get; set; }
        /// <summary>
        /// 球员价格
        /// </summary>
        public int price { get; set; }
    }
}
