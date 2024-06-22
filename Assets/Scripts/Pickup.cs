using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] Transform _pickupArea;
    [SerializeField] LayerMask _pickupLayerMask;
    [SerializeField] Transform _objectGrabPointTransform;

    private float pickupDistance = 2f;
    private ObjectGrabbable _objectGrabbable;
    private bool _isGrabbable;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(_objectGrabbable == null)
            {
                if (Physics.Raycast(_pickupArea.position, _pickupArea.forward, out RaycastHit hit, pickupDistance, _pickupLayerMask))
                {
                    if (hit.transform.TryGetComponent(out _objectGrabbable))
                    {
                        _objectGrabbable.Grab(_objectGrabPointTransform);
                    }
                }
            } else {
                _objectGrabbable.Drop();
                _objectGrabbable = null;
            }

        }
    }
}
