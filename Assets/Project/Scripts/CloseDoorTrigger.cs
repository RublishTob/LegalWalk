using Unity.XR.CoreUtils;
using UnityEngine;

public class CloseDoorTrigger : MonoBehaviour
{
    [SerializeField] private DoorView _door;
    private void OnTriggerEnter(Collider other)
    {
        //_door.Close();
        Debug.Log("exit");
    }
}
