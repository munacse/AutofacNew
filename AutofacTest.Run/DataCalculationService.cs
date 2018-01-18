using System;
using AutofacTest.Core.Infrastructure;

namespace AutofacTest.Run
{
    public class DataCalculationService
    {
        private IAddService addService;
        private ISubstractService substractService;

        public DataCalculationService(IAddService addService, ISubstractService substractService)
        {
            this.addService = addService;
            this.substractService = substractService;
        }

        public void AddData()
        {
            int number1 = 20;
            int number2 = 30;

            var result = this.addService.AddTwo(number1, number2);
            Console.WriteLine(result);
        }

        public void SubstractData()
        {
            int number1 = 20;
            int number2 = 30;

            var result = this.substractService.SubstractTwo(number2, number1);
            Console.WriteLine(result);
        }
    }
}
