using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimRepository
{
    public class ClaimsRepository
    {
        private Queue<Claims> _queueOfClaims = new Queue<Claims>();

        // Create
        public void AddClaimsToQueue(Claims claims)
        {
            _queueOfClaims.Enqueue(claims);
        }

        // Read
        public Queue<Claims> GetClaimsQueue()
        {
            return _queueOfClaims;
        }

        //Helper method
        public Claims GetClaimsByClaimID(int claimID)
        {
            foreach(Claims claims in _queueOfClaims)
            {
                if (claims.ClaimID == claimID)
                {
                    return claims;
                }
            }
            return null;
        }
    }
}
