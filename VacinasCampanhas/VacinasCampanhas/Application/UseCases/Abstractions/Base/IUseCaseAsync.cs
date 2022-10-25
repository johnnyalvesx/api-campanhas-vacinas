namespace VacinasCampanhas.Application.UseCases.Abstractions.Base
{

    public interface IUseCaseAsync<TResponse, TRequest>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }

    public interface IUseCaseResponse<TResponse>
    {
        TResponse Execute();
    }

    public interface IUseCaseRequestAsync<in TRequest>
    {
        void Execute(TRequest request);
    }


}
