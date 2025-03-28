using UnityEngine;

public class ObjectFollowCamera : MonoBehaviour
{
    [SerializeField] private float _offset;
    [SerializeField] private Vector3 _euler;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }
    public void Update()
    {
        transform.position = _camera.transform.position + _camera.transform.forward * _offset;

        var relativePosition = _camera.transform.position - transform.position;
        relativePosition.y = 0;
        transform.rotation = Quaternion.LookRotation(relativePosition) * Quaternion.Euler(_euler);
    }

}
