using System.Collections.Generic;

namespace Iskatel.Model
{
    public class Source
    {
        public string Title { get; set; }
        public List<Person> Authors { get; set; }
        public Date CreateDate { get; set; }
        public List<string> Genres { get; set; }
        public List<Human> Characters { get; set; }
    }
}
