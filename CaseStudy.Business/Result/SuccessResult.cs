namespace CaseStudy.Business.Result
{
    public class SuccessResult : Result
    {
        public SuccessResult(List<string> message, string code) : base(true, message, code)
        {
        }

        public SuccessResult() : base(true)
        {
        }
    }
}
