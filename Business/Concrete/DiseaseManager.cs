using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Autofac.Caching;
using Entities.Dtos;

namespace Business.Concrete
{
    public class DiseaseManager : IDiseaseService
    {
        IDiseaseDal _diseaseDal;

        public DiseaseManager(IDiseaseDal diseaseDal)
        {
            _diseaseDal = diseaseDal;
        }
        [ValidationAspect(typeof(DiseaseValidator))]
        public IResult Add(Disease disease)
        {
            _diseaseDal.Add(disease);
            return new SuccessResult(Messages.DiseaseAdded);
        }

        public IResult Delete(Disease disease)
        {
            _diseaseDal.Delete(disease);
            return new SuccessResult(Messages.DiseaseDeleted);
        }

        public IDataResult<Disease> GetById(int id)
        {
            return new SuccessDataResult<Disease>(_diseaseDal.Get(p => p.Id == id));
        }
        [CacheAspect(duration: 20)]
        public IDataResult<List<Disease>> GetAll()
        {
            return new SuccessDataResult<List<Disease>>(_diseaseDal.GetAll());
        }
        [ValidationAspect(typeof(DiseaseValidator))]
        public IResult Update(Disease disease)
        {
            _diseaseDal.Update(disease);
            return new SuccessResult(Messages.DiseaseUpdate);
        }

        public IDataResult<List<Disease>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<Disease>>(_diseaseDal.GetAll(p=>p.UserId==userId));
        }

        public IDataResult<List<DiseaseDetailDto>> GetDiseaseDetail(int id)
        {
            return new SuccessDataResult<List<DiseaseDetailDto>>(_diseaseDal.GetDiseaseDetail(id));
        }
    }
}
