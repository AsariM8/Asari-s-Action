using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Vector3 initPos;
    private Vector3 prePos, curPos;
    private Vector3 diff;
    // Start is called before the first frame update
    void Start()
    {
        prePos = player.transform.position;
        transform.position = initPos;

    }

    // Update is called once per frame
    void Update()
    {
        curPos = player.transform.position;
        diff = curPos - prePos;
        transform.position = Vector3.Lerp(transform.position, transform.position + diff, 1.0f);
        prePos = curPos;
    }

}
