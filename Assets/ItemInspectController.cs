using System;
using System.Collections.Generic;
using UnityEngine;
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

    [SerializeField] private float RotationSpeedMod = 1.0f;

    private Vector2 CurrentRotationInput;

    private void Awake()
    {
        CustomerSystem.OnRequestStartedAction += OnNewRequest;
    }

    private void FixedUpdate()
    {
        if (currentViewObject)
        {
            var q = Quaternion.Euler(CurrentRotationInput.y, -CurrentRotationInput.x, 0.0f);
            currentViewObject.transform.localRotation = (q * currentViewObject.transform.localRotation);
        }
    }

    private void OnDestroy()
    {
        CustomerSystem.OnRequestStartedAction -= OnNewRequest;
    }

    private void Start()
    {
        if (items.Count == 0)
        {
            Debug.LogWarning("No items to inspect added!");
        }
    }

    public void EnterInspectionMode()
    {
        if (inspecting)
        {
            return;
        }

        inspecting = true;

        foreach (Camera cam in Camera.allCameras)
        {
            cam.gameObject.SetActive(false);
            Debug.Log("Disable");
        }

        inspectCamera.gameObject.SetActive(true);

        // Show first item
        SetCurrentItem(items[0]);
    }

    private void OpenItemDetails()
    {
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

    private void Update()
    {
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            Debug.Log("TEST");
            EnterInspectionMode();
        }

        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            Debug.Log("L");
            PreviousItem();
        }

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            Debug.Log("R");
            NextItem();
        }
    }

    public void OnLook(InputAction.CallbackContext Context)
    {
        CurrentRotationInput = Context.performed ? Context.ReadValue<Vector2>() : Vector2.zero;
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
    }

    public void SetCurrentItem(FoundItem InFoundItem)
    {
        currentObject = InFoundItem;
        Destroy(currentViewObject);
        itemViewTransform.rotation = Quaternion.identity;
        currentViewObject = Instantiate(currentObject.Visuals.Visual, itemViewTransform);
    }
}