using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Drink", menuName = "machine/Drinks")]
public class DrinkSO : ScriptableObject
{
    [Header("음료 정보")]
    public string drinkName = "콜라";
    public int drinkPrice = 1000;
    public int thirstRecovery = 50;          //갈증해소 수치
    public int affection = 50;                   //호감도
}
