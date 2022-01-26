using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCollectiable : MonoBehaviour
{
    [SerializeField]
    GameObject UIPressE;

    [SerializeField]
    GameObject itemToTake;

    private void Start()
    {
        UIPressE.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject machineGun = Instantiate(itemToTake, transform.position, transform.rotation);
            PlayerController.instance.availableGun.Add(machineGun.GetComponent<Gun>());
            PlayerController.instance.CurrentGun++;
            PlayerController.instance.SwitchGun();
            machineGun.transform.parent = PlayerController.instance.gunArm;
            machineGun.transform.localPosition = Vector3.zero;
            machineGun.transform.localRotation = Quaternion.Euler(Vector3.zero);
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
            UIPressE.SetActive(true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
            UIPressE.SetActive(false);
    }
}
