using UnityEngine;
/// <summary>
/// Cube logic class.
/// </summary>
public class boxLogic : MonoBehaviour
{
    private Vector3 oldPosition;
    private float curDistance = 0;
    private float speed;
    private float distance;
    /// <summary>
    /// Changeinitial parameters of object
    /// </summary>
    /// <param name="sp">boxing speed</param>
    /// <param name="dst">boxing distance</param>
    public void Init(float sp, float dst)
    {
        speed = sp;
        distance = dst;
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
