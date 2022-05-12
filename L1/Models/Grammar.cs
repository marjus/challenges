using System.ComponentModel.DataAnnotations;

namespace L1.Models
{
    public  class Grammar
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string  Image { get; set; }
        

   //     public abstract void playSound();

        public bool isSameAs(int id)
        {
            return this.Id == id;
        }
    }
}
