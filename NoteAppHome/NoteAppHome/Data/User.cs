using System.ComponentModel.DataAnnotations;

namespace NoteAppHome.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }  
        
        public string LastName { get; set; }

        public string Email { get; set; }   

        public string Password { get; set; }

        public virtual List<NoteBook> NoteBooks { get; set; }
    }
}
