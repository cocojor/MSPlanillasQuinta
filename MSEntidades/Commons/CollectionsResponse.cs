using System;
using System.Collections.Generic;
using System.Text;

namespace MSEntidades.Commons
{
    public class CollectionsResponse<T>
    {
        public CollectionsResponse() { }
        public List<T> Data { get; set; }
        public int page { get; set; }
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public string MySelf { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public int MaxId { get; set; }
    }
}
