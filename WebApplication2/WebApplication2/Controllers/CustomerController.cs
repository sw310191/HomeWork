using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CustomerController : Controller
    {

        客戶資料Repository clientRepo = RepositoryHelper.Get客戶資料Repository();
        客戶聯絡人Repository clientcontact = RepositoryHelper.Get客戶聯絡人Repository();
        客戶銀行資訊Repository clientbank = RepositoryHelper.Get客戶銀行資訊Repository();
        // GET: Customer
        public ActionResult Index()
        {
            var data = clientRepo.All();
            return View(data);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            var client = clientRepo.All().FirstOrDefault(p => p.Id == id);
            return View(client);

        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                clientRepo.Add(客戶資料);
                客戶資料.IsDelete = false;
                clientRepo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            var client = clientRepo.All().FirstOrDefault(p => p.Id == id);


            return View(client);
        }

        // POST: Customer/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,統一編號,電話,傳真,地址,Email")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                clientRepo.UnitOfWork.Context.Entry(客戶資料).State = EntityState.Modified;
                clientRepo.UnitOfWork.Commit();
                return RedirectToAction("Index");

            }
            return View(客戶資料);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            客戶資料 客戶資料 = clientRepo.FindById(id.Value);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }
            return View(客戶資料);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            客戶資料 客戶資料 = clientRepo.FindById(id);
            
            var bank = clientbank.All();
            foreach (var item in bank)
            {
                if (item.客戶Id == id)
                {
                    item.IsDelete = true;
                }
            }
            clientbank.UnitOfWork.Commit();

            var contact = clientcontact.All();
            foreach (var item in contact)
            {
                if (item.客戶Id == id)
                {
                    item.IsDelete = true;
                }
            }
            clientcontact.UnitOfWork.Commit();


            客戶資料.IsDelete = true;
            clientRepo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }


    }
}
