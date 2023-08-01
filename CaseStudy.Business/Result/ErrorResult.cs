
namespace CaseStudy.Business.Result

{
    public class ErrorResult : Result
    {
        public ErrorResult(List<string> message, string code) : base(false, message, code)
        {
        }

        public ErrorResult() : base(false)
        {
        }
    }
}
