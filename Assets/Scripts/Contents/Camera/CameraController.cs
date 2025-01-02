using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform targetTransform;

    public bool isTargetFollow;

    [SerializeField]
    private float followSpeed = 10f;

    [SerializeField]
    private float cameraHeight = 25;

    new private Camera camera;
    private Vector3 targetPos;



    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        if(isTargetFollow)
        {
            targetPos = targetTransform.position;
            targetPos.y = cameraHeight;

            transform.position = Vector3.MoveTowards(transform.position, targetPos, followSpeed * Time.fixedDeltaTime);
        }

    }
}
