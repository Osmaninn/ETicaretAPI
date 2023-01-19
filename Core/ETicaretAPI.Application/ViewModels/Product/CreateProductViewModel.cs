using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.ViewModels.Product
{
    public class CreateProductViewModel
    {
        public string ProductName{ get; set; }

        public int Stock{ get; set; }

        public float Price{ get; set; }
    }
}
