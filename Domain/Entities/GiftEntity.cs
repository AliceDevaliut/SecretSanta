namespace Domain.Entities
{
    public class GiftEntity
    {
        public Guid Id { get; set; }

        
        public Guid UserId { get; set; }
                        
        public string Description { get; set; }

        public virtual UserEntity User { get; }


    }
}
