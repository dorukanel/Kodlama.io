using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Arac eklendi.";
        public static string InvalidCar = "Arac eklenemedi.";
        public static string CarDeleted = "Arac silindi.";
        public static string CarUpdated = "Arac güncellendi.";
        public static string MaintenanceTime = "Bakım zamanı, lütfen sonra deneyiniz.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandUpdated = "Marka güncellendi";
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string RentalAdded = "Kiralama eklendi.";
        public static string RentalDeleted = "Kiralama silindi.";
        public static string RentalUpdated = "Kiralama güncellendi.";
        public static string RentalReturnDateError = "Araç şuanda kiradadır. ";
        public static string RentalNotAdded = "Kiralama eklenemedi.";
        public static string ReturnDateUpdate = "Araç iade tatihi güncellendi.";
        public static string CarImageDeleted = "Arac resmi başarıyla silinmiştir.";
        public static string CarImageUpdated = "Arac resmi güncellendi.";
        public static string CarImageAdded = "Arac resmi eklendi.";
        public static string DefaultImageAdded = "Bu aracın resmi olmadığından şirket logosu resmi gönderildi.";
        public static string AmountLimitOfImagesExceeded= "Bu araç için en daha fazla resim ekleyemezsiniz.";
        public static string UserRegistered="Kayıt başarılı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string SuccessfulLogin="Başarıyla giriş yapıldı";
        public static string PasswordError="Şifre hatalı";
        public static string UserAlreadyExists="Kullanıcı zaten var";
        public static string AccessTokenCreated="Token oluşturuldu";
        public static string AuthorizationDenied="Yetkiniz yok";
    }
}
