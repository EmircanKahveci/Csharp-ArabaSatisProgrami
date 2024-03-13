using Core.Utilities.Results;
using Entities.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IColorService
    {
         IDataResult<List<Color>> GetAll();
         IDataResult<List<Color>> GetByColorId(int id);
         IResult Add(Color color);

    }
}
