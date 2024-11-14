using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] GameObject player;
    public Vector2 speed;
    private Vector3 prePos;
    private Vector3 curPos;
    private Vector3 diff;
    // Start is called before the first frame update
    void Start()
    {
        prePos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        curPos = player.transform.position;
        diff = new Vector3(0, curPos.y - prePos.y, 0);
        transform.position = Vector3.Lerp(transform.position, transform.position + diff, 1.0f);
        transform.Translate(speed * Time.deltaTime);
        prePos = curPos;
    }
}
