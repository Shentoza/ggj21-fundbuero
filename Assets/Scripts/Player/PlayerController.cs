using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

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
            bInspectionRunning = true;
            PlayRumble();
        }
    }

    public void OnSubmit(InputAction.CallbackContext Context)
    {
        if (Context.performed)
        {
            SubmitCurrentItem();
        }
    }

    public void SubmitCurrentItem()
    {
        CustomerSystem.Instance.SubmitItem(CurrentItem);
    }

    public void OnInspect(InputAction.CallbackContext Context)
    {
        Debug.Log("Inspect");
        if (Context.performed)
        {
            InspectGameObject.SetActive(!InspectGameObject.activeSelf);
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