using System;

namespace CommissionCalculation {
    public class CommissionCalculator {
        public const decimal CommissionPerCarSold = 250;
        public decimal FixedSalary { get; set; }
        public int AmountCarsSold { get; set; }
        public decimal TotalSalesValue { get; set; }
        public decimal FinalSalary { get; set; }

        public decimal CalculateFinalSalary(decimal fixedSalary, int amountCarsSold, decimal totalSalesValue) {

            FixedSalary = fixedSalary;
            AmountCarsSold = amountCarsSold;
            TotalSalesValue = totalSalesValue;

            decimal percentage = 0.03M;

            FinalSalary = FixedSalary + (AmountCarsSold * CommissionPerCarSold) + (TotalSalesValue * percentage);

            return FinalSalary;

        }

        public string GetFinalSalary(string contributorName, string month) {

            decimal percentage = 0.03M;

            return $"O colaborador {contributorName} neste mês de {month} obteve o salário final de R${FinalSalary.ToString("F2")} referente à: SALARIO FIXO: R${FixedSalary.ToString("F2")} TOTAL DE CARROS VENDIDOS: {AmountCarsSold} VALOR TOTAL DE VENDAS NO MES: R${TotalSalesValue.ToString("F2")} COMISSÃO POR CARROS VENDIDOS: R${CommissionPerCarSold.ToString("F2")} COMISSÃO DE 3% DO TOTAL DE VENDAS: R${(TotalSalesValue * percentage).ToString("F2")}";

            // return message;
        }
    }
}