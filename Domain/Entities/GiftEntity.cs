namespace Domain.Entities
{
    public class GiftEntity
    {
        public Guid Id { get; set; }

        
        public Guid UserId { get; set; }

        public virtual UserEntity User { get; }

        
        public string Description { get; set; }


    
    }
}
