using UnityEngine.Events;
using UnityEngine;
using VInspector;

public class AnimationEventInvoker : MonoBehaviour
{
    [SerializeField] private SerializedDictionary<AnimationEventType, UnityEvent> _animationEvents;

    public void PlayAnimationEvent(AnimationEventType eventType)
    {
        _animationEvents[eventType]?.Invoke();
    }

    public enum AnimationEventType
    {
        CASTER,
        TARGET
    }
}