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
    }

    private void Update()
    {
        Move();
        FlipSprite();
    }

    /* FUNCTIONS */
    private void Move()
    {
        // Vector3 delta = _rawInput * (moveSpeed * Time.deltaTime);
        // transform.position += delta;

        // Vector2 playerVelocity = new Vector2 (_rawInput.x * moveSpeed, _rigidbody.velocity.y);
        // _rigidbody.velocity = playerVelocity;

        Vector2 playerVelocity = new Vector2(_rawInputKeys.x * moveSpeed, _rawInputKeys.y * moveSpeed);
        _rigidbody.velocity = playerVelocity;

        // bool playerHasHorizontalSpeed = Mathf.Abs(_rigidbody.velocity.x) > Mathf.Epsilon;

    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_rigidbody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rigidbody.velocity.x), 1f);
        }
    }

    /* EVENT FUNCTIONS */
    private void OnMove(InputValue inputValue)
    {
        _rawInputKeys = inputValue.Get<Vector2>();
        Debug.Log("Keys => " + _rawInputKeys);
    }

    private void OnLook(InputValue inputValue)
    {
        _rawInputMouse = inputValue.Get<Vector2>();
        Debug.Log("Mouse => " + _rawInputMouse);
    }

}
