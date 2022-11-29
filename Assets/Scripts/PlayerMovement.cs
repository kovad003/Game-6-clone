using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// @Daniel K.
/// Initial commit: 29-Nov-2022
/// Last modified: 29-Nov-2022 by @Daniel K.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    /* EXPOSED FIELDS */
    [SerializeField] private float moveSpeed = 5.0f;

    /* HIDDEN FIELDS */
    private Vector2 _rawInputKeys;
    private Vector2 _rawInputMouse;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        
        ConfineMouse();
    }

    private void Update()
    {
        Move();
        FaceCursor();
    }

    /* FUNCTIONS */
    private void ConfineMouse()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void FaceCursor()
    {
        Vector2 screenPosition = Mouse.current.position.ReadValue();
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        // Debug.Log("worldPosition.x => " + worldPosition.x);
        // Debug.Log("worldPosition.y => " + worldPosition.y);

        if (worldPosition.x > 0)
        {
            transform.localScale = new Vector2(Mathf.Sign(worldPosition.x), 1f);
        }
        if (worldPosition.x < 0)
        {
            transform.localScale = new Vector2(Mathf.Sign(worldPosition.x), 1f);
        }
    }
    private void Move()
    {
        Vector2 playerVelocity = new Vector2(_rawInputKeys.x * moveSpeed, _rawInputKeys.y * moveSpeed);
        _rigidbody.velocity = playerVelocity;
    }

    /* EVENT FUNCTIONS */
    private void OnMove(InputValue inputValue)
    {
        _rawInputKeys = inputValue.Get<Vector2>();
        Debug.Log("Keys => " + _rawInputKeys);
    }
}
