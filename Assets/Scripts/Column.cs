using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    [HideInInspector]public Stack<Disk> stack;
    public int columnNumber;
    private GameManager gm;

    void Start()
    {
        stack = new Stack<Disk>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        if(gm.hand != null){
            if(columnNumber == gm.hand.diskColumn.columnNumber)
            { //se eu tentar colocar na posicao que ele ja estava, eu nao conto movimento e apenas o devolvo para sua posicao
                GoToPosition();
                gm.hand.rb.useGravity = true;
                gm.hand = null;
            }
            else if(stack.Count != 0){
                if(stack.Peek().number < gm.hand.number)
                {
                    GoToPosition();

                    gm.hand.rb.useGravity = true;
                    
                    stack.Push(gm.hand.diskColumn.stack.Pop());
                    gm.hand.diskColumn = this;

                    gm.hand = null;
                    gm.incMov();
                    Debug.Log($"Voce realizou: {gm.getMov()} movimentos");
                    gm.VerifyVictory();
                }
                else
                {
                    Debug.Log("Voce nao pode colocar um disco maior sobre um menor!");
                }
            }
            else{
                GoToPosition();

                gm.hand.rb.useGravity = true; //habilito novamente a gravidade para que ele possa se encaixar

                stack.Push(gm.hand.diskColumn.stack.Pop()); ////retiro ele da pilha da coluna anterior, e insiro na pilha da nova coluna
                gm.hand.diskColumn = this; //troco a coluna antiga pela nova
                    
                gm.hand = null;
                gm.incMov();
                Debug.Log($"Voce realizou: {gm.getMov()} movimentos");
                gm.VerifyVictory();
            }
        }
        else if(stack.TryPeek(out Disk a))
        { //quando clico em uma coluna que tem disco com a mão vazia, pego ele
            a.diskColumn = this; //associo a coluna pertencente ao disco a ele
            a.GetDisk(); //pego ele
        }
    }

    void GoToPosition()
    {
        if(columnNumber == 1) //vou colocar na posicao 1
            gm.hand.transform.localPosition = new Vector3(49.5999985f,37.3199997f,105.410004f); 

        else if(columnNumber == 2)
            gm.hand.transform.localPosition = new Vector3(9.41797638f ,37.3199997f,105.409973f);

        else if(columnNumber == 3)
            gm.hand.transform.localPosition = new Vector3(-30.4500008f ,37.3199997f,105.409973f);
    }

}
