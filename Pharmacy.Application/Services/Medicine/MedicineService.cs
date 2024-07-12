using Pharmacy.Domain.DTOs;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Repositories;
using Pharmacy.SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services.Medicine;

public class MedicineService : BaseService<Domain.Entities.Medicine>, IMedicineService
{
    private readonly IMedicineRepository _repository;
    public MedicineService(IMedicineRepository repository) : base(repository)
    {
        _repository = repository;
    }

    public bool? ApplyEventChanges(int id, List<AttachEventDTO> eventsList)
    {
        return _repository.ApplyEventChanges(id, eventsList);
    }

    public List<Domain.Entities.Ingredient> GetIngredients(int id)
    {
        return _repository.GetIngredients(id);
    }
}