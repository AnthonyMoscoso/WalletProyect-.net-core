using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class ExpenseDto : BaseEntity
    {
        public int IdExpense { get; set; }
        public int? IdType { get; set; }
        public int IdUser { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public float Quantity { get; set; }
        public DateTime ExpenseDate { get; set; }
        public override int ID { get => IdExpense; set => IdExpense = value; }
    }
}
