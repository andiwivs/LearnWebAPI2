using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnWebAPI2.API.DomainModel
{
    public class ExpenseGroup
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Expense[] Expenses { get; set; }

        public ExpenseGroup()
        {
            Expenses = new Expense[0];
        }
    }
}