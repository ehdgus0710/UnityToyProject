using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : Sington<GameController>
{
    [SerializeField]
    private int currentMoney = 500;

    [SerializeField]
    private int life = 5;

    [SerializeField]
    private TextMeshProUGUI lifeText;
    [SerializeField]
    private TextMeshProUGUI moneyText;
    [SerializeField]
    private TextMeshProUGUI waveText;

    public UnityEvent<int> moneyChangeEvent;
    public UnityEvent<int> lifeChangeEvent;
    public UnityEvent gameoverEvent;
    private bool isDead = false;

    private void Reset()
    {
        life = 5;
        currentMoney = 500;
    }

    private void Start()
    {
        lifeText.text = life.ToString();
        moneyText.text = currentMoney.ToString();
    }

    public void AddMoney(int money)
    {
        currentMoney += money;
        moneyText.text = currentMoney.ToString();
        moneyChangeEvent.Invoke(currentMoney);
    }

    public bool UseMoney(int price)
    {
        if(currentMoney < price)
            return false;

        currentMoney -= price;
        moneyText.text = currentMoney.ToString();
        moneyChangeEvent.Invoke(currentMoney);

        return true;
    }

    public void LifeDown()
    {
        --life;
        lifeText.text = life.ToString();
        lifeChangeEvent?.Invoke(life);

        if (!isDead && life < 0)
        {
            GameOver();
        }
    }

    public void SetCurrentWave(int wave)
    {
        waveText.text = $"Wave : {wave.ToString()}";
    }

    private void GameOver()
    {
        isDead = true;
        GameTimeManager.Instance.SetTimeScale(0f);
        gameoverEvent?.Invoke();
    }

    public void OnRestart()
    {
        GameTimeManager.Instance.SetTimeScale(1f);
        SceneManager.LoadScene(0);
        Reset();
    }
}
