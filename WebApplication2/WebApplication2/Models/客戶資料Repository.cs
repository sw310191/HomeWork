using System;
using System.Linq;
using System.Collections.Generic;
	
namespace WebApplication2.Models
{   
	public  class 客戶資料Repository : EFRepository<客戶資料>, I客戶資料Repository
	{
        public override IQueryable<客戶資料> All()
        {
            return base.All().Where(p => p.IsDelete == false);
        }
        public 客戶資料 FindById(int id)
        {
            return this.All().Where(p => p.Id == id).SingleOrDefault();
        }
	}

	public  interface I客戶資料Repository : IRepository<客戶資料>
	{

	}
}