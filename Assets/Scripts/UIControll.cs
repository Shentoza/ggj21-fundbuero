using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControll : MonoBehaviour
{
    /* switch cameras on
     * #1 turn off Display 
     * #2 open Door 
     * #3 Switch camera
     */

    public static UIControll Instance;

    [Header("Cameras")] public Camera officeCam;
    public Camera warehouseCam;

    [Header("UI")] public GameObject display;
    public Button button;

    [SerializeField] private Animator doorAnimator;

    private void Start()
    {
        display.SetActive(false);
        Instance = this;
    }

    public void showMail()
    {
        display.SetActive(true);
        button.GetComponentInChildren<Text>().text = "Switch to Warehouse";
        GameManager.Instance.State = GameManager.CurrentState.MailOpen;
    }

    public void SwitchCameras()
    {
        if (officeCam.enabled && display.activeSelf == false)
        {
            showMail();
        }

        else if (officeCam.enabled && display.activeSelf)
        {
            // play Door Animation
            StartSwitchToWareHouse();
        }
        else if (warehouseCam.enabled)
        {
            SwitchBackToOffice();
        }
    }

    public void StartSwitchToWareHouse()
    {
        StartCoroutine(SwitchToWarehouse());
    }

    public void SwitchBackToOffice()
    {
        button.GetComponentInChildren<Text>().text = "Switch to Warehouse";
        display.SetActive(true);

        officeCam.enabled = true;
        warehouseCam.enabled = false;
        GameManager.Instance.State = GameManager.CurrentState.MailOpen;
    }

    IEnumerator SwitchToWarehouse()
    {
        doorAnimator.SetBool("isPlaying", true);
        display.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        // actiavte changes
        button.GetComponentInChildren<Text>().text = "Submit current Item";
        button.onClick.AddListener(SubmitItem);
        display.SetActive(false);
        officeCam.enabled = false;
        warehouseCam.enabled = true;
        GameManager.Instance.State = GameManager.CurrentState.Warehouse;
    }

    public void SubmitItem()
    {
        button.onClick.RemoveListener(SubmitItem);
        PlayerController.Instance.SubmitCurrentItem();
    }
}