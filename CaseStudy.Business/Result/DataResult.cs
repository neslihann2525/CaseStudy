
namespace CaseStudy.Business.Result
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(T data, bool success, List<string> message, string code) : base(success, message, code)
        {
            Data = data;
        }

        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
