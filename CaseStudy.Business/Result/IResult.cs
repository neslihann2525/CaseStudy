namespace CaseStudy.Business.Result
{
    public interface IResult
    {
        bool Success { get; }
        List<string> Message { get; }
        string Code { get; }

    }
}
