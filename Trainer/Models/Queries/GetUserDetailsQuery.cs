using System;

namespace SUAI.SpbGeographic.Trainer.Models.Queries
{
    public class GetUserDetailsQuery
    {
        public Guid UserId { get; }

        public GetUserDetailsQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
