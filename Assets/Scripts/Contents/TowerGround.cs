using UnityEngine;

public class TowerGround : MonoBehaviour
{
    private TowerController towerController;

    private Color defalueColor;
    private Color currentColor;

    [SerializeField]
    private Color selectColor;

    [SerializeField]
    private Material currentMaterial;

    private void Awake()
    {
        currentMaterial = GetComponent<MeshRenderer>().material; 
        defalueColor = currentMaterial.color;
        currentColor = defalueColor;
    }

    public void SetTower(TowerController createTower)
    {
        towerController = createTower;
    }

    public void OnSelectionEffect()
    {
        currentMaterial.color = selectColor;
    }

    public void OnEndSelection()
    {
        currentMaterial.color = defalueColor;
    }
}
