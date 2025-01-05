using UnityEngine;

public class TowerGround : MonoBehaviour
{
    private TowerController towerController;
    public TowerController TowerController { get {  return towerController; } }

    private Material currentMaterial;

    [SerializeField]
    private GameObject uiConrtroller;

    [SerializeField]
    private Color selectColor;

    private Color defalueColor;
    private Color currentColor;

    private void Awake()
    {
        currentMaterial = GetComponent<MeshRenderer>().material; 
        defalueColor = currentMaterial.color;
        currentColor = defalueColor;
    }

    public void SetTower(TowerController createTower)
    {
        towerController = createTower;
        towerController?.OnDrawInfo();
    }

    public void OnSelectionEffect()
    {
        currentMaterial.color = selectColor;
        uiConrtroller.SetActive(true);

        OnDrawTowerInfo();
    }

    public void OnEndSelection()
    {
        currentMaterial.color = defalueColor;
        uiConrtroller.SetActive(false);
        towerController?.offDrawInfo();
    }

    private void OnDrawTowerInfo()
    {
        if (towerController == null)
            return;

        towerController?.OnDrawInfo();
    }
}
