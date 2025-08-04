using AutoMapper;
using MediatR;
using StudMart.PartnersMicroservice.BusinessLogic.Models.Employee;
using StudMart.PartnersMicroservice.BusinessLogic.Queries.Requests.Employee;
using StudMart.PartnersMicroservice.Repositories.Abstractions;

namespace StudMart.PartnersMicroservice.BusinessLogic.Queries.Handlers.Employee;

public class GetPartnerEmployeesRequestHandler(IEmployeesRepository repository, IMapper mapper) :
    IRequestHandler<GetPartnerEmployeesRequest, IEnumerable<EmployeeModel>>,
    IDisposable,
    IAsyncDisposable
{
    public async Task<IEnumerable<EmployeeModel>> Handle(
        GetPartnerEmployeesRequest request, 
        CancellationToken cancellationToken)
    {
        // Получаем сотрудников по PartnerId
        var employees = await repository.GetAllByPartnerIdAsync(request.PartnerId, cancellationToken);
        return mapper.Map<IEnumerable<EmployeeModel>>(employees);
    }

    public void Dispose()
    {
        repository.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await repository.DisposeAsync();
    }
}

    