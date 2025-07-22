using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Drink", menuName = "machine/Drinks")]
public class DrinkSO : ScriptableObject
{
    [Header("���� ����")]
    public string drinkName = "�ݶ�";
    public int drinkPrice = 1000;
    public int thirstRecovery = 50;          //�����ؼ� ��ġ
    public int affection = 50;                   //ȣ����
}
