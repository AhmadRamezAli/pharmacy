using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pharmacy.Domain.DTOs;
using Pharmacy.Domain.Entities;
using Pharmacy.Domain.Repositories;
using Pharmacy.Infrastracture.DataContext;
using Pharmacy.Infrastracture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Infrastracture.Repositories
{
    internal class PatientRepository : BaseRepository<Patient, PatientDAO>, IPatientRepository
    {
        public PatientRepository(PharmacyContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public bool? ApplyEventChanges(int id, List<AttachEventDTO> eventsList)
        {
            var completed = false;

            // Start a transaction

            var executionStrategy = _context.Database.CreateExecutionStrategy();
            executionStrategy.Execute(() =>
            {
                using (var transactionScope = _context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (var ev in eventsList)
                        {
                            if (ev.Type == "Added")
                            {
                                _context.PatientDiseases.Add(new()
                                {
                                    Patient = ev.Id,
                                    Disease = id
                                });
                                _context.SaveChanges();
                            }
                            if (ev.Type == "Removed")
                            {
                                PatientDiseaseDAO? patientDisease = _context.PatientDiseases
                                                    .Where(e => e.Patient == id
                                                    && e.Disease == ev.Id)
                                                                .FirstOrDefault();

                                if (patientDisease is not null)
                                {
                                    _context.PatientDiseases.Remove(patientDisease);
                                    _context.SaveChanges();
                                }
                            }
                        }

                        transactionScope.Commit();

                        completed = true;
                    }
                    catch (Exception)
                    {
                        completed = false;
                        transactionScope.Rollback();
                    }
                }

            });

            return completed;
        }
        public List<Disease> GetDiseases(int id)
        {
            List<int> x = _context.PatientDiseases.Where(e => e.Patient == id).Select(e => e.Disease).ToList();

            List<DiseaseDAO> diseases = new List<DiseaseDAO>();
            foreach (int v in x)
            {
                var f = _context.Diseases.FirstOrDefault(e => e.Id == v);
                if (f != null) { diseases.Add(f); }

            }
            _context.SaveChanges();

            List<Disease> medi = new List<Disease>();
            foreach (var z in diseases)
            {
                medi.Add(_mapper.Map<Disease>(z));
            }

            return medi;
        }
    }
}

