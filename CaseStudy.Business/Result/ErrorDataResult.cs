
namespace CaseStudy.Business.Result
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, List<string> message, string code) : base(data, false, message, code)
        {
        }

        public ErrorDataResult(T data) : base(data, false)
        {
        }

        public ErrorDataResult(List<string> message, string code) : base(default, false, message, code)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
