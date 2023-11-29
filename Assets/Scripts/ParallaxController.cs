using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public Transform cam;  // Make cam public to assign from editor
    Vector3 camStartPos;
    float distance;
    float yDistance;
    GameObject[] backgrounds;
    Material[] mat;
    float[] backspeed;
    float farthestBack;
    [Range(0.01f, 0.05f)]
    public float parallaxSpeed;

    void Start()
    {
        // Check if the camera is assigned, if not, try to find the main camera
        if (cam == null)
        {
            cam = Camera.main?.transform;

            // If no main camera is found, disable the script
            if (cam == null)
            {
                Debug.LogWarning("ParallaxController: No camera assigned and no main camera found. Disabling script.");
                this.enabled = false;
                return;
            }
        }
        camStartPos = cam.position;

        int backCount = transform.childCount;
        mat = new Material[backCount];
        backspeed = new float[backCount];
        backgrounds = new GameObject[backCount];

        for (int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            mat[i] = backgrounds[i].GetComponent<Renderer>().material;
        }
        BackSpeedCalculate(backCount);
    }

    void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++)
        {
            if ((backgrounds[i].transform.position.z - cam.position.z) > farthestBack)
            {
                farthestBack = backgrounds[i].transform.position.z - cam.position.z;
            }
        }

        for (int i = 0; i < backCount; i++)
        {
            backspeed[i] = 1 - ((backgrounds[i].transform.position.z - cam.position.z) / farthestBack);
        }
    }

    private void LateUpdate()
    {
        distance = cam.position.x - camStartPos.x;
        yDistance = cam.position.y - camStartPos.y;  // Update y-axis distance
        transform.position = new Vector3(cam.position.x, cam.position.y, 0);  // Update y-coordinate here too

        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backspeed[i] * parallaxSpeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, yDistance) * speed);  // Include y-axis distance
        }
    }
}
