using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private RectTransform background; // Assign the joystick background in the Inspector
    [SerializeField] private RectTransform handle; // Assign the joystick handle in the Inspector
    private Vector2 inputVector;

    private void Awake()
    {
        // Ensure the background and handle are assigned
        if (background == null)
        {
            background = GetComponent<RectTransform>();
        }

        if (handle == null && transform.childCount > 0)
        {
            handle = transform.GetChild(0).GetComponent<RectTransform>();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(background, eventData.position, eventData.pressEventCamera, out position);

        position.x = (position.x / background.sizeDelta.x) * 2;
        position.y = (position.y / background.sizeDelta.y) * 2;

        inputVector = new Vector2(position.x, position.y);
        inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

        handle.anchoredPosition = new Vector2(inputVector.x * (background.sizeDelta.x / 2), inputVector.y * (background.sizeDelta.y / 2));
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }

    public Vector2 GetInput()
    {
        Debug.Log($"Joystick Input: {inputVector}");
        return inputVector;
    }
}
