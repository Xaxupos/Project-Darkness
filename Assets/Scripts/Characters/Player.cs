using System.Collections.Generic;
using Items;
using UnityEngine.Serialization;

namespace Characters
{
    public class Player : Character
    {
        //just for debug purpose untill there is inventory system
        public List<Item> playerEquippedItems;
        
        #region SingletonSetup
            private static Player _instance;
            
            public static Player Instance
            {
                get
                {
                    if (_instance == null)
                    {
                        _instance = FindFirstObjectByType<Player>();
                    }

                    return _instance;
                }
            }
                    
            private void Awake()
            {
                if (_instance == null)
                {
                    _instance = this as Player;
                }
                else if (_instance != this)
                {
                    Destroy(gameObject);
                }
            }
            
            private void OnDestroy()
            {
                if (_instance == this) _instance = null;
            }
        #endregion
    }   
}