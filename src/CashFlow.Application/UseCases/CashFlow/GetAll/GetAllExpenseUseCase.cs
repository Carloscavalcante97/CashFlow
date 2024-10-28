
using AutoMapper;
using CashFlow.Communication.Reponses;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.CashFlow.GetAll;

public class GetAllExpenseUseCase : IGetAllExpenseUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IMapper _mapper;
    public GetAllExpenseUseCase(IExpensesRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<RequestExpensesJson> Execute()
    {
       var result = await _repository.GetAll();
       
        return new RequestExpensesJson
        {
            Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(result)
        };
    }
}
