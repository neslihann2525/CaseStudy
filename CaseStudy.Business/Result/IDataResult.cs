namespace CaseStudy.Business.Result
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}
