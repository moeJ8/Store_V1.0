using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Store.Models
{
    public class Order
    {
        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
