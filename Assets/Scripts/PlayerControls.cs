using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] InputAction movement;
    void Start()
    {

    }

    void OnEnable()
    {
        movement.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = movement.ReadValue<Vector2>().x;
        float yThrow = movement.ReadValue<Vector2>().y;

        float xOffset = .1f;
        float newXPos = transform.localPosition.x + xOffset;

        transform.localPosition = new Vector3(xOffset, transform.localPosition.y, transform.localPosition.z);
    }
}
