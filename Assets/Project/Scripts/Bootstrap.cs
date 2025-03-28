using BerserkPixel.Prata;
using DmitryRubic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private DialogManager _dialogManager;

    private void Awake()
    {
        //ServiceLocator.Instance.RegisterService(_dialogManager);


        //InitializeService();
    }
    private void InitializeService()
    {

    }

}
