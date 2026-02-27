using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Finanças.Domain.Entities
{    public class UpdateIncomeDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }    
        public double? Value { get; set; }
        public DateTime? Date { get; set; }

    }

}
