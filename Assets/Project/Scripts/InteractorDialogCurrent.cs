using System;
using BerserkPixel.Prata;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractorDialogCurrent : MonoBehaviour, IDialogInteract
{
    [SerializeField] private InputActionReference action;
    [SerializeField] private Interaction interaction;
    private bool isInteract = false;

    private void OnEnable()
    {
        action.action.performed += Performed;
    }
    private void OnDisable()
    {
        action.action.performed -= Performed;
    }

    private void Update()
    {
        Debug.Log($"Interaction is {interaction}");
        if (interaction != null && isInteract)
        {
            Interact();
            isInteract = false;
        }
    }
    private void Performed(InputAction.CallbackContext context)
    {
        if (interaction != null)
        {
            Interact();
        }
    }
    public void CancelInteraction()
    {
        interaction = null;
        DialogManager.Instance.HideDialog();
    }
    public void Interact()
    {
        Debug.Log("Interact");
        Debug.Log("BeginConversation");
        DialogManager.Instance.BeginConversation(interaction);

    }
    public void ReadyForInteraction(Interaction newInteraction)
    {
        interaction = newInteraction;
        Debug.Log($"Find Interaction this is == {interaction}");
    }
}
