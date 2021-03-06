﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRS.Models;
using HRS.Repository;

namespace HRS.Controllers
{
    public class RoomTypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /RoomType/
        public ActionResult Index()
        {
            return View(db.RoomType.ToList());
        }

        // GET: /RoomType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomType roomtype = db.RoomType.Find(id);
            if (roomtype == null)
            {
                return HttpNotFound();
            }
            return View(roomtype);
        }

        // GET: /RoomType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /RoomType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Name,Description,GaleryId,ImageURL,Price")] RoomType roomtype)
        {
            if (ModelState.IsValid)
            {
                db.RoomType.Add(roomtype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roomtype);
        }

        // GET: /RoomType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomType roomtype = db.RoomType.Find(id);
            if (roomtype == null)
            {
                return HttpNotFound();
            }
            return View(roomtype);
        }

        // POST: /RoomType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Name,Description,GaleryId,ImageURL,Price")] RoomType roomtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roomtype);
        }

        // GET: /RoomType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomType roomtype = db.RoomType.Find(id);
            if (roomtype == null)
            {
                return HttpNotFound();
            }
            return View(roomtype);
        }

        // POST: /RoomType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomType roomtype = db.RoomType.Find(id);
            db.RoomType.Remove(roomtype);
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
