using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DbModels.EF
{
    public class Expense
    {
        public int IdExpense { get; set; }
        public int? IdType { get; set; }
        public int IdUser { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public float Quantity { get; set; }
        public DateTime ExpenseDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        #region
        /// <summary>
        /// Expensetype entity with they datas
        /// </summary>
        public ExpenseType ExpenseType { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Users User { get; set; }

        #endregion
    }
}
