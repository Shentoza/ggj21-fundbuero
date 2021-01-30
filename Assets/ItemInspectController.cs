using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ItemInspectController : MonoBehaviour
{
    [SerializeField] private List<GameObject> items;
    [SerializeField] private Transform itemViewPosition;
    [SerializeField] private Camera inspectCamera;

    private GameObject currentObject;
    private int currentIndex;
    private bool inspecting;

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
        currentObject = Instantiate(items[0], itemViewPosition);
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
        Destroy(currentObject);
        currentObject = Instantiate(items[currentIndex], itemViewPosition);
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
        Destroy(currentObject);
        currentObject = Instantiate(items[currentIndex], itemViewPosition);
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
}
