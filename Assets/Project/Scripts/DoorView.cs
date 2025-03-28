using DG.Tweening;
using UnityEngine;

public class DoorView : MonoBehaviour
{
    private Tween tween;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }
    public void Open()
    {
        tween = transform.DOMoveY(4f, 1f);
    }
    public void Close()
    {
        tween = transform.DOMoveY(startPosition.y, 1f);
    }
}
