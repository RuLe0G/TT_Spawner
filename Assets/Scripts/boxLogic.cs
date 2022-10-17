using UnityEngine;
/// <summary>
/// Cube logic class.
/// </summary>
public class boxLogic : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private Vector3 oldPosition;
    private float curDistance = 0;

    [SerializeField]
    private float _distance;
    public float distance
    {
        get { return _distance; }
        set { _distance = value; }
    }
    public float speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    /// <summary>
    /// Changeinitial parameters of object
    /// </summary>
    public void Init()
    {
        //
    }
    private void Start()
    {
        oldPosition = transform.position;
    }
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        UpdateDistance();

        if (curDistance >= distance)
        {
            Destroy(this.gameObject);
        }
    }
    /// <summary>
    /// Determine traveled distance
    /// </summary>
    void UpdateDistance()
    {
        var tmp = Mathf.Abs(transform.position.z - oldPosition.z);
        oldPosition = transform.position;
        curDistance += tmp;
    }
}
