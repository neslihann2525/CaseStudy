namespace CaseStudy.Business.Result
{
    public class Result : IResult
    {
        public Result(bool success, List<string> message, string code) : this(success)
        {
            Message = message;
            Code = code;
        }

        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }
        public List<string> Message { get; }

        public string Code { get; }
    }
}