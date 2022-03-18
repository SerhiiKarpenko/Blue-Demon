using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicLoadCandelsFires : MonoBehaviour
{
    [SerializeField] private Image[] candleFires;
    private int lenght;

    private void Start()
    {
        lenght = candleFires.Length;
        StartCoroutine(DynamicCandelFireAppearing());
        
    }


    IEnumerator DynamicCandelFireAppearing()
    {
        for(int i = 0; i < candleFires.Length; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.3f, 0.7f));
            candleFires[i].enabled = true;

            if (i == lenght)
                yield break;
        }
    }

}
