using WebApplication1.Dto;

namespace WebApplication1.Services;

public interface IMedicamentsService
{
    public IEnumerable<MedicamentDto> getAnimalsService(int id);
}
public class MedicamentsService : IMedicamentsService
{
    private IMedicamentsService _service;

    public MedicamentsService(IMedicamentsService service)
    {
        this._service = service;
    }
    public IEnumerable<MedicamentDto> getAnimalsService(int id)
    {
        
    }
}