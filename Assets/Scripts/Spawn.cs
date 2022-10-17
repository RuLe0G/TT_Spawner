using Newtonsoft.Json.Linq;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Cube spawn class.
/// </summary>

public class Spawn : MonoBehaviour
{
    [SerializeField]
    public Transform spawnPoint;
    [SerializeField]
    private GameObject box;

    public InputField inputSpeed;
    public InputField inputDistance;
    public InputField inputSpawnRate;

    private float timer;

    private float _spawnRate;
    public float spawnRate
    {
        get { return _spawnRate; }
        set { _spawnRate = value; }
    }
    private float _distance;
    public float distance
    {
        get { return _distance; }
        set { _distance = value; }
    }
    private float _speed;
    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    /// <summary>
    /// Instantiate obj
    /// </summary>
    public void SpawnObj()
    {
        GameObject tmpGO = new GameObject();
        tmpGO.SetActive(false);

        GameObject go = Instantiate(box, spawnPoint.position, Quaternion.identity, tmpGO.transform);
        go.GetComponent<boxLogic>().Init(speed, distance);

        go.transform.parent = null;
        Destroy(tmpGO);
    }
    [Serializable]
    public enum E_params
    {
        Spawn_Rate,
        Distance,
        Speed
    }
    public string preParse(string var1)
    {
        return var1.Replace(",", ".");
    }
    /// <summary>
    /// Update settings from UI. Enum specify to parameter
    /// </summary>
    /// <param name="_params">Enum params</param>
    public void UpdateParams(ChoseParams _params)
    {
        switch (_params.choseParams)
        {
            case E_params.Spawn_Rate:
                {
                    spawnRate = float.Parse(preParse(inputSpawnRate.text), CultureInfo.InvariantCulture.NumberFormat);
                    timer = 0;
                    break;
                }
            case E_params.Distance:
                {
                    distance = float.Parse(preParse(inputDistance.text), CultureInfo.InvariantCulture.NumberFormat);
                    break;
                }
            case E_params.Speed:
                {
                    speed = float.Parse(preParse(inputSpeed.text), CultureInfo.InvariantCulture.NumberFormat);
                    break;
                }
            default: break;
        }
    }

    private void Start()
    {
        spawnRate = float.Parse(inputSpawnRate.text, CultureInfo.InvariantCulture.NumberFormat);
        distance = float.Parse(inputDistance.text, CultureInfo.InvariantCulture.NumberFormat);
        speed = float.Parse(inputSpeed.text, CultureInfo.InvariantCulture.NumberFormat);
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
