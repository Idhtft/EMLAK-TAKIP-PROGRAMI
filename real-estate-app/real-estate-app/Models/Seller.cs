using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace real_estate_app.Models
{
    public class Seller
    {
        public int SellerId { get; set; }

       
        public string Name { get; set; }
        public string Surname { get; set; }


        public string Phone { get; set; }
    }
}
