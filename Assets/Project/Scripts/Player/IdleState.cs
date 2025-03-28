using BerserkPixel.Prata;
using UnityEngine;

public class IdleState : State
{
    private float angleThreshold = 50f;
    private PlayerIsNearTrigger _playerisnearTrigger;
    private AdutantView _adutantView;
    private PlayerView _playerView;
    private DialogManager _dialogManager;
    public IdleState(PlayerIsNearTrigger playerisnearTrigger, AdutantView adutantView, PlayerView playerView, DialogManager dialogManager)
    {
        _playerisnearTrigger = playerisnearTrigger;
        _adutantView = adutantView;
        _playerView = playerView;
        _dialogManager = dialogManager;
    }

    public override void Start()
    {
        _dialogManager.OnTalkPhrase += StartPhrase;
    }
    private void StartPhrase()
    {
        _adutantView.AnimateTemporary("isTalk", 5f);
    }

    public override void Update()
    {
        if ( _playerisnearTrigger.PlayerIsNear)
        {
            Vector3 directionToTarget = _playerView.transform.position - _adutantView.transform.position;
            float angle = Vector3.Angle(_adutantView.transform.forward, directionToTarget);

            float dotProduct = Vector3.Dot(_adutantView.transform.right, directionToTarget);

            if (angle > angleThreshold)
            {
                _adutantView.RotateToSomething(_playerView.transform.position);
            }
            else
            {
                _adutantView.StopRight();
            }
        }

    }
    public override void Exit()
    {
        _dialogManager.OnTalkPhrase -= StartPhrase;
    }

}
