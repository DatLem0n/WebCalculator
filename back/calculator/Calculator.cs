namespace calculator
{
    public class Calculator
    {
        /**
         * Calculates the calculation received in json from front
         */
        public double Calculate(CalcRequest request)
        {
            switch (request.operation.ToLower())
            {
                case "+":
                    return request.num1 + request.num2;
                case "-":
                    return request.num1 - request.num2;
                case "*":
                    return request.num1 * request.num2;
                case "/":
                    if (request.num2 == 0)
                        throw new ArgumentException("Can't divide by 0.");
                    return (double)request.num1 / request.num2;
                default:
                    throw new ArgumentException("Operation not implemented.");
            }
        }
    }
}