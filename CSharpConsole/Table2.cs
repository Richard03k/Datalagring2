using System.ComponentModel.DataAnnotations;

namespace CSharpConsole
{
    public class Table2
    {
        [Key]
        public int UserID { get; set; }

        public string Name { get; set; }

        public Table2(string name)
        {
            Name = name;
        }
    }

}   