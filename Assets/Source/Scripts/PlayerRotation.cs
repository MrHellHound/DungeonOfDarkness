using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Transform playerTransform;
    
    public Camera mainCamera;

    public Vector3 mousePos;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition) - playerTransform.position;
        mousePos.Normalize();
        float rot_z = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
