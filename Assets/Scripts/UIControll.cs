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

    [Header("Cameras")]
    public Camera officeCam;
    public Camera warehouseCam;

    [Header("UI")]
    public GameObject display;
    public Button button;

    [SerializeField]
    private Animator doorAnimator;

    private void Start()
    {
        display.SetActive(false);
    }

    public void SwitchCameras()
    { 
        if (officeCam.enabled && display.activeSelf == false)
        {
            display.SetActive(true);
            button.GetComponentInChildren<Text>().text = "Switch to Warehouse";
        }

        else if (officeCam.enabled && display.activeSelf)
        {
            // play Door Animation
            StartCoroutine(SwitchToWarehouse());


        }
        else if (warehouseCam.enabled)
        {
            button.GetComponentInChildren<Text>().text = "Switch to Warehouse";
            display.SetActive(true);

            officeCam.enabled = true;
            warehouseCam.enabled = false;
        }
    }

    IEnumerator SwitchToWarehouse()
    {
        doorAnimator.SetBool("isPlaying", true);
        display.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        // actiavte changes
        button.GetComponentInChildren<Text>().text = "Switch to Office";
        display.SetActive(false);
        officeCam.enabled = false;
        warehouseCam.enabled = true;

    }
}
