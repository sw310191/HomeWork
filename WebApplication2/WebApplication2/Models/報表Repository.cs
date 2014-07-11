using System;
using System.Linq;
using System.Collections.Generic;
	
namespace WebApplication2.Models
{   
	public  class 報表Repository : EFRepository<報表>, I報表Repository
	{
        public 報表 FindById(int id)
        {
            return this.All().Where(p => p.Id == id).SingleOrDefault();
        }
	}

	public  interface I報表Repository : IRepository<報表>
	{

	}
}