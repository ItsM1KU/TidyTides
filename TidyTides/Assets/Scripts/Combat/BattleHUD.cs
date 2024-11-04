using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text lvlText;

    [SerializeField] Slider HPslider;

    public void setupHUD(unit unit)
    {
        nameText.text = unit.unitName;
        lvlText.text = "Lvl " + unit.unitLevel;
        HPslider.maxValue = unit.MaxHP;
        HPslider.value = unit.CurrentHP;
    }

    public void setHP(int hp)
    {
        HPslider.value = hp; 
    }
}
