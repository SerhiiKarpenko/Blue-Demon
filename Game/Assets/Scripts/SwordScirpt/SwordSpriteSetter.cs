using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SwordStats))]
public class SwordSpriteSetter : MonoBehaviour
{
    private void Start()
    {
        GetComponent<SwordStats>().SetSwordSprite(); 
    }
}
