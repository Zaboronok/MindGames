using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    private Rigidbody _objectRigidbody;
    private Transform _objectGrabPointTransform;

    private void Awake()
    {
        _objectRigidbody = GetComponent<Rigidbody>();
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        _objectGrabPointTransform = objectGrabPointTransform;
        _objectRigidbody.useGravity = false;
    }

    public void Drop()
    {
        _objectGrabPointTransform = null;
        _objectRigidbody.useGravity = true;
    }

    private void FixedUpdate()
    {
        if (_objectGrabPointTransform != null)
        {
            _objectRigidbody.MovePosition(_objectGrabPointTransform.position);
        }
    }
}
