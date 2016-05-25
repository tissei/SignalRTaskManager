using System.ComponentModel.DataAnnotations;

namespace SignalRTaskManager.Models
{
    public abstract class Entity
    {
        [Key]
        public long Id { get; set; }
    }
}