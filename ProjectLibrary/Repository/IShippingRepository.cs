using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repository
{
    public interface IShippingRepository
    {
        List<Shipping> GetShippings();

        Shipping GetShippingById(int id);
        void SaveShipping(Shipping shipping);

        void DeleteShipping(Shipping shipping);
        void UpdateShipping(Shipping shipping);
    }


}
