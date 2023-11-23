using UnityEngine;

public class ToolSwapping : MonoBehaviour
{
    public int currentTool = 0;

    // Start is called before the first frame update
    void Start()
    {
        SwapTool();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSwappedTool = currentTool;

        //swap tools based on key press (hard coded to J and K)
        //based on the order of the tools in the hierarchy
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (currentTool >= transform.childCount - 1)
                currentTool = 0;
            else
            currentTool++;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (currentTool <= 0)
                currentTool = transform.childCount - 1;
            else
            currentTool--;
        }

        if (previousSwappedTool != currentTool)
        {
            SwapTool();
        }
    }

    void SwapTool ()
    {
        int i = 0;
        foreach (Transform tool in transform)
        {
            if (i == currentTool)
                tool.gameObject.SetActive(true);
            else
                tool.gameObject.SetActive(false);
            i++;
        }
    }
}
