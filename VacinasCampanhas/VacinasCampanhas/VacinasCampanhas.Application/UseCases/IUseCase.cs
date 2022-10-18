namespace VacinasCampanhas.VacinasCampanhas.Application.UseCases
{
    public interface IUseCaseResponse<TResponse>
    {
        TResponse Execute();
    }

    public interface IUseCase<in TRequest>
    {
        void Execute(TRequest request);
    }

    public interface IUseCaseAsync<TResponse, TRequest>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }
}
