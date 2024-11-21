using UnityEngine;
using VInspector;

namespace Characters
{
    public class CharacterImportantPositions : MonoBehaviour
    {
        [SerializeField] private Vector3 initialFightPosition;
        [SerializeField] private SerializedDictionary<ImportantPosition, Transform> _importantPositions;

        public Vector3 InitialFightPosition
        {
            get
            {
                if (initialFightPosition == Vector3.zero)
                    initialFightPosition = transform.position;
                    
                return initialFightPosition;
            }
            set { initialFightPosition = value; }
        }

        public Vector3 GetDesiredPosition(ImportantPosition positionEnum)
        {
            if (_importantPositions.ContainsKey(positionEnum))
                return _importantPositions[positionEnum].position;
        
            return Vector3.zero;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(InitialFightPosition, 1);
        }
    }   
}