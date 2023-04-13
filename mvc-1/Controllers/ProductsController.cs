using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ders2.Models;
using Microsoft.AspNetCore.Mvc;
//using ders2.Models;

namespace ders2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepository _prodoctRepository;
        public ProductsController()
        {
            _prodoctRepository=new ProductRepository();
            if (!_prodoctRepository.TumUrunler().Any())
            {
                 _prodoctRepository.UrunEkle(new(){Id=1,Name="Kalem",Price=250,Stock=28});
                 _prodoctRepository.UrunEkle(new(){Id=2,Name="Silgi",Price=5,Stock=5000});
                 _prodoctRepository.UrunEkle(new(){Id=3,Name="Kalemtraş",Price=3,Stock=10000});
                 _prodoctRepository.UrunEkle(new(){Id=4,Name="Defter",Price=95,Stock=0});
            }
           

        }
       
        public IActionResult Index()
        {
            var Urunler=_prodoctRepository.TumUrunler();
            return View(Urunler);
        }
    }
}