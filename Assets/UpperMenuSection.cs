using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpperMenuSection : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyCount;
    [SerializeField] private Button firstTableButton;
    [SerializeField] private Button secondTableButton;
    [SerializeField] private Button thirdTableButton;

    private float _currency;
    private Button _selectedButton;

    private void Start()
    {
        _selectedButton = firstTableButton;
        _selectedButton.interactable = false;
    }

    private void OnEnable()
    {
        firstTableButton.onClick.AddListener(TurnOnFirstTable);
        secondTableButton.onClick.AddListener(TurnOnSecondTable);
        thirdTableButton.onClick.AddListener(TurnOnThirdTable);
    }

    private void TurnOnFirstTable()
    {
        _selectedButton.interactable = true;
        _selectedButton = firstTableButton;
        _selectedButton.interactable = false;
        TableManager.Instance.TurnOnFirstTable();
    }
    
    private void TurnOnSecondTable()
    {
        _selectedButton.interactable = true;
        _selectedButton = secondTableButton;
        _selectedButton.interactable = false;
        TableManager.Instance.TurnOnSecondTable();
    }
    
    private void TurnOnThirdTable()
    {
        _selectedButton.interactable = true;
        _selectedButton = thirdTableButton;
        _selectedButton.interactable = false;
        TableManager.Instance.TurnOnThirdTable();
    }

    public void ChangeCurrencyAmount(float newValue)
    {
        _currency = newValue;
        currencyCount.text = newValue.ToString();
    }
    
    private void OnDisable()
    {
        firstTableButton.onClick.RemoveListener(TurnOnFirstTable);
        secondTableButton.onClick.RemoveListener(TurnOnSecondTable);
        thirdTableButton.onClick.RemoveListener(TurnOnThirdTable);
    }
}
