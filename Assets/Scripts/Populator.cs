using UnityEngine;
public class Populator : MonoBehaviour 
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    //public GameObject singularityPrefab;
    public GameObject planetoidPrefab;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0) and zero rotation.
        //Instantiate(singularityPrefab, new Vector2(0, 0), Quaternion.identity);

        // Instantiate a bunch of planetoids at random positions.
        for(int i = 0; i < 20; i++)
        {
            Instantiate(planetoidPrefab, new Vector2(Random.Range(-10,10), Random.Range(-10,10)), Quaternion.identity);
        }
    }
}