using System.Reflection.Metadata;

namespace NoteAppHome.Models
{
    public class NoteVm
    {
        public int Id { get; set; }

        public string Content { get; set; }    

        public int NoteBookId { get; set; }

        public string NoteBookName { get; set; }
        public string Title { get; set; }
    }
}
