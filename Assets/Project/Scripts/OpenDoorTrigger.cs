using Unity.XR.CoreUtils;
using UnityEngine;

public class OpenDoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorView _door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<XROrigin>(out var origin))
        {
            _door.Open();
        }
        Debug.Log("enter");
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<XROrigin>(out var origin))
        {
            _door.Close();
        }
    }
}
