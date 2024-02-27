using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Truyền vào Transform của nhân vật mà camera sẽ theo dõi
    public float smoothSpeed = 0.125f; // Độ mượt khi camera di chuyển

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position; // Vị trí mà camera muốn di chuyển đến
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Di chuyển camera một cách mượt mà
            transform.position = smoothedPosition;
            transform.position.Set(smoothedPosition.x, smoothedPosition.y, -10f);
        }
    }
}