using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(NonDrawingGraphic))]
public class InputManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PointerEventData eventData;
    private Vector2 startedPos;
    public Vector2 deltaPos;
    public int maxDistance = 100;
    
    #region Singleton
    public static InputManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion
    
    public void OnPointerDown(PointerEventData _eventData)
    {
        eventData = _eventData;
        startedPos = eventData.position;
    }

    public void OnPointerUp(PointerEventData _eventData)
    {
        eventData = null;
        startedPos = Vector2.zero;
        deltaPos = Vector2.zero;
    }

    private void FixedUpdate()
    {
        if (eventData == null) return;
        
        deltaPos = eventData.position - startedPos;
        deltaPos.x = Mathf.Clamp(deltaPos.x, -maxDistance, maxDistance);
        deltaPos.y = Mathf.Clamp(deltaPos.y, -maxDistance, maxDistance);
        startedPos = eventData.position;
    }
}
