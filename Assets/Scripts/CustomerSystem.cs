using System;
using UnityEngine;
using UnityEngine.Events;

public class CustomerSystem : MonoBehaviour
{
    protected FoundItem CurrentRequest;

    public UnityEvent OnRequestStarted;

    public event Action<FoundItem> OnRequestStartedAction;
    
    
    public UnityEvent OnRequestSubmitted;
    public event Action<float> OnRequestSubmittedAction;

    public void StartRequest()
    {
        CurrentRequest = GameManager.Instance.RandomizeItem();
        OnRequestStarted.Invoke();
        OnRequestStartedAction?.Invoke(CurrentRequest);
    }

    public void SubmitItem(FoundItem Item)
    {
        float quota = CurrentRequest.Compare(Item);
        
        OnRequestSubmitted.Invoke();
        OnRequestSubmittedAction?.Invoke(quota);
    }
}
