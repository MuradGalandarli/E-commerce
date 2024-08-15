using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityCommerce.Enum
{
    public class Enums
    {
        public enum OrderEnum
        {

            // Sipariş henüz sepete eklenmemiş
            NotAddedToCart = 1,

            // Ürün sepete eklendi
            AddedToCart = 2,

            // Sepete eklenen ürünler alındı (satın alma işlemi başlatıldı)
            Purchased = 3,

            // Ödeme bekleniyor
            PaymentPending = 4,

            // Ödeme alındı
            PaymentCompleted = 5,

            // Sipariş hazırlanıyor
            Preparing = 6,

            // Sipariş kargoya verildi
            Shipped = 7,

            // Sipariş teslim edildi
            Delivered = 8,

            // Sipariş iptal edildi
            Canceled = 9,

            // Ürün stokta yok
            OutOfStock = 10
        }

        public enum likeEnum
        {
            Dislike = 0,
            Like = 1,
            Neutral = 2
        }
    }

}