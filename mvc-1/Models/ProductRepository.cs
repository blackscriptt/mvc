using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ders2.Models
{
    public class ProductRepository
    {
        private static List<Product> _urunler;
        public List<Product> TumUrunler()=>_urunler;
        public void UrunEkle(Product Urun)=>_urunler.Add(Urun);
        // {
        //     _urunler.Add(Urun);
        // }
        public void UrunSil(int id)
        {
            var gelenUrun=_urunler.FirstOrDefault(x=>x.Id==id);
            if (gelenUrun==null)
            {
                throw new Exception($"{id} numaralı id'ye sahip ürün listede yok!");
            }
            else
            {
                _urunler.Remove(gelenUrun);
            }
        }

        public void UrunGuncelle(Product guncel)
        {
             var guncellenecekUrun=_urunler.FirstOrDefault(x=>x.Id==guncel.Id);
            if (guncellenecekUrun==null)
            {
                throw new Exception("Güncellemeye çalıştığınız ürün bulunamadı.");
            }
            else
            {
                guncellenecekUrun.Name=guncel.Name;
                guncellenecekUrun.Price=guncel.Price;
                guncellenecekUrun.Stock=guncel.Stock;
                var index=_urunler.FindIndex(x=>x.Id==guncel.Id);
                _urunler[index]=guncellenecekUrun;


            }
        }
    }
}