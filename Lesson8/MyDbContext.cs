
using Microsoft.EntityFrameworkCore;

namespace Lesson8
{
    public class MyDbContext: DbContext
    {
        internal object Customer;

        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
        public object Apartment { get; internal set; }

        internal Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
