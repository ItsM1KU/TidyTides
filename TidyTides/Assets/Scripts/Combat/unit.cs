using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;
    public int damage;

    public int MaxHP;
    public int CurrentHP;


    public bool takeDamage(int dmg)
    {
        CurrentHP -= dmg;

        if (CurrentHP <= 0 )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void heal(int hp)
    {
        CurrentHP += hp;

        if(CurrentHP <= MaxHP )
        {
            CurrentHP = MaxHP;
        }
    }
}
