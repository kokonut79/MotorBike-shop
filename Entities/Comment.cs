using System.ComponentModel.DataAnnotations.Schema;

namespace MotorbikeShop.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Desc { get; set; }

        public int MotorbikeId { get; set; }

        [ForeignKey(nameof(MotorbikeId))]
        public Motorbike Motorbike { get; set; }
    }
}
