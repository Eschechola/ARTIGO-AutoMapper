using System;

namespace NETCoreAutoMapper.Models
{
    public class ClientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
