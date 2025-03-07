using AutoMapper;
using CashFlow.Communication.Reponse;
using CashFlow.Communication.Reponses;
using CashFlow.Communication.Request;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }
    private void RequestToEntity()
    {
        CreateMap<RequestExpenseJson, Expense>();
        CreateMap<RequestRegisterUserJson, User>()
            .ForMember(dest => dest.Password, config => config.Ignore());
    }
    private void EntityToResponse()
    {
        CreateMap<Expense, ResponseExpenseJson>();
        CreateMap<Expense, ResponseShortExpenseJson>();
        CreateMap<User,ResponseRegisteredUserJson>();
    }
}
