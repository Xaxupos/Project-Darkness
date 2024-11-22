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

    public void SetBaseValue(float value)
    {
        _baseValue = value;
        _currentValue = value;
    }

    public void SetMaxValue(float value)
    {
        _maxValue = value;
    }

    public void UpdateCurrentValue(float additionalAmount)
    {
        _currentValue = Mathf.Clamp(_currentValue + additionalAmount, 0, _maxValue);
    }
}