using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IArticleService
    {
        IResult Add(Article article);
        IResult Update(Article article);
        IResult Delete(Article article);
        IDataResult<List<Article>> GetAll();
        IDataResult<List<Article>> GetByUserName(string userName);
        IDataResult<Article> GetArticleById(int id);
    }
}
