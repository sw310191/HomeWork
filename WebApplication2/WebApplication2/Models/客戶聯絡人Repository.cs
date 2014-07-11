using System;
using System.Linq;
using System.Collections.Generic;
	
namespace WebApplication2.Models
{   
	public  class 客戶聯絡人Repository : EFRepository<客戶聯絡人>, I客戶聯絡人Repository
	{
        public override IQueryable<客戶聯絡人> All()
        {
            return base.All().Where(p => p.IsDelete == false);
        }
        public 客戶聯絡人 FindById(int id)
        {
            return this.All().Where(p => p.Id == id).SingleOrDefault();
        }
        public 客戶聯絡人 FindByPId(int id)
        {
            return this.All().Where(p => p.客戶Id  == id).SingleOrDefault();
        }
	}

	public  interface I客戶聯絡人Repository : IRepository<客戶聯絡人>
	{

	}
}