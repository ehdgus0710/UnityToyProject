using TMPro;
using UnityEngine;

public class UpgradeTower : MonoBehaviour
{
    [SerializeField]
    private TowerGround ownerGround;

    [SerializeField]
    private CreateTowerData[] upgradeTowerDatas;

    [SerializeField]
    private Transform towerSocket;

    [SerializeField]
    private GameObject upgradeButton;

    [SerializeField]
    private TextMeshProUGUI priceText;

    public void OnUpgradeTower(int index)
    {
        if (!GameController.Instance.UseMoney(upgradeTowerDatas[index].Price))
            return;

        var tower = Instantiate(upgradeTowerDatas[index].TowerPrefab, towerSocket);
        tower.transform.localPosition = upgradeTowerDatas[index].CreateLocalPosition();

        var prevTowerController = ownerGround.TowerController;
        Destroy(prevTowerController.gameObject);

        var towerController = tower.GetComponent<TowerController>();
        towerController.SetCreateInfo(ownerGround);
        ownerGround.SetTower(towerController);
        upgradeTowerDatas = towerController.CreateTowerDatas;
        int count = upgradeTowerDatas.Length;

        if (count == 0)
            upgradeButton.SetActive(false);
        else
        {
            priceText.text = $"Price : {upgradeTowerDatas[0].Price.ToString()}";
        }
    }

    public void SetUpgeradeTowerData(CreateTowerData[] upgradeDatas)
    {
        upgradeTowerDatas = upgradeDatas;
    }
}
