using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private int a = 3;
    private MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        print(transform.position);
        Vector3 tmp = transform.position;
        tmp.y += 10;
        transform.position = tmp;
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetKeyDown & GetKey & GetKeyUp
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 tmp = transform.position;
            tmp.y += 0.5f;
            transform.position = tmp;
        }
    }

    public void setter(int newa)
    {
        if (newa > 50)
        {
            a = 50;
            return;
        }
        a = newa;
    }

    public int getter()
    {
        print(a);
        return a;
    }
}
