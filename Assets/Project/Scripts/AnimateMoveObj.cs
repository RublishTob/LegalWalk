using DG.Tweening;
using UnityEngine;

public class AnimateMoveObj : MonoBehaviour
{
    private Transform _transform;

    private Tween tween;

    private void Awake()
    {
        _transform = transform;
    }

    private void OnEnable()
    {
        _transform.position = _transform.position;
        tween = transform.DOMoveY(transform.position.y + 0.033f, 1f).SetLoops(-1,LoopType.Yoyo);
    }
    private void OnDisable()
    {
        tween = null;
    }
}
