using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelBlog.Models.Siniflar;

namespace TravelBlog.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c=new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler=c.Blogs.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var b=c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir",bl);
        }

        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.BASLIK = b.BASLIK;
            blg.TARIH = b.TARIH;
            blg.BLOGIMAGE = b.BLOGIMAGE;
            blg.ACIKLAMA = b.ACIKLAMA;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int id)
        {
            var yrm = c.Yorumlars.Find(id);
            return View("YorumGetir", yrm);
        }

        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yrm = c.Yorumlars.Find(y.ID);
            yrm.KULLANICIADI = y.KULLANICIADI;
            yrm.MAIL=y.MAIL;
            yrm.YORUM=y.YORUM;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult HakkimizdaListesi()
        {
            var hakkimizda = c.Hakkimizdas.ToList();
            return View(hakkimizda);
        }
        public ActionResult HakkimizdaGetir(int id)
        {
            var hkmz = c.Hakkimizdas.Find(id);
            return View("HakkimizdaGetir", hkmz);
        }

        public ActionResult HakkimizdaGuncelle(Hakkimizda h)
        {
            var hkmz = c.Hakkimizdas.Find(h.ID);
            hkmz.FOTOURL = h.FOTOURL;
            hkmz.ACIKLAMA = h.ACIKLAMA;
            c.SaveChanges();
            return RedirectToAction("HakkimizdaListesi");
        }
    }
}