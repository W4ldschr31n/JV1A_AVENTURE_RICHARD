using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;

public class PowerDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject imageBindController, textBindKeyboard;
    private InputDisplayManager inputDisplayManager;


    // Start is called before the first frame update
    private void Start()
    {
        inputDisplayManager = FindObjectOfType<InputDisplayManager>();
        UpdateDisplay();
    }
    void OnEnable()
    {
        InputDisplayManager.onInputPressed += UpdateDisplay;
    }

    private void OnDisable()
    {
        InputDisplayManager.onInputPressed -= UpdateDisplay;
    }

    private void UpdateDisplay()
    {
        textBindKeyboard.SetActive(inputDisplayManager.isKeyboard);
        imageBindController.SetActive(!inputDisplayManager.isKeyboard);
    }
}
