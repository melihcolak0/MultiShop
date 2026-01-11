using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOLayer.CargoDTOs.CargoDetailDTOs
{
    public class ResultCargoDetailDTO
    {
        public int CargoDetailId { get; set; }
        public string SenderCustomer { get; set; }
        public string SenderCustomerName { get; set; }
        public string SenderCustomerSurname { get; set; }
        public string ReceiverCustomer { get; set; }
        public string ReceiverCustomerName { get; set; }
        public string ReceiverCustomerSurname { get; set; }
        public int Barcode { get; set; }
        public int CargoCompanyId { get; set; }        
        public string CargoCompanyName { get; set; }        
    }
}
