using System.ComponentModel.DataAnnotations.Schema;

namespace SignalRTaskManager.Models
{
    public class TaskModel : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool Done { get; set; }

        public long UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }
    }
}