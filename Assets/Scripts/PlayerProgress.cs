using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerProgress : MonoBehaviour
{
    public List<PlayerProgressLevel> levels;

    public Slider ExperienceBar;
    public TextMeshProUGUI LevelValueTMP;

    private int _levelValue = 1;
    private float _experienceCurrentValue = 0;
    private float _experienceTargetValue = 100;

    public void Start()
    {
        DrawUI();
        SetLevel(_levelValue);
    }

    public void AddExperience(float value)
    {
        _experienceCurrentValue += value;
        if(_experienceCurrentValue >= _experienceTargetValue)
        {
            _levelValue += 1;
            _experienceCurrentValue = _experienceCurrentValue - _experienceTargetValue;
            SetLevel(_levelValue);
        }
        DrawUI();
    }

    private void SetLevel(int value)
    {
        _levelValue = value;

        var CurrentLevel = levels[_levelValue - 1];
        _experienceTargetValue = CurrentLevel.ExperienceForTheNextLevel;
        GetComponent<FireballCaster>().Damage = CurrentLevel.FireballDamage;
        GetComponent<GranadeCaster>().damage = CurrentLevel.GrenadeDamage;
    }
    private void DrawUI()
    {
        ExperienceBar.value = _experienceCurrentValue;
        LevelValueTMP.text = _levelValue.ToString();
    }
}
