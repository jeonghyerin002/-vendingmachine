using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MachineManager : MonoBehaviour
{
    [Header("음료 템플릿")]
    public DrinkSO[] drinks;

    [Header("참조 UI")]
    public Button[] chooseDrinkButton;
    public Text[] drinkPrice;
    public Text userInformationText;

    [Header("유저 정보")]
    public int currentCoin = 0;
    public int currentThirsty = 0;
    public int currentHappy = 0;

    

    void Start()
    {
        UpdateUI();
    }
    
    void UpdateUI()
    {
        userInformationText.text = $"잔액  :{currentCoin} 원\n" +
                                   $"갈증  :{currentThirsty}\n" +
                                   $"만족도:{currentHappy}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
