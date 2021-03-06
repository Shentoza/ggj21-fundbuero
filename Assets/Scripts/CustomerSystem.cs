using System;
using UnityEngine;
using UnityEngine.Events;

public class CustomerSystem : MonoBehaviour
{
    public static CustomerSystem Instance;
    
    [SerializeField]protected FoundItem CurrentRequest;

    public UnityEvent OnRequestStarted;

    public static event Action<FoundItem,int> OnRequestStartedAction;
    
    
    public UnityEvent OnRequestSubmitted;
    public static event Action<float> OnRequestSubmittedAction;

    [SerializeField]
    protected int NumOfRandomItems = 3;

    void Start()
    {
        if (Instance)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }
    
    void OnDestroy()
    {
        OnRequestStartedAction = null;
    }

    public void StartRequest()
    {
        CurrentRequest = GameManager.Instance.RandomizeItem();
        OnRequestStarted.Invoke();
        OnRequestStartedAction?.Invoke(CurrentRequest, NumOfRandomItems);
    }

    public void SubmitItem(FoundItem Item)
    {
        float quota = CurrentRequest.Compare(Item);
        OnRequestSubmitted.Invoke();
        OnRequestSubmittedAction?.Invoke(quota);
        
        StartRequest();
    }
}
