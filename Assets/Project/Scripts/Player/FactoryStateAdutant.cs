using BerserkPixel.Prata;
using UnityEngine;

public class FactoryStateAdutant : MonoBehaviour
{
    [SerializeField] private PlayerIsNearTrigger _playerisnearTrigger;
    [SerializeField] private AdutantView _adutantView;
    [SerializeField] private DialogManager _dialogManager;
    [SerializeField] private PlayerView _playerView;

    public void Init()
    {
    }
    public State Create(string stateName)
    {
        State gameState = MakeState(stateName);

        return gameState;
    }
    private State MakeState(string stateName)
    {
        switch (stateName)
        {
            case "IdleState":
                return new IdleState(_playerisnearTrigger, _adutantView, _playerView, _dialogManager);
        }
        return null;

    }
}
