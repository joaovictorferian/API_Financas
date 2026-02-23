using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Finanças.Application.Services
{
    public class IncomeService
    {
        public void AddIncome(Income income)
        {
            if(income.Value < 0)
            {
                throw new ArgumentException("O valor da receita deve ser positivo.");
            }

            if (string.IsNullOrWhiteSpace(income.Description)){
                throw new ArgumentException("A descrição é obrigatória");
            }

            if (string.IsNullOrWhiteSpace(income.Title))
            {
                throw new ArgumentException("O título é obrigatório");
            }
            if (income.Date == null)
            {
                throw new ArgumentException("A data é obrigatória");
            }
        }

    }
}
