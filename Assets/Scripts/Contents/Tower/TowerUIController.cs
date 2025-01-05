using UnityEngine;
using UnityEngine.UI;

public class TowerUIController : MonoBehaviour
{
    [SerializeField]
    private TowerController owner;

    //[SerializeField]
    //private GameObject uiCanvas;

    [SerializeField]
    private GameObject attackRangeShape;
    public void OnDrawInfo()
    {
        // uiCanvas?.SetActive(true);
        attackRangeShape.SetActive(true);

        float attackRange = owner.TowerProfile.AttackRange * 0.35f;
        attackRangeShape.transform.localScale = new Vector3(attackRange, 0.1f, attackRange);
    }

    public void OffDrawInfo()
    {
        // uiCanvas?.SetActive(false);
        attackRangeShape.SetActive(false);
    }
}
