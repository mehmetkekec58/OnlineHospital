using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDiseaseService
    {
        IDataResult<List<Disease>> GetAll();
        IDataResult<Disease> GetById(int id);
        IDataResult<List<Disease>> GetByUserId(int userId);
        IDataResult<List<DiseaseDetailDto>> GetDiseaseDetail(int id);
        IResult Add(Disease disease);
        IResult Update(Disease disease);
        IResult Delete(Disease disease);

    }
}
