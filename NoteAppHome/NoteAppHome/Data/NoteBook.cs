using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteAppHome.Data
{
    public class NoteBook
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }    
        public string Name { get; set; }

        [ForeignKey("UserId")]

        public virtual User User 
        {
            get; set;
        }


        public virtual List<Note> Notes { get; set; }


    }
}
