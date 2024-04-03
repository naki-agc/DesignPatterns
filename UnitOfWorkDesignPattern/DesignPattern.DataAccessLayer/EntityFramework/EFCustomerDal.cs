using DesignPattern.DataAccessLayer.Abstract;
using DesignPattern.DataAccessLayer.Concrete;
using DesignPattern.DataAccessLayer.Repositories;
using DesignPattern.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.DataAccessLayer.EntityFramework
{
    public class EFCustomerDal:GenericRepository<Customer>,ICustomerDal
    {
        public EFCustomerDal(Context context):base(context)
        {
                
        }
    }
}
