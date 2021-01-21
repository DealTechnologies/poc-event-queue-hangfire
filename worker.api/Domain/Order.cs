using System;

namespace worker.api.Domain
{
    public class Order
    {
        public Order()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Message { get; set; }
        public string Id { get; set; }
        public bool Active { get; set; }
    }
}
