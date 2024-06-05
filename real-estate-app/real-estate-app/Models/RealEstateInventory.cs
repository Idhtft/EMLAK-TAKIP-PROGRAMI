using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace real_estate_app.Models
{
    public class RealEstateInventory
    {

        public int RealEstateInventoryId { get; set; }

        public int RealEstateId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }

        public int RoomNumb { get; set; }

        public int SquareMeter { get; set; }

        public int Price { get; set; }

        public bool IsSaled { get; set; }
        public RealEstate RealEstate { get; set; }
    }
}
