using UnityEngine;

[System.Serializable]
public class CharacterStatistic
{
    [SerializeField] private float _baseValue;
    [SerializeField] private float _currentValue;
    [SerializeField] private float _maxValue;

    public float GetBaseValue() => _baseValue;
    public float GetCurrentValue() => _currentValue;
    public float GetMaxValue() => _maxValue;
    
    public CharacterStatistic(float baseValue, float maxValue)
    {
        this._baseValue = baseValue;
        this._maxValue = maxValue;
        
        this._currentValue = baseValue;
    }

    public void UpdateCurrentByValue(float additionalAmount)
    {
        _currentValue = Mathf.Clamp(_currentValue + additionalAmount, 0, _maxValue);
    }

    public void UpdateMaxByValue(float additionalAmount)
    {
        _maxValue += additionalAmount;
    }
}