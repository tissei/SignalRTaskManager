using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalRTaskManager.Models
{
    public class TaskModel : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool Done { get; set; }

        //[ForeignKey(nameof(ApplicationUser))]
        //public string ApplicationUserId { get; set; }

        //public virtual ApplicationUser ApplicationUser { get; set; }
    }
}