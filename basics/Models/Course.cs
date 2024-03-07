using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Drawing;

namespace basics.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string? Title { get; set; } //Soru işareti olmasının sebebi ilgili stringin null değer alabileceğini belirtmek içindir. Sadece string olsaydı null değer geldiğinde hata verirdi. Bu özelliği kapatmak için basics.csproj dosyasında Nullable kısmını disable yapabiliriz. Bu durumda ? kullanmamıza gerek kalmaz.

        public string? Image { get; set; }
        public string? Description { get; set; }
        public string[]? Tags { get; set; }
        public bool isActive { get; set; }
        public bool isHome { get; set; }
    }
}