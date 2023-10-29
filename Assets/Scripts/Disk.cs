using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour
{
    [HideInInspector]public Rigidbody rb;
    public int number;
    private GameManager gm;
    [HideInInspector]public Column diskColumn;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void GetDisk()
    {
        gm.hand = this;
        transform.localPosition = new Vector3(0.150000006f, 24.2900009f, 145.710007f);
        rb.useGravity = false;
    }
}
