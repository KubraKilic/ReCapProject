using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IService<T>
    {
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(int id);
        IDataResult<T> GetById(int id);
        IDataResult<List<T>> GetAll();
    }
}
