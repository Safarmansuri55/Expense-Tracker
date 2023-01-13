using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Expanse_Manager.Models;

namespace Expanse_Manager.Viewmodel
{
    public class ExpenseViewModel
    {

        public IEnumerable<catagory> Catagories { get; set; }
        public IEnumerable<expense> Expenses { get; set; }  
        public IEnumerable<user> users { get; set; }    
        public IEnumerable<total_limit> total_limit { get; set; }
    }
}