using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NoteAppHome.Data
{
    public class Note
    {
        [Key]
        public int Id { get; set; }


        public string Title { get; set; }

        public int NoteBookId { get; set; }

        public string Content { get; set; }

        [ForeignKey("NoteBookId")]

        public virtual NoteBook NoteBook
        {
            get; set;
        }
    }
}
