using System;

namespace Mediator.API.App.UseCase.Sample
{
    public class SampleResponse
    {
        public string FullName { get; set; }
        public string BirthCity { get; set; }
        public DateTime Birthday { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
    }
}
