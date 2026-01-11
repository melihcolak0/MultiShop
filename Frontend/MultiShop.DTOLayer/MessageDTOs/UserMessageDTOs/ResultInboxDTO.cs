using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DTOLayer.MessageDTOs.UserMessageDTOs
{
    public class ResultInboxDTO
    {
        public int UserMessageId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Subject { get; set; }
        public string MessageDetail { get; set; }
        public bool IsRead { get; set; }
        public DateTime SendDate { get; set; }
        public string SenderName { get; set; }
        public string SenderSurname { get; set; }
        public string SenderEmail { get; set; }
    }
}
