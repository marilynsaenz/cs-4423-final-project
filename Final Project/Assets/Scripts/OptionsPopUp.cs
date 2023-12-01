using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsPopUp : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            ToggleOptionsMenu();
        }
    }

    public void ToggleOptionsMenu()
    {
        if (optionsMenu != null)
        {
            optionsMenu.SetActive(!optionsMenu.activeSelf);
        }
    }
}
