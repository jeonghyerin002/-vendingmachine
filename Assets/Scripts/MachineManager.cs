using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MachineManager : MonoBehaviour
{
    [Header("���� ���ø�")]
    public DrinkSO[] drinks;

    [Header("���� UI")]
    public Button[] chooseDrinkButton;
    public Text[] drinkPrice;
    public Text userInformationText;

    [Header("���� ����")]
    public int currentCoin = 0;
    public int currentThirsty = 0;
    public int currentHappy = 0;

    

    void Start()
    {
        UpdateUI();
    }
    
    void UpdateUI()
    {
        userInformationText.text = $"�ܾ�  :{currentCoin} ��\n" +
                                   $"����  :{currentThirsty}\n" +
                                   $"������:{currentHappy}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
