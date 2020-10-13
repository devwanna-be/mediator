using System.Collections.Generic;

namespace Mediator.API.App.Model
{
    public class ResponseOne<T> where T : class
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }

    public class ResponseList<T> where T : class
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
