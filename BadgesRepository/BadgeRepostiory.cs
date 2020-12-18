using System.Collections.Generic;

namespace BadgesRepository
{
    public class BadgeRepostiory
    {
        private Dictionary<int, List<string>> _dictionaryBadge = new Dictionary<int, List<string>>();

        // Create
        public void AddBadgeToDictionary(Badge badge)
        {
            _dictionaryBadge.Add(badge.BadgeID, badge.Doors);
        }

        // Read
        public Dictionary<int, List<string>> GetBadgeDictionary()
        {
            return _dictionaryBadge;
        }

        // Add a door
        public void UpdateDoorToBadge(int badgeID, string door)
        {
            KeyValuePair<int, List<string>> keyVP = GetBadgeByBadgeID(badgeID);
            keyVP.Value.Add(door);
        }

        // Delete
        public bool RemoveDoorFromBadge(int badgeID, string door)
        {
            KeyValuePair<int, List<string>> keyVP = GetBadgeByBadgeID(badgeID);

            if (badgeID == null || door == null)
            {
                return false;
            }

            int initialCount = keyVP.Value.Count;//_dictionaryBadge.Count;
            keyVP.Value.Remove(door);

            if (initialCount > keyVP.Value.Count)  //_dictionaryBadge.Count)
            {
               return true;
            }
            else
            {
                return false;
            }
        }

        // Helper method
        public KeyValuePair<int, List<string>> GetBadgeByBadgeID(int badgeID)

        {
            // KeyValuePair<int, List<string>> badgeKey = new KeyValuePair<int, List<string>>();
            foreach (KeyValuePair<int, List<string>> badgeKeyValuePair in _dictionaryBadge)
            {
                if (badgeKeyValuePair.Key == badgeID)
                {
                    return
                        badgeKeyValuePair;
                }
                return default;
            }
            return default;
            //return badgeKey;
        }
    }
}
