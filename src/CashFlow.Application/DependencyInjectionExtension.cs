using CashFlow.Application.AutoMapper;
using CashFlow.Application.UseCases.Expenses.CashFlow.Delete;
using CashFlow.Application.UseCases.Expenses.CashFlow.GetAll;
using CashFlow.Application.UseCases.Expenses.CashFlow.GetExpenseById;
using CashFlow.Application.UseCases.Expenses.CashFlow.Register;
using CashFlow.Application.UseCases.Expenses.CashFlow.Update;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }
    private static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }
    public static void AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
        services.AddScoped<IGetAllExpenseUseCase, GetAllExpenseUseCase>();
        services.AddScoped<IGetExpenseByIdUseCase, GetExpenseByIdUseCase>();
        services.AddScoped<IDeleteExpenseUseCase, DeleteExpenseUseCase>();
        services.AddScoped<IUpdateExpenseUseCase, UpdateExpenseUseCase>();
    }
}
