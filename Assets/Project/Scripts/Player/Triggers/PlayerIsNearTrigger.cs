using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerIsNearTrigger : MonoBehaviour
{
    public bool PlayerIsNear {  get; private set; }

    private void Start()
    {
        PlayerIsNear = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerView>(out var origin))
        {
            PlayerIsNear = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerView>(out var origin))
        {
            PlayerIsNear = true;
        }
    }
}
