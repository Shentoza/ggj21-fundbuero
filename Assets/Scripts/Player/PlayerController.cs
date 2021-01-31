using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;

[RequireComponent(typeof(RumbleComponent), typeof(SoundComponent))]
public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    
    protected RumbleComponent Rumbler;

    protected SoundComponent SoundComp;

    [SerializeField] private FoundItem CurrentItem;

    [Range(0, 5)] public float TimeBetweenSteps = 0.5f;

    [SerializeField] protected GameObject InspectGameObject;

    private bool _bInspectionRunning = false;
    

    public bool bInspectionRunning
    {
        get => _bInspectionRunning;

        set
        {
            _bInspectionRunning = value;
            InspectionStateChanged.Invoke(_bInspectionRunning);
        }
    }

    public UnityEvent<bool> InspectionStateChanged;

    private void Awake()
    {
        bInspectionRunning = false;
        ItemInspectController.OnItemSelected += NewItemSelected;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    private void Start()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
        Rumbler = GetComponent<RumbleComponent>();
        Rumbler.FinishedRumbleItem.AddListener(OnRumbleFinish);

        SoundComp = GetComponent<SoundComponent>();
        SoundComp.FinishedItem.AddListener(OnSoundFinish);
    }

    private void OnDisable()
    {
        ItemInspectController.OnItemSelected -= NewItemSelected;
    }

    public void OnUse(InputAction.CallbackContext Context)
    {
        if (Context.performed)
        {
            var GM = GameManager.Instance;
            switch(GameManager.Instance.State)
            {
                case GameManager.CurrentState.MailNotOpened:
                    UIControll.Instance.showMail();
                    break;
                case GameManager.CurrentState.MailOpen:
                    UIControll.Instance.StartSwitchToWareHouse();
                    GM.State = GameManager.CurrentState.Warehouse;
                    break;
                case GameManager.CurrentState.Warehouse:
                    SubmitCurrentItem();
                    UIControll.Instance.SwitchBackToOffice();
                    GM.State = GameManager.CurrentState.MailOpen;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public void SubmitCurrentItem()
    {
        CustomerSystem.Instance.SubmitItem(CurrentItem);
    }

    public void OnInspect(InputAction.CallbackContext Context)
    {
        Debug.Log("Inspect");
        if (Context.performed && GameManager.Instance.State == GameManager.CurrentState.Warehouse)
        {
            bInspectionRunning = true;
            PlayRumble();
        }
    }

    void NewItemSelected(FoundItem Item)
    {
        CurrentItem = Item;
    }

    void OnRumbleFinish()
    {
        if (CurrentItem)
        {
            Invoke("PlaySound", TimeBetweenSteps);
        }
    }

    void PlayRumble()
    {
        if (CurrentItem)
        {
            Rumbler.PlayRumble(CurrentItem.Rumble);
        }
    }

    void PlaySound()
    {
        SoundComp.PlaySound(CurrentItem.Sound);
    }

    void OnSoundFinish()
    {
        OnItemFinish();
    }

    void OnItemFinish()
    {
        bInspectionRunning = false;
    }
}