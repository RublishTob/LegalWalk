using UnityEngine;

public class SpeakState : State
{
    private HelperView _helperView;

    public SpeakState(HelperView helperView)
    {
        _helperView = helperView;
    }

    public override void Exit()
    {
    }

    public override void Start()
    {
    }

    public override void Update()
    {
        //StartConversation();
    }

    //private void StartConversation()
    //{
    //    _uiConversation.SetActive(true);

    //    for (int i = 0; i < _textToSay.Count; i++)
    //    {
    //        _conversationText.text = _textToSay[i];
    //        yield return new WaitForSeconds(2f);
    //    }

    //    _uiConversation.SetActive(false);

    //    if (_questName == "Ground")
    //    {
    //        Ground.SetActive(_objectIsVisible);
    //    }
    //    if (_questName == "Bag")
    //    {
    //        Bag.SetActive(_objectIsVisible);
    //    }
    //    if (_questState == TutorialState.Complete)
    //    {
    //        gameObject.SetActive(false);
    //    }
        
    //}
}
