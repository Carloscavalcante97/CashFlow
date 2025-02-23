using CashFlow.Domain.Enum;
using CashFlow.Domain.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Domain.Enums.Extensions
{
    public static class PaymentTypeExtensions
    {
        public static string PaymentTypeToString(this PaymentType paymentType)
        {
            return paymentType switch
            {
                PaymentType.Cash => ResourceReportGenerationMessage.CASH,
                PaymentType.CreditCard => ResourceReportGenerationMessage.CREDIT_CARD,
                PaymentType.DebitCard => ResourceReportGenerationMessage.DEBIT_CARD,
                PaymentType.EletronicTransfer => ResourceReportGenerationMessage.ELETRONIC_TRANSFER,
                _ => string.Empty
            };
        }
    }
}
