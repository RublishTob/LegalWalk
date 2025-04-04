using UnityEngine;

namespace BerserkPixel.Prata
{
    public class DialogInteractor : MonoBehaviour
    {
        [SerializeField] private float detectionRadius;
        [SerializeField] private Transform origin;
        [SerializeField] private LayerMask targetMask;
        [SerializeField] private GameObject bubbleSprite;
        [SerializeField] private float timeForReset = 2f;

        [SerializeField] private Interaction interaction;
        [SerializeField] private DialogRenderer _dialogRenderer;
        [SerializeField] private DialogManager _dialogManager;

        private bool isBubbleShown;
        private IDialogInteract dialogInteract;
        private float timeSinceFirstShown;

        private void Awake()
        {
            HideBubble();
        }

        private void AddDialogRenderer()
        {
            _dialogManager.ChangeDialogRenderer(_dialogRenderer);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("EnterCollider");
            if (!interaction.HasAnyDialogLeft())
            {
                if (isBubbleShown)
                {
                    isBubbleShown = false;
                    HideBubble();   
                }
                return;
            }

            if (other.transform.TryGetComponent(out IDialogInteract interact))
            {
                Debug.Log("EnterDialog");
                if (!isBubbleShown)
                {
                    isBubbleShown = true;
                    ShowBubble();
                }
                dialogInteract = interact;
                timeSinceFirstShown = timeForReset;
                interact.ReadyForInteraction(interaction);
                AddDialogRenderer();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (dialogInteract != null)
            {
                dialogInteract.CancelInteraction();
                dialogInteract = null;
            }

            if (isBubbleShown)
            {
                isBubbleShown = false;
                HideBubble();
            }
            if (dialogInteract == null)
            {
                timeSinceFirstShown -= Time.deltaTime;

                if (timeSinceFirstShown <= 0)
                {
                    interaction.Reset();
                }
            }
        }

        private void Update()
        {
            //Collider[] hit = Physics.OverlapSphere(origin.position, detectionRadius,targetMask);
            //if (hit.Length > 0)
            //{
            //    if (!interaction.HasAnyDialogLeft())
            //    {
            //        if (isBubbleShown)
            //        {
            //            isBubbleShown = false;
            //            HideBubble();
            //        }

            //        return;
            //    }

            //    if (hit.transform.TryGetComponent(out IDialogInteract interact))
            //    {
            //        if (!isBubbleShown)
            //        {
            //            isBubbleShown = true;
            //            ShowBubble();
            //        }

            //        dialogInteract = interact;

            //        timeSinceFirstShown = timeForReset;

            //        interact.ReadyForInteraction(interaction);
            //    }
            //}
            //else
            //{
            //    if (dialogInteract != null)
            //    {
            //        dialogInteract.CancelInteraction();
            //        dialogInteract = null;
            //    }

            //    if (isBubbleShown)
            //    {
            //        isBubbleShown = false;
            //        HideBubble();
            //    }
            //}

            //// we subtract the reset timer if the player leaves
            //if (dialogInteract == null)
            //{
            //    timeSinceFirstShown -= Time.deltaTime;

            //    if (timeSinceFirstShown <= 0)
            //    {
            //        interaction.Reset();
            //    }
            //}
        }

        private void ShowBubble()
        {
            bubbleSprite.SetActive(true);
        }

        private void HideBubble()
        {
            bubbleSprite.SetActive(false);
        }

        private void OnDrawGizmosSelected()
        {
            //Gizmos.DrawWireSphere(origin.position, detectionRadius);
        }
    }
}