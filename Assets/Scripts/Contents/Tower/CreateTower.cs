using UnityEngine;

public class CreateTower : MonoBehaviour
{
    [SerializeField]
    private TowerGround ownerGround;

    [SerializeField]
    private CreateTowerData[] createTowerDatas;

    [SerializeField]
    private Transform towerSocket;

    public void OnCreateTower(int index)
    {
        if (!GameController.Instance.UseMoney(createTowerDatas[index].Price))
            return;

        var tower = Instantiate(createTowerDatas[index].TowerPrefab, towerSocket);
        tower.transform.localPosition = createTowerDatas[index].CreateLocalPosition();

        var towerController = tower.GetComponent<TowerController>();
        towerController.SetCreateInfo(ownerGround);
    }
}
