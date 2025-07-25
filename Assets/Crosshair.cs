using UnityEngine;


public class Follow : MonoBehaviour
{
    void Update()
    {
        transform.position = Camera.main.GetComponent<CameraMain>().worldPosition;
    }
}

