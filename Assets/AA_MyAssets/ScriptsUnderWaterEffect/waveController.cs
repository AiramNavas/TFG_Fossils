using UnityEngine;
using System.Collections;

public class waveController : MonoBehaviour
{
    public float speed = 0.5f;
    private bool ascending = false;
    public float pleamar;
    public float bajamar;

    void Update()
    {
        if (ascending)
        {
            if (transform.position.y < pleamar)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                ascending = false;
            }


        }
        else if (!ascending)
        {
            if (transform.position.y > bajamar)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                ascending = true;
            }

        }
    }
}