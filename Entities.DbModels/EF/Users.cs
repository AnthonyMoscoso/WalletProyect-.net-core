using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DbModels.EF
{
    public class Users
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
  
        public virtual ICollection<Expense> Expense { get; set; }
        public virtual ICollection<Ingress> Ingress { get; set; }
        public virtual ICollection<IngressType> IngressType { get; set; }
        public virtual ICollection<ExpenseType> ExpenseType { get; set; }

    }
}
