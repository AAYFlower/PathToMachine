using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform followTarget;
    public Vector3 offset;
    public float smoothspeed;
    private Vector3 playerxpos;

    private static bool CameraExist;

    void Start()
    {
        //offset = transform.position - player.transform.position;

        DontDestroyOnLoad(transform.gameObject);
        if (!CameraExist)
        {
            CameraExist = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    void FixedUpdate()
    {
        playerxpos = new Vector3(followTarget.position.x, /*followTarget.position.y*/0, 0);

        Vector3 desiredposition = playerxpos + offset;
        Vector3 smoothedposition = Vector3.Lerp(transform.position, desiredposition, smoothspeed * Time.deltaTime);
        transform.position = smoothedposition;
        //transform.position = player.transform.position + offset;
    }
}
