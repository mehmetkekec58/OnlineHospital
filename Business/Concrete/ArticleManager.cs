using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ArticleManager : IArticleService
    {
        IArticleDal _articleDal;

        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

       // [SecuredOperation("Doctor,Admin")]
        public IResult Add(Article article)
        {
            _articleDal.Add(article);
            return new SuccessResult(Messages.ArticleAdded);
        }

        public IResult Delete(Article article)
        {
            _articleDal.Delete(article);
            return new SuccessResult(Messages.ArticleDeleted);
        }

        public IDataResult<List<Article>> GetAll()
        {
            return new SuccessDataResult<List<Article>>(_articleDal.GetList().ToList());
        }

        public IDataResult<Article> GetArticleById(int id)
        {
            return new SuccessDataResult<Article>(_articleDal.Get(p => p.Id == id));
        }

        public IDataResult<List<Article>> GetByUserName(string userName)
        {
            return new SuccessDataResult<List<Article>> (_articleDal.GetAll(p=>p.UserName==userName));
        }

        [SecuredOperation("Doctor,Admin")]
        public IResult Update(Article article)
        {
            _articleDal.Update(article);
            return new SuccessResult(Messages.ArticleUpdate);
        }
    }
}
