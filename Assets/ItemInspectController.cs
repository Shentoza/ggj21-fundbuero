using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ItemInspectController : MonoBehaviour
{
    [SerializeField] private List<FoundItem> items = new List<FoundItem>();
    [SerializeField] private Transform itemViewTransform;
    [SerializeField] private Camera inspectCamera;

    [SerializeField] private FoundItem currentObject;
    private GameObject currentViewObject;
    private int currentIndex;
    private bool inspecting;

    [SerializeField] private float RotationSpeedMod = 2.0f;

    private Vector2 CurrentRotationInput;

    public UnityEvent OnItemSelectedEvent;

    private bool bInspectionRunning = false;

    public static event Action<FoundItem> OnItemSelected;

    private void Awake()
    {
        CustomerSystem.OnRequestStartedAction += OnNewRequest;
    }

    private void FixedUpdate()
    {
        if (currentViewObject)
        {
            var q = Quaternion.Euler(CurrentRotationInput.y, -CurrentRotationInput.x, 0.0f);
            currentViewObject.transform.localRotation =  currentViewObject.transform.localRotation *q;
        }
    }

    private void OnDestroy()
    {
        CustomerSystem.OnRequestStartedAction -= OnNewRequest;
    }

    public void EnterInspectionMode()
    {
        inspecting = true;

        //inspectCamera.gameObject.SetActive(true);

        // Show first item
        SetCurrentItem(items[0]);
    }

    public void OnInspectionStateChanged(bool newState)
    {
        bInspectionRunning = newState;
    }


    private void NextItem()
    {
        if (!inspecting)
        {
            return;
        }

        currentIndex++;
        if (currentIndex >= items.Count)
        {
            currentIndex = 0;
        }

        SetCurrentItem(items[currentIndex]);
    }

    private void PreviousItem()
    {
        if (!inspecting)
        {
            return;
        }

        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = items.Count - 1;
        }

        SetCurrentItem(items[currentIndex]);
    }

    public void OnCycle(InputAction.CallbackContext Context)
    {
        if (Context.performed && !bInspectionRunning)
        {
            float val = Context.ReadValue<float>();
            if (val > 0.4f)
            {
                NextItem();
            }
            else if (val < -0.4f)
            {
                PreviousItem();
            }
        }
    }

    public void OnLook(InputAction.CallbackContext Context)
    {
        CurrentRotationInput = Vector2.zero;
        if (Context.performed && !bInspectionRunning)
        {
            CurrentRotationInput = Context.ReadValue<Vector2>()*RotationSpeedMod;
        }
        else if (bInspectionRunning)
        {
            CurrentRotationInput = Vector2.zero;
        }
    }

    public void OnNewRequest(FoundItem RequestedItem, int NumRandomItems)
    {
        items.Clear();
        items.Add(RequestedItem);
        for (int i = 0; i < NumRandomItems; ++i)
        {
            items.Add(GameManager.Instance.RandomizeItem());
        }

        UtilClass.Shuffle(items);
        EnterInspectionMode();
    }

    public void SetCurrentItem(FoundItem InFoundItem)
    {
        currentObject = InFoundItem;
        Destroy(currentViewObject);
        currentViewObject = Instantiate(currentObject.Visuals.Visual, itemViewTransform);
        OnItemSelectedEvent.Invoke();
        OnItemSelected?.Invoke(InFoundItem);
    }
}