using System.ComponentModel.DataAnnotations;

namespace SignalRTaskManager.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
    }
}