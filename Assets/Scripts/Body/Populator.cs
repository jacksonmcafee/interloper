using UnityEngine;
public class Populator : MonoBehaviour 
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    //public GameObject singularityPrefab;
    //rock
    public GameObject RSML;
    public GameObject RMED;
    public GameObject RLRG;
    //gas
    public GameObject GSML;
    public GameObject GMED;
    public GameObject GLRG;

    // This script will simply instantiate the Prefab when the game starts.
    void Start()
    {
        // Instantiate at position (0, 0) and zero rotation.
        //Instantiate(singularityPrefab, new Vector2(0, 0), Quaternion.identity);

        // Instantiate a bunch of planetoids at random positions.
        /*for(int i = 0; i < 30; i++)
        {
            GameObject planet = Instantiate(TYPE, new Vector2(Random.Range(-100,100), Random.Range(-100,100)), Quaternion.identity);
            
            planet.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-2.5f,2.5f), Random.Range(-2.5f,2.5f)),ForceMode2D.Impulse);
        }*/
    }
}