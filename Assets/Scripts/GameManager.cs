using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]public Disk hand;
    public Column mainColumn;
    public Disk one, two, three, four, five, six;
    [HideInInspector] int mov;
    private Column c1, c3;
    private bool victory;

    void Start()
    {
        c1 = GameObject.Find("Cylinder001").GetComponent<Column>();
        c3 = GameObject.Find("Cylinder003").GetComponent<Column>();
        victory = false;

        mov = 0;
        mainColumn.stack.Push(one);
        mainColumn.stack.Push(two);
        mainColumn.stack.Push(three);
        mainColumn.stack.Push(four);
        mainColumn.stack.Push(five);
        mainColumn.stack.Push(six);

        //testReset();
    }

    void Update()
    {
        if(victory)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if(c1.stack.Count == 6)
                {
                    victory = false;
                    mov = 0;
                    GetComponent<Message>().text.enabled = false;

                    Disk[] d = c1.stack.ToArray();
                    c1.stack.Clear();

                    mainColumn.stack.Push(d[5]);
                    mainColumn.stack.Push(d[4]);
                    mainColumn.stack.Push(d[3]);
                    mainColumn.stack.Push(d[2]);
                    mainColumn.stack.Push(d[1]);
                    mainColumn.stack.Push(d[0]);

                    d[5].transform.localPosition = new Vector3(9.46248722f, 13.8772297f, 104.969978f);
                    d[4].transform.localPosition = new Vector3(9.4024868f, 17.9972286f, 105.209976f);
                    d[3].transform.localPosition = new Vector3(9.46248722f, 22.0072289f, 105.259979f);
                    d[2].transform.localPosition = new Vector3(9.48248672f, 26.5772285f, 105.329979f);
                    d[1].transform.localPosition = new Vector3(9.39248657f, 30.6872292f, 105.239975f);
                    d[0].transform.localPosition = new Vector3(9.41797638f, 34.3172302f, 105.409973f);
                }
                else if(c3.stack.Count == 6)
                {
                    victory = false;
                    mov = 0;
                    GetComponent<Message>().text.enabled = false;

                    Disk[] d = c3.stack.ToArray();
                    c3.stack.Clear();
                    
                    mainColumn.stack.Push(d[5]);
                    mainColumn.stack.Push(d[4]);
                    mainColumn.stack.Push(d[3]);
                    mainColumn.stack.Push(d[2]);
                    mainColumn.stack.Push(d[1]);
                    mainColumn.stack.Push(d[0]);

                    d[5].transform.localPosition = new Vector3(9.46248722f, 13.8772297f, 104.969978f);
                    d[4].transform.localPosition = new Vector3(9.4024868f, 17.9972286f, 105.209976f);
                    d[3].transform.localPosition = new Vector3(9.46248722f, 22.0072289f, 105.259979f);
                    d[2].transform.localPosition = new Vector3(9.48248672f, 26.5772285f, 105.329979f);
                    d[1].transform.localPosition = new Vector3(9.39248657f, 30.6872292f, 105.239975f);
                    d[0].transform.localPosition = new Vector3(9.41797638f, 34.3172302f, 105.409973f);
                }
            }
        }
    }

    private void testReset()
    {   
        Disk[] d = mainColumn.stack.ToArray();
        
        d[5].transform.localPosition = new Vector3(-30.4500008f ,13.8772297f,105.409973f);
        d[4].transform.localPosition = new Vector3(-30.4500008f ,17.9972286f,105.409973f);
        d[3].transform.localPosition = new Vector3(-30.4500008f ,22.0072289f,105.409973f);
        d[2].transform.localPosition = new Vector3(-30.4500008f ,26.5772285f,105.409973f);
        d[1].transform.localPosition = new Vector3(-30.4500008f ,30.6872292f,105.409973f);
        d[0].transform.localPosition = new Vector3(-30.4500008f ,34.3172302f,105.409973f);

        mainColumn.stack.Clear();

        c3.stack.Push(d[5]);
        c3.stack.Push(d[4]);
        c3.stack.Push(d[3]);
        c3.stack.Push(d[2]);
        c3.stack.Push(d[1]);
        c3.stack.Push(d[0]);

        VerifyVictory();
    }

    public void VerifyVictory()
    {
        if(c1.stack.Count == 6 || c3.stack.Count == 6)
        {
            GetComponent<Message>().text.enabled = true;
            victory = true;
        }
    }

    public void incMov()=> mov++;

    public int getMov()
    {
        return mov;
    }
}
