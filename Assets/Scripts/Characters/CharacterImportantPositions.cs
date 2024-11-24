using UnityEngine;
using UnityEngine.Serialization;
using VInspector;

namespace Characters
{
    public class CharacterImportantPositions : MonoBehaviour
    {
        [SerializeField] private Vector3 _initialFightPosition;
        [SerializeField] private SerializedDictionary<ImportantPosition, Transform> _importantPositions;

        public Vector3 InitialFightPosition
        {
            get
            {
                if (_initialFightPosition == Vector3.zero)
                    _initialFightPosition = transform.position;
                    
                return _initialFightPosition;
            }
            set { _initialFightPosition = value; }
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