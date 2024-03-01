using ProjectLibrary.DataAccess;
using ProjectLibrary.ObjectBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.Repository
{
    public class ShippingRepository : IShippingRepository
    {
        public List<Shipping> GetShippings() => ShippingDAO.Instance.GetShippings();

        public void SaveShipping(Shipping shipping) => ShippingDAO.Instance.SaveShipping(shipping);
        public Shipping GetShippingById(int id) => ShippingDAO.Instance.GetShippingById(id);
        public void DeleteShipping(Shipping shipping) => ShippingDAO.Instance.DeleteShipping(shipping);
        public void UpdateShipping(Shipping shipping) => ShippingDAO.Instance.UpdateShipping(shipping);
    }

}
