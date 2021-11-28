using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LLTD.Models;

namespace LLTD.Controllers
{
    public class DiemHocSinhsController : Controller
    {
        private LLTDDbContext db = new LLTDDbContext();
        AutoGenerateKey aukey = new AutoGenerateKey();

        // GET: DiemHocSinhs
        public ActionResult Index()
        {
            return View(db.DiemHocSinhs.ToList());
        }
        public ActionResult Create()
        {
            var hsID = "";
            var countHS = db.DiemHocSinhs.Count();
            if (countHS == 0)
            {
                hsID = "HS001";
            }
            else
            {
                //Lấy giá trị MaHS moi nhat
                var MaHS = db.DiemHocSinhs.ToList().OrderByDescending(m => m.MaHS).FirstOrDefault().MaHS;
                //sinh MaHS tự dộng
                hsID = aukey.GenerateKey(MaHS);
            }
            ViewBag.MaHS = hsID;
            return View();
        }
        [HttpPost]
        public ActionResult Create(DiemHocSinh hs)

        {
            var countHS = db.DiemHocSinhs.Count();
            if (countHS == 0)
            {
                hs.MaHS = "HS001";
            }
            else
            {
                //Lấy giá trị MaHS moi nhat
                var MaHS = db.DiemHocSinhs.ToList().OrderByDescending(m => m.MaHS).FirstOrDefault().MaHS;
                //sinh MaHS tự dộng
                hs.MaHS = aukey.GenerateKey(MaHS);
            }
            //luu thông tin vao database
            db.DiemHocSinhs.Add(hs);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             DiemHocSinh diemHocSinh = db.DiemHocSinhs.Find(id);
            if (diemHocSinh == null)
            {
                return HttpNotFound();
            }
            return View(diemHocSinh);
        }

        // GET: DiemHocSinhs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemHocSinh diemHocSinh = db.DiemHocSinhs.Find(id);
            if (diemHocSinh == null)
            {
                return HttpNotFound();
            }
            return View(diemHocSinh);
        }

        // POST: DiemHocSinhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiemMieng,Diem15Phut,Diem1Tiet,DiemHK,DiemTBHK,GhiChu")] DiemHocSinh diemHocSinh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diemHocSinh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diemHocSinh);
        }

        // GET: DiemHocSinhs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemHocSinh diemHocSinh = db.DiemHocSinhs.Find(id);
            if (diemHocSinh == null)
            {
                return HttpNotFound();
            }
            return View(diemHocSinh);
        }

        // POST: DiemHocSinhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DiemHocSinh diemHocSinh = db.DiemHocSinhs.Find(id);
            db.DiemHocSinhs.Remove(diemHocSinh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
