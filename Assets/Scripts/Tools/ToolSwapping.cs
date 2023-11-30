using UnityEngine;

public class ToolSwapping : MonoBehaviour
{
    public int currentTool = 0;
    public GameObject LaserBoxSelect;
    public GameObject MissileBoxSelect;
    public GameObject TetherBoxSelect;
    public GameObject GravitonBoxSelect;

    // Start is called before the first frame update
    void Start()
    {
        SwapTool();
        LaserBoxSelect.SetActive(false);
        MissileBoxSelect.SetActive(false);
        TetherBoxSelect.SetActive(false);
        GravitonBoxSelect.SetActive(false);
        
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

        if(currentTool == 0)
            LaserBoxSelect.SetActive(true);
        else
            LaserBoxSelect.SetActive(false);
        if (currentTool == 1)
            MissileBoxSelect.SetActive(true);
        else
            MissileBoxSelect.SetActive(false);
        if (currentTool == 2)
            TetherBoxSelect.SetActive(true);
        else
            TetherBoxSelect.SetActive(false);
        if (currentTool == 3)
            GravitonBoxSelect.SetActive(true);
        else
            GravitonBoxSelect.SetActive(false);
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
