using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ForTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i <10; i+=1)                //i�� 0���� �����ؼ� i�� 10�̸��� �ɶ����� i�� 2�� ���Ѵ�.
        {
            for (int j = 1; j < 10; j+=1)                //i�� 0���� �����ؼ� i�� 10�̸��� �ɶ����� i�� 2�� ���Ѵ�.
            {
                Debug.Log($"{i} x {j} = {i * j}");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
