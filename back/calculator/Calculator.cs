namespace calculator
{
    public class Calculator
    {
        public double Calculate(CalcRequest request)
        {
            switch (request.operation.ToLower())
            {
                case "add":
                    return request.num1 + request.num2;
                case "subtract":
                    return request.num1 - request.num2;
                case "multiply":
                    return request.num1 * request.num2;
                case "divide":
                    if (request.num2 == 0)
                        throw new ArgumentException("Can't divide by 0.");
                    return request.num1 / request.num2;
                default:
                    throw new ArgumentException("Operation not implemented.");
            }
        }
    }
}