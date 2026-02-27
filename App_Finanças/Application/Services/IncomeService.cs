using App_Finanças.Domain.Entities;
using App_Finanças.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Finanças.Application.Services
{
    public class IncomeService
    {
        private readonly IncomeRepository _incomeRepository;

        public IncomeService(IncomeRepository incomeRepository)
        {
            _incomeRepository = incomeRepository;
        }

        public void ReadIncomes(Income income)
        {
            _incomeRepository.ReadIncomes(income);
        }   

        public void AddIncome(Income income)
        {
            AutenticateIncomeCreation(income);
    
            _incomeRepository.SaveIncome(income); 
        }

        public void UpdateIncome(int id, UpdateIncomeDto dto)
        {
            AutenticateIncomeUpdate(dto);

            _incomeRepository.UpdateIncome(
                id,
                dto.Title,
                dto.Description,
                dto.Category,
                dto.Value,
                dto.Date
                );
        }

        public void DeleteIncome(Income income)
        { 
            _incomeRepository.DeleteIncome(income.Id);
        }

        private void AutenticateIncomeCreation(Income income)
        {
            if (income.Value < 0)
            {
                throw new ArgumentException("O valor da receita deve ser positivo.");
            }

            if (string.IsNullOrWhiteSpace(income.Description))
            {
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

            return;
        }
        private void AutenticateIncomeUpdate(UpdateIncomeDto dto)
        {

            if (dto.Value.HasValue && dto.Value < 0)
            {
                throw new ArgumentException("O valor da receita deve ser positivo.");
            }

            if (dto.Description != null && string.IsNullOrWhiteSpace(dto.Description))
            {
                throw new ArgumentException("A descrição é obrigatória");
            }

            if (dto.Title != null && string.IsNullOrWhiteSpace(dto.Title))
            {
                throw new ArgumentException("O título é obrigatório");
            }

            return;
        }

    }
}
