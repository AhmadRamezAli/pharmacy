using Pharmacy.Domain.DTOs;
using Pharmacy.SharedKernel.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services.Medicine
{
    public interface IMedicineService : IService<Pharmacy.Domain.Entities.Medicine>
    {
        bool? ApplyEventChanges(int id, List<AttachEventDTO> eventsList);
        List<Domain.Entities.Ingredient> GetIngredients(int id);
    }
}
