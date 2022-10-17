using UnityEngine;
/// <summary>
/// Cube spawn class.
/// </summary>

public class Spawn : MonoBehaviour
{
    [SerializeField]
    public Transform spawnPoint;
    [SerializeField]
    private GameObject box;

    [SerializeField]
    private float _spawnRate;
    public float spawnRate
    {
        get { return _spawnRate; }
        set { _spawnRate = value; }
    }

    private float timer;

    /// <summary>
    /// Instantiate obj
    /// </summary>
    public void SpawnObj()
    {
        Instantiate(box, spawnPoint.position, Quaternion.identity);
    }

    private void Start()
    {
        //InvokeRepeating("SpawnObj", 0f, spawnRate);

    }

    private void Update()
    {
        if (timer <= 0)
        {
            SpawnObj();
            timer = spawnRate;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
