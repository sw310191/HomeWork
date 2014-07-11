using System;
using System.Linq;
using System.Collections.Generic;
	
namespace WebApplication2.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public override IQueryable<客戶銀行資訊> All()
        {
            return base.All().Where(p => p.IsDelete == false);
        }
        public 客戶銀行資訊 FindById(int id)
        {
            return this.All().Where(p => p.Id == id).SingleOrDefault();
        }
        public 客戶銀行資訊 FindByPId(int id)
        {
            return this.All().Where(p => p.客戶Id == id).SingleOrDefault() ;
        }
	}

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}