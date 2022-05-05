using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    public virtual void SkillMechanic()
    { }
    
    public virtual IEnumerator SkillMechanicNumerator()
    {
        yield return null;
    }
}
