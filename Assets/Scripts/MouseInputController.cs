using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInputController : MonoBehaviour
{
    [SerializeField]    
    private Camera mainCamara;
    private Ray mouseRay = new Ray();

    private TowerGround selectTowerGround;

    private bool isSelectTower;

    private void Awake()
    {
        mouseRay.origin = transform.position;
        mouseRay.direction = Vector3.down;
    }

    public bool GetMouseWorldPoint()
    {
        mouseRay = mainCamara.ScreenPointToRay(Mouse.current.position.ReadValue());

        RaycastHit hitData;
        bool isResult = Physics.Raycast(mouseRay, out hitData, 1000, GetLayerMasks.TowerGround);

        if(isResult)
        {
            selectTowerGround = hitData.transform.GetComponent<TowerGround>();
            selectTowerGround.OnSelectionEffect();
        }
        return isResult;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if (!isSelectTower)
        {
            if(GetMouseWorldPoint())
                isSelectTower = true;
        }
        else
        {

        }
    }

    public void OnCancle(InputAction.CallbackContext context)
    {
        if(isSelectTower)
        {
            selectTowerGround.OnEndSelection();
            isSelectTower = false;
        }
    }
}
