using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFStest.Models;


namespace CFStest.Helpers
{
    public class TestDataGenerator
    {
        public static Pet CreatePetData()
        {
            Random random = new Random();

            return new Pet
            {
                id = random.Next(1000, 9999),
                name = "Dog_" + random.Next(1000, 9999),
                status = "available"
            };
        }
    }
}
