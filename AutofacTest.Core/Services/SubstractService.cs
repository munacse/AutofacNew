using AutofacTest.Core.Infrastructure;

namespace AutofacTest.Core.Services
{
    public class SubstractService : ISubstractService
    {
        private ILogger logger;

        public SubstractService(ILogger logger)
        {
            this.logger = logger;
        }

        public int SubstractTwo(int number1, int number2)
        {
            var result = number1 - number2;
            this.logger.Info($"Total value {result}");
            return result;
        }

        public int SubstractThree(int number1, int number2, int number3)
        {
            var result = number1 - number2 - number3;
            this.logger.Info($"Total value {result}");
            return result;
        }
    }
}
