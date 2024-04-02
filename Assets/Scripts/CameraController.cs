using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;

    public float scrollSpeed = 5f;

    public float minY = 20f;
    public float maxY = 95f;

    private Vector3 startPosOfCam = new(38.6f, 78.4f, -21.6f);
    private Vector3 returnBackPosOfCam = new(38.6f, 78.4f, -21.6f);

    private void Update()
    {
        if (GameManager.gameIsOver)
        {
            enabled = false;
            return;
        }

        // Camera 4 directional control
        if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(panSpeed * Time.deltaTime * Vector3.forward, Space.World);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(panSpeed * Time.deltaTime * Vector3.back, Space.World);
        }

        if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(panSpeed * Time.deltaTime * Vector3.left, Space.World);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(panSpeed * Time.deltaTime * Vector3.right, Space.World);
        }

        // [CamOrigin]
        // Return back to origin camera position
        if (Input.GetKeyDown(KeyCode.C))
        {
            returnBackPosOfCam = transform.position;
            transform.position = startPosOfCam;
        }
        
        // Return back to the last save camera position when [CamOrigin] is used (default = origin position)
        if(Input.GetKeyDown(KeyCode.M))
        {
            transform.position = returnBackPosOfCam;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 800 * scrollSpeed * Time.deltaTime;

        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
