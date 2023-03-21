using KUZEYYELİ.ORM.entity;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace KUZEYYELİ.ORM.facade
{
    public class Urunler
    {
        public static DataTable Listele()
        {
            return Tools.Listele("UrunListele");
            //ürün listele=stored procedure
        }

        //insert işlemi

        public static bool Ekle(URUN entity)
        {
            SqlCommand komut = new SqlCommand("UrunEkle", Tools.Baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@urunAdi", entity.UrunAdi);
            komut.Parameters.AddWithValue("@fiyat", entity.Fiyat);
            komut.Parameters.AddWithValue("@stok", entity.Stok);

            //return olunca alt satırlar normalde çalışmaz.Ancak try-catch
            //finally blok çalışır.
            return Tools.ExecuteNonQuery(komut);
        }
        public static bool Sil(URUN entity)
        {
            SqlCommand komut = new SqlCommand("UrunSil", Tools.Baglanti);
                komut.CommandType = CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@urunID", entity.UrunId);
            return Tools.ExecuteNonQuery(komut);
        }

        public static bool Guncelle(URUN entity)
        {
            SqlCommand komut = new SqlCommand("UrunGuncelle", Tools.Baglanti);
            komut.CommandType= CommandType.StoredProcedure;
            komut.Parameters.AddWithValue("@a", entity.UrunAdi);
            komut.Parameters.AddWithValue("@f", entity.Fiyat);
            komut.Parameters.AddWithValue("@s", entity.Stok);
            komut.Parameters.AddWithValue("@id", entity.UrunId);
            return Tools.ExecuteNonQuery(komut);
        }
    }
}
