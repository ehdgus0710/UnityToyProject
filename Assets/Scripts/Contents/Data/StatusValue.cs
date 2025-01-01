using UnityEngine;

[System.Serializable]
public class StatusValue
{
    [SerializeField]
    private StatusInfoType statusInfoType;

    public StatusInfoType StatusInfoType { get { return statusInfoType; } }
    [SerializeField]
    private float value;
    public float Value { get { return value; } }

    [SerializeField]
    private float maxValue;
    public float MaxValue { get { return maxValue; } }

    public void ValueCopy(StatusValue statusValue)
    {
        this.maxValue = statusValue.MaxValue;
        this.value = statusValue.Value > this.maxValue ? this.maxValue : statusValue.Value;
    }

    public float AddValue(float _value)
    {
        this.value += _value;
        this.value = this.value > maxValue ? maxValue : this.value;

        return this.value;
    }

    public void OnValueincrease(StatusValue statusValue)
    {
        OnValueincrease(statusValue.MaxValue);
    }

    public void OnValueincrease(float value)
    {
        this.maxValue += value;
        this.value = this.maxValue;
    }

    public void SetValue(float _value)
    {
        this.value = maxValue < _value ? maxValue : _value;
    }

    public StatusValue(StatusInfoType statusInfoType, float value = 0f, float maxValue = 0f)
    {
        this.statusInfoType = statusInfoType;
        this.value = value;
        this.maxValue = maxValue;
    }
}
