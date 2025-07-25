using UnityEngine;

public class CameraMain : MonoBehaviour
{
    public Vector3 worldPosition;
    public Plane plane = new Plane(Vector3.forward, 0);

    void Update()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
        }
    }
}