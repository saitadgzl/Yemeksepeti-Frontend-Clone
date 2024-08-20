using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yemeksepeti.Models
{
    public class baglanti
    {
        public int userid { get; set; }
        public int siparisID { get; set; }
        public List<SelectListItem> userList { get; set; }
        public List<SelectListItem> siparisList { get; set; }
    }
}