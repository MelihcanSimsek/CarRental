using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Message
    {
        public static string CarAdded = "Araba Eklendi";
        public static string CarAddError = "Araba Ekleme Hatası";
        public static string CarDeleted = "Araba Silindi";
        public static string CarsListed = "Arabalar Listelendi";
        public static string CarsDetailsListed = "Araba Detayları Listelendi";
        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandsListed = "Markalar Listelendi";
        public static string ColorAdded = "Renk Eklendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorsListed = "Renkler Listelendi";
        public static string RentalAdded = "Araba Kiralandı";
        public static string RentalAddError = "Araba Kiralama Hatası";
        public static string ImageLimitExceded = "Resim Limiti Hatası";
        public static string CarImageDeleted = "Araba Resmi Silindi";
        public static string CarImageUpdated = "Araba Resmi Güncellendi";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string UserListed = "Kullanıcı Listelendi";
        public static string UserRegistered = "Kullanıcı Kaydedildi";
        public static string PasswordError = "Parola Hatalı";
        public static string SuccessLogin = "Giriş Başarılı";
        public static string UserAlreadyExists = "Kullanıcı Mevcut";
        public static string AccessTokenCreated = "Token Oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz Yok";
        public static string ThisCarAlreadyRentedInSelectedDateRange = "Seçilen aralıkta araba zaten kiralanmış";
        public static string ReturnDateIsBeforeRentDate = "Dönüş tarihi kiralama tarihinden önce hatası";
        public static string SelectedDateRangeIsOkay = "Tarih aralığı uygun";
        public static string InvalidCardNumber = "Geçersiz kart numarası";
        public static string PayIsSuccessfull = "Ödeme işlemi başarılı";
        public static string CardInformationIsIncorrect = "Kart bilgileri hatalı";
        public static string InvalidCardYear = "Geçersiz kart yılı";
        public static string InvalidCardMonth = "Geçersiz kart ayı";
        public static string UserUpdated = "Kullanıcı Güncellendi";
    }
}
