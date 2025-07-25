using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;
using static Unity.VisualScripting.Dependencies.Sqlite.SQLite3;


public class MachineManager : MonoBehaviour
{
    [Header("���� ���ø�")]
    public DrinkSO[] drinks;

    //[Header("���� ���ø�")]
    //public CoinButtonSO[] coinButtons;

    [Header("���� UI")]
    public Button[] chooseDrinkButton;
    public Button returnCoinButton;
    public Text[] drinkInformationText;
    public Text userInformationText;
    public Text putInCoinCountText;

    [Header("���ι�ư")]
    public Button[] coinButton;
    public int machineCoin = 0;

    [Header("���� ����")]
    public int currentCoin = 0;
    public int currentThirsty = 0;
    public int currentHappy = 0;

    [Header("���������ü���")]
    public Text drinkfullText;
    public GameObject drinkFullPopup;
    public Button closeDrinkFullPopupButton;

    public bool isEnoughHappy = false;
    public bool isEnoughthirstRecovery = false;

    void Start()
    {
        UpdateUI();
        InitButton();
        drinkFullPopup.SetActive(false);
        closeDrinkFullPopupButton.onClick.AddListener(CloseDrinkFullPopup);
    }

    void UpdateUI()
    {
        userInformationText.text = $"�ܾ�  :{currentCoin} ��\n" +
                                   $"����  :{currentThirsty}\n" +
                                   $"������:{currentHappy}";

        putInCoinCountText.text =  $"���� �ݾ�  :{machineCoin}��\n";

        for(int i = 0; i < drinks.Length; i++)  
        {
            if(machineCoin >= drinks[i].drinkPrice)
                chooseDrinkButton[i].interactable = true;
            else
                chooseDrinkButton[i].interactable = false;
        }
        for(int i = 0; i < drinks.Length; i++)
        {
            string drinkName = drinks[i].name;
            int drinkPrice = drinks[i].drinkPrice;
            drinkInformationText[i].text = $"{drinkName}\n" +
                                           $"{drinkPrice}";
        }


    }
   
    public void ChooseDrink(int index)
    {
        UseCoin(drinks[index]);
        UpdateUI();
    }

    void UseCoin (DrinkSO drink)
    {

        if(machineCoin >= drink.drinkPrice)
        {
            machineCoin -= drink.drinkPrice;
            Debug.Log($"{drink.drinkPrice}���� ����߽��ϴ�.");

            UserEmotion(drink);
        }
    }

    string AfterDrinkUserStatusText()
    {
        if(currentHappy == 100 && currentThirsty <= 0)
        {
            isEnoughHappy = true;
            isEnoughthirstRecovery = true;
            return "���� �ؼ�, ������";
        }

        if (currentThirsty <= 0)
        {
            isEnoughthirstRecovery = true;
            return "���� �ؼ�";
        }
            
        if (currentHappy == 100)
        {
            isEnoughHappy = true;
            return "������";
        }

        return "";
    }

    void UserEmotion(DrinkSO drinks)
    {
        currentHappy += drinks.affection;
        currentThirsty -= drinks.thirstRecovery;

        currentHappy = Mathf.Clamp(currentHappy, 0, 100);
        currentThirsty = Mathf.Clamp(currentThirsty, 0, 100);

        string status = AfterDrinkUserStatusText();
        if (isEnoughHappy == true || isEnoughthirstRecovery == true)
        {
            drinkfullText.text = $"����� {status} �����Դϴ�.";

            drinkFullPopup.SetActive(true);
        }
    }
    void InitButton()
    {
        for (int i = 0; i < chooseDrinkButton.Length; i++)
        {
            int index = i;
            chooseDrinkButton[i].onClick.AddListener(() => ChooseDrink(index));
        }

        for (int i = 0; i < coinButton.Length; i++)
        {
            int index = i;
            coinButton[i].onClick.AddListener(() => ClickMachineCoinButton(index));
        }

        returnCoinButton.onClick.AddListener(ClickReturnCoinButton);
    }

    void ClickMachineCoinButton(int index)
    {
        int CoinType = 0;

        if(index == 0)
        {
            CoinType = 100;
        }
        if (index == 1)
        {
            CoinType = 500;
        }
        if (index == 2)
        {
            CoinType = 1000;
        }

        if(currentCoin >= CoinType)
        {
            machineCoin += CoinType;
            currentCoin -= CoinType;
            UpdateUI();
        }
       
    }

    void ClickReturnCoinButton()
    {
        if(returnCoinButton)
        {
            if(machineCoin > 0)
            {
                currentCoin += machineCoin;
                machineCoin = 0;
                UpdateUI();
            }
            else if(machineCoin <= 0)
            {
                Debug.Log("����� ������ ��� ����߽��ϴ�");
            }
            
        }
    }

    public void CloseDrinkFullPopup()
    {
        drinkFullPopup.SetActive(false);
        UpdateUI();
    }

    
    void Update()
    {

    }

}
