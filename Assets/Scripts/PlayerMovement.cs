using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Range(1f, 15f)] float _speed = 5f;
    [SerializeField, Range(50f, 150f)] float _speedRotation = 100f;

    private CharacterController _characterController;
    private float inputX;
    private float inputZ;
    private float _currentAttractionCharacter = 0;
    private float _gracityForce = 20;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        GravityHandling();
        MoveCharactor();
    }

    private void MoveCharactor()
    {
        Vector3 diraction = _characterController.transform.forward * inputZ;
        diraction.y = _currentAttractionCharacter;
        _characterController.transform.Rotate(Vector3.up * inputX * Time.deltaTime * _speedRotation);
        _characterController.Move(diraction * _speed * Time.deltaTime);
    }

    private void GravityHandling()
    {
        if (_characterController.isGrounded) {
            _currentAttractionCharacter -= _gracityForce * Time.deltaTime;
        } else {
            _currentAttractionCharacter = 0;
        }
    }
}
