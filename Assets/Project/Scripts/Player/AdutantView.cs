using System.Collections;
using UnityEngine;

public class AdutantView : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private float _rotationSpeed = 5.0f;
    private Coroutine _coroutineTalking;
    public void AnimateTemporary(string nameOfAnimate, float seconds)
    {
        Debug.Log(nameOfAnimate);
        if (_coroutineTalking != null)
        {
            _coroutineTalking = null;
            _coroutineTalking = StartCoroutine(AnimateBySeconds(nameOfAnimate, seconds));
        }
        _coroutineTalking = StartCoroutine(AnimateBySeconds(nameOfAnimate, seconds));
    }
    public void StopAnimateTemporary()
    {
        _coroutineTalking = null;
    }
    public void StartLeft()
    {
        _animator.SetBool("isLeft", true);
    }
    public void StartRight()
    {
        _animator.SetBool("isRight", true);
    }
    public void StopLeft()
    {
        _animator.SetBool("isLeft", false);
    }
    public void StopRight()
    {
        _animator.SetBool("isRight", false);
    }
    private void StartTalking()
    {
        _animator.SetBool("isTalk", true);
    }
    private void StopTalking()
    {
        _animator.SetBool("isTalk", false);
    }
    private void StartWalking()
    {
        _animator.SetBool("isWalk", true);
    }
    private void StopWalking()
    {
        _animator.SetBool("isWalk", false);
    }
    private IEnumerator AnimateBySeconds(string nameOfAnimate, float seconds)
    {
        float timerConstraint = seconds;
        float timer = 0f;
        
        while (true)
        {
            if (timer > timerConstraint)
            {
                _animator.SetBool(nameOfAnimate, false);
                _coroutineTalking = null;
                yield break;
            }
            yield return null;
            _animator.SetBool(nameOfAnimate, true);
            timer += Time.deltaTime;
        }
    }
    private void MoveToSomething(Vector3 position)
    {
        _animator.SetBool("isWalk", true);
    }
    public void RotateToSomething(Vector3 position)
    {
        _animator.SetBool("isRight", true);
        Vector3 direction = position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }
}
