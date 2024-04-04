using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryDesignPattern.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class //Controller tarafında çağıacağımız methodları tutacak controllerda business katmanını çağıracağız dataAccessi değil !!!
    {

        void TInsert(T t);
        void TUpdate(T t);
        void TDelete(T t);
        List<T> TGetList();
        T TGetById(int id);


    }
}
