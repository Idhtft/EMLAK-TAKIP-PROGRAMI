using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace real_estate_app.Models
{
    public class RealEstate
    {
        
            public int RealEstateId { get; set; }

            [Required]
            public string Address { get; set; }
            public string City { get; set; }
            public string District { get; set; }

            public int RoomNumb { get; set; }

            public int SquareMeter { get; set; }

            public int Price { get; set; }

            public bool IsSaled { get; set; }

            // Emlağın bağlı olduğu Satıcı Id'si
            public int SellerId { get; set; }

            // Navigation property - Emlak modeli ile Satıcı modeli arasında bir ilişki kuruyor
            public Seller Seller { get; set; }
        
    }
}
