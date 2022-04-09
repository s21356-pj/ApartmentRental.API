using ApartmentRental.Infrastructure.Context;
using ApartmentRental.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApartmentRental.Infrastructure.Repository;

public class ApartmentRepository : IApartmentRepository
{
    private readonly MainContext _mainContext;

    public ApartmentRepository(MainContext mainContext)
    {
        _mainContext = mainContext;
    }
    
    public async Task<IEnumerable<Apartment>> GetAll()
    {
        var apartments = await _mainContext.Apartment.ToListAsync();
        foreach (var apartment in apartments)
        {
            await _mainContext.Entry(apartment).Reference(x => x.Address).LoadAsync();
        }

        return apartments;
    }

    public Task<Apartment> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task Add(Apartment entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(Apartment entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteById(int id)
    {
        throw new NotImplementedException();
    }
}