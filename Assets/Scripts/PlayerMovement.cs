using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// @Daniel K.
/// Initial commit: 29-Nov-2022
/// Last modified: 30-Nov-2022 by @Daniel K.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    /* EXPOSED FIELDS */
    [Header("Moving")]
    [SerializeField] private float moveSpeed = 5.0f;
    [Header("Dashing")]
    [SerializeField] private float dashingTime = 0.5f;
    [Tooltip("Value is used to multiple the player's velocity!")]
    [SerializeField] [Range(1, 10)] private float dashPower = 1;
    [SerializeField] [Range(1,10)] private float dashCooldown = 1;
    
    /* HIDDEN FIELDS */
    private Vector2 _rawInputKeys;
    private Vector2 _rawInputMouse;
    private Rigidbody2D _rigidbody;
    private TrailRenderer _trailRenderer;
    private bool _canDash = true;
    private bool _isDashing; // false by default
    
    private void Start()
    {
        // Binding Components:
        _rigidbody = GetComponent<Rigidbody2D>();
        _trailRenderer = GetComponent<TrailRenderer>();
        
        // Calling Methods:
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

        if (worldPosition.x > _rigidbody.position.x)
        {
            // Debug.Log("worldPosition.x > _rigidbody.position.x");
            transform.localScale = new Vector2(Mathf.Sign(+1), 1f);
        }
        if (worldPosition.x < _rigidbody.position.x)
        {
            // Debug.Log("worldPosition.x < _rigidbody.position.x");
            transform.localScale = new Vector2(Mathf.Sign(-1), 1f);
        }
        
        // Getting position data:
        // Debug.Log("Playa.X: " + _rigidbody.position.x);
        // Debug.Log("Mouse.X: " + worldPosition.x);
    }
    private void Move()
    {
        Vector2 playerVelocity = new Vector2(_rawInputKeys.x * moveSpeed, _rawInputKeys.y * moveSpeed);
        if (!_isDashing)
        {
            _rigidbody.velocity = playerVelocity;
            _trailRenderer.emitting = false;
        }
        if (_isDashing)
        {
            _rigidbody.velocity = dashPower * playerVelocity;
            _trailRenderer.emitting = true;
        }
    }

    /* EVENT FUNCTIONS */
    private void OnMove(InputValue inputValue)
    {
        _rawInputKeys = inputValue.Get<Vector2>();
        Debug.Log("Keys => " + _rawInputKeys);
    }
    
    private void OnDash(InputValue inputValue)
    {
        // if (!_canDash) return;
        StartCoroutine(DashCoroutine());
        Debug.Log("Keys => SPACE");
    }
    
    /* COROUTINE */
    private IEnumerator DashCoroutine()
    {
        // Condition:
        if (!_canDash) yield break;
        
        _canDash = false;
        _isDashing = true;
        yield return new WaitForSeconds(dashingTime);
        _isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        _canDash = true;
    }
}
