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

    private void FixedUpdate()
    {
        HandleRotation();
    }

    private void HandleRotation()
    {
        mousePos = mainCamera.ScreenToWorldPoint(new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Mathf.Abs(playerTransform.position.z - mainCamera.transform.position.z)));
        
        Vector3 diff = mousePos - playerTransform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
