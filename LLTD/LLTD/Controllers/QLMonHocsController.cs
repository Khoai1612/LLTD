﻿using System;
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
    public class QLMonHocsController : Controller
    {
        private LLTDDbContext db = new LLTDDbContext();
        AutoGenerateKey aukey = new AutoGenerateKey();

        // GET: QLMonHocs
        public ActionResult Index()
        {
            return View(db.QLMonHocs.ToList());
        }
        public ActionResult Create()
        {
            var mhID = "";
            var countMH = db.QLMonHocs.Count();
            if (countMH == 0)
            {
                mhID = "MH001";
            }
            else
            {
                //Lấy giá trị MaHS moi nhat
                var MaMH = db.QLMonHocs.ToList().OrderByDescending(m => m.MaMH).FirstOrDefault().MaMH;
                //sinh MaHS tự dộng
                mhID = aukey.GenerateKey(MaMH);
            }
            ViewBag.MaMH = mhID;
            return View();
        }
        [HttpPost]
        public ActionResult Create(QLMonHoc mh)

        {
            var countMH = db.QLMonHocs.Count();
            if (countMH == 0)
            {
                mh.MaMH = "MH001";
            }
            else
            {
                //Lấy giá trị MaHS moi nhat
                var MaMH = db.QLMonHocs.ToList().OrderByDescending(m => m.MaMH).FirstOrDefault().MaMH;
                //sinh MaHS tự dộng
                mh.MaMH = aukey.GenerateKey(MaMH);
            }
            //luu thông tin vao database
            db.QLMonHocs.Add(mh);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: QLMonHocs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLMonHoc qLMonHoc = db.QLMonHocs.Find(id);
            if (qLMonHoc == null)
            {
                return HttpNotFound();
            }
            return View(qLMonHoc);
        }

        

        
        // GET: QLMonHocs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLMonHoc qLMonHoc = db.QLMonHocs.Find(id);
            if (qLMonHoc == null)
            {
                return HttpNotFound();
            }
            return View(qLMonHoc);
        }

        // POST: QLMonHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaMH,TenMH,GhiChu")] QLMonHoc qLMonHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qLMonHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(qLMonHoc);
        }

        // GET: QLMonHocs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QLMonHoc qLMonHoc = db.QLMonHocs.Find(id);
            if (qLMonHoc == null)
            {
                return HttpNotFound();
            }
            return View(qLMonHoc);
        }

        // POST: QLMonHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QLMonHoc qLMonHoc = db.QLMonHocs.Find(id);
            db.QLMonHocs.Remove(qLMonHoc);
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
