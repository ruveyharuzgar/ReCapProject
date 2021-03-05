using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi ";
        public static string BrandAdded = "Marka eklendi ";
        public static string ColorAdded = "Renk eklendi ";

        public static string CarDeleted = "Araba silindi ";
        public static string BrandDeleted = "Marka silindi ";
        public static string ColorDeleted = "Renk silindi ";

        public static string CarUpdated = "Araba güncellendi ";
        public static string BrandUpdated = "Marka güncellendi ";
        public static string ColorUpdated = "Renk güncellendi ";

        public static string CarListed = "Arabalar listelendi ";
        public static string BrandListed = "Markalar listelendi";
        public static string ColorListed = "Renkler listelendi";

        public static string CarIdListed = "Araba Id'leri listelendi";
        public static string BrandIdListed = "Marka Id'leri listelendi";
        public static string ColorIdListed = "Renk Id'leri listelendi";

        public static string CarDetailsListed = "Araba ayrıntıları listelendi ";

        public static string CarDailyPriceInValid = "Günlük ücret bilgisi 0'dan küçük olamaz.";
        public static string ColorNameInValid = "Renk bilgisi en az 4 karakter olmalı.";
        public static string BrandNameInValid = "Marka bilgisi en az 3 karakter olmalı.";
        public static string RentalReturnDateInValid = "Araba henüz teslim edilmedi.";

        public static string RentalAdded = "Kira bilgisi eklendi";
        public static string RentalDeleted="Kira bilgisi silindi";
        public static string RentalUpdated="Kira bilgisi güncellendi";
        public static string RentalListed="Kira bilgileri listelendi";

        public static string CustomerAdded="Müşteri eklendi";
        public static string CustomerDeleted="Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerListed="Müşteriler listelendi";

        public static string UserUpdated="Kullanıcı güncellendi";
        public static string UserListed="Kullanıcılar listelendi";
        public static string UserAdded="Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";

        public static string FailAddedImageLimit="En fazla 5 resim yüklenebilir";

        public static string AuthorizationDenied="Yetkiniz yok";
        public static string UserRegistered="Kayıt başarılı";
        public static string UserNotFound="Kullanıcı bulunamadı";
        public static string SuccessfulLogin="Giriş başarılı";
        public static string PasswordError="Parola hatalı";
        public static string AccessTokenCreated="Token oluşturuldu";
        public static string UserAlreadyExists="Kullanıcı zaten mevcut";

        public static string CarImageUpdated="Araba resmi güncellendi";
        public static string CarImageDeleted="Araba resmi silindi";
        public static string CarImageAdded="Araba resmi yüklendi";
    }
}
