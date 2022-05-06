using System;
using WebApi.Domain.Entities;

namespace WebApi.Controllers.ViewModels
{
    public class CreateChargeViewModel
    {
        public DateTime DueDate { get; set; }
        public double AmountCharge { get; set; }
        public long CustomerId { get; set; }
    }
}
