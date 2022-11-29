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
    
    
    /* HIDDEN FIELDS */
    private Vector2 _rawInput;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /* EVENT FUNCTIONS */
    private void OnMove(InputValue inputValue)
    {
        _rawInput = inputValue.Get<Vector2>();
        Debug.Log(_rawInput);
    }
}
