using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_EntityFramework.Models
{
    public class Credential
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Client Client { get; set; }//null
        public int? ClientId { get; set; }// null
       

    }
}
