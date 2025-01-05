using UnityEngine;

public class ResaleTower : MonoBehaviour
{
    [SerializeField]
    private TowerGround owner;

    public void OnResaleTower()
    {
        var towerController = owner.TowerController;

        if (towerController == null)
            return;

        GameController.Instance.AddMoney(towerController.TowerProfile.ResalePrice);

        owner.SetTower(null);
        Destroy(towerController.gameObject);

    }
}
