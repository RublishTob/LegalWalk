using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class HelperView : MonoBehaviour
{
    [SerializeField] private TMP_Text _conversationText;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _uiConversation;
    [SerializeField] private XRSimpleInteractable _interactable;

    [SerializeField] private List<string> _textToSay = new();

    private Camera _arSessionOrigin;

    private bool _isPlayer = false;
    private bool _isStartTalk = false;
    private bool _isTalking = false;
    private bool _objectIsVisible = false;
    private float _rotationSpeed = 5.0f;
    private string _questName;
    //private TutorialState _questState = TutorialState.NonActive;
    [field: SerializeField] public GameObject Bag { get; private set; }
    [field: SerializeField] public GameObject Ground { get; private set; }

    private void Start()
    {
        _arSessionOrigin = Camera.main;
        _interactable.selectEntered.AddListener(PlayerTap);
        Bag.SetActive(false);
        Ground.SetActive(false);
    }
    private void PlayerTap(SelectEnterEventArgs arg0)
    {
        if (_isStartTalk == false)
        {
            _isStartTalk = true;
            StartTalking();
        }
    }
    public void SetIsTalk(bool isTalk)
    {
        if (_isStartTalk == false)
        {
            _isStartTalk = true;
            StartTalking();
            _isStartTalk = isTalk;
            _isTalking = isTalk;
            _animator.SetBool("isTalk", isTalk);
            _animator.SetBool("isStartTalk", isTalk);
        }
    }
    public void SetVisibleObjectsQuest(bool isVisible)
    {
        _objectIsVisible = isVisible;
    }
    public void SetVisibleMouseQuest(bool isVisible)
    {
        gameObject.SetActive(isVisible);
    }
    public void SetQuestName(string questName)
    {
        _questName = questName;
    }
    public void SetVisibleUiConversation(bool isVisible)
    {
        _uiConversation.SetActive(isVisible);
    }
    public void SetQuestState(TutorialState state)
    {
        //_questState = state;
    }
    public void SetText(List<string> textQuest)
    {
        _textToSay.Clear();
        _textToSay.AddRange(textQuest);
    }
    public void PlayerIsNear()
    {
        _isPlayer = true;
    }
    public void PlayerIsOut()
    {
        _isPlayer = false;
    }
    void Update()
    {
        if (_isPlayer == false)
        {
            _isStartTalk = false;
            _isTalking = false;
            _animator.SetBool("isTalk", false);
            _animator.SetBool("isStartTalk", false);
            return;
        }

        if (_arSessionOrigin != null)
        {
            Vector3 direction = _arSessionOrigin.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }

        if (_isStartTalk)
        {
            _animator.SetBool("isStartTalk", true);
            _animator.SetBool("isTalk", true);
        }
        else
        {
            _animator.SetBool("isTalk", false);
            _animator.SetBool("isStartTalk", false);
        }
    }
    private void StartTalking()
    {
        //StartCoroutine(StartConversation());
    }
}
public enum TutorialState
{

}