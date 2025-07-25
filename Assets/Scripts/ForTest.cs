using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ForTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i <10; i+=1)                //i를 0으로 시작해서 i가 10미만이 될때까지 i를 2씩 더한다.
        {
            for (int j = 1; j < 10; j+=1)                //i를 0으로 시작해서 i가 10미만이 될때까지 i를 2씩 더한다.
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
