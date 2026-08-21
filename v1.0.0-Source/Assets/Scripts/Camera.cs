using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public class Camera : MonoBehaviour
{
    public float cameraSensibility = 10f;
    public float rotationSpeed = 250f;
    private Vector2 cameraMoves = Vector2.zero;
    private Vector2 mouseMoves = Vector2.zero;
    private bool Q = false;
    private bool E = false;
    private bool RClick = false;

    public void OnMove(InputValue value)
    {
        cameraMoves = value.Get<Vector2>();
    }

    public void OnMouse(InputValue value)
    {
        mouseMoves = value.Get<Vector2>();
    }

    public void OnQ(InputValue value)
    {
        if (value.isPressed)
        {
            Q = true;
        }
        else
        {
            Q = false;
        }
    }

    public void OnE(InputValue value)
    {
        if (value.isPressed)
        {
            E = true;
        }
        else
        {
            E = false;
        }
    }

    public void OnRClick(InputValue value)
    {
        if (value.isPressed == true)
        {
            RClick = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            RClick = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void Update()
    {
        float positionS = Time.unscaledDeltaTime * cameraSensibility;
        float rotationS = Time.unscaledDeltaTime * rotationSpeed;
        transform.position += transform.right * cameraMoves.x * positionS + transform.forward * cameraMoves.y * positionS;

        if (E == true)
        {
            transform.position += transform.up * positionS;
        }
        if (Q == true)
        {
            transform.position += -transform.up * positionS;
        }

        if (RClick == true)
        {
            transform.Rotate(-mouseMoves.y * rotationS, mouseMoves.x * rotationS, 0f);
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
    }
}
