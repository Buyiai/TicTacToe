using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe : MonoBehaviour
{
    private int turn = 1; //记录是谁的回合，turn为1是圈的回合，-1是叉的回合
    private int result = 0; //游戏进行中为0，圈赢为1，叉赢为2，平局为3
    private int[,] state = new int[3, 3]; 
    //0代表未下棋，1代表格子里是圈，2代表格子里是叉

    public Texture2D img;
    public Texture2D img1;
    public Texture2D img2;

    void Start()
    {
        Reset(); //初始化
    }

    void OnGUI()
    {
        GUIStyle fontStyle = new GUIStyle();
        fontStyle.normal.background = img; //设置背景图片

        //Welcome style
        GUIStyle fontStyle1 = new GUIStyle();
        fontStyle1.normal.textColor = new Color(1, 1, 0); //设置字体颜色
        fontStyle1.fontSize = 40; //设置字体大小

        //result style
        GUIStyle fontStyle2 = new GUIStyle();
        fontStyle2.normal.textColor = new Color(1, 0, 1);
        fontStyle2.fontSize = 40;

        GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "", fontStyle);//background
        GUI.Label(new Rect(100, 100, 100, 100), "Welcome to Tic Tac Toe!", fontStyle1);
        GUI.Label(new Rect(50, 150, 200, 100), img1);
        GUI.Label(new Rect(400, 150, 200, 100), img2);

        if (GUI.Button(new Rect(220, 335, 100, 50), "RESET"))
        {
            Reset();
        }

        result = check(); //检查哪一方胜利
        if (result == 1)
        {
            GUI.Label(new Rect(400, 250, 100, 50), "Mario wins!", fontStyle2);
        }
        else if (result == 2)
        {
            GUI.Label(new Rect(400, 250, 100, 50), "Mushroom wins!", fontStyle2);
        }
        else if (result == 3)
        {
            GUI.Label(new Rect(400, 300, 100, 50), "Tied!", fontStyle2);
        }
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                if (state[i, j] == 1) //圈
                {
                    GUI.Button(new Rect(200 + i * 50, 170 + j * 50, 50, 50), img1);
                }
                else if (state[i, j] == 2) //叉
                {
                    GUI.Button(new Rect(200 + i * 50, 170 + j * 50, 50, 50), img2);
                }
                if(GUI.Button(new Rect(200 + i * 50, 170 + j * 50, 50, 50), ""))
                {
                    if(result == 0) //游戏进行中
                    {
                        if (turn == 1) //圈的回合
                        {
                            state[i, j] = 1;
                        }
                        else //叉的回合
                        {
                            state[i, j] = 2;
                        }
                        turn = -turn;
                    }
                }
            }
        }
    }

    void Reset()
    {
        turn = 1;
        result = 0;
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                state[i, j] = 0;
            }
        }
        Debug.Log("Reset");
    }
    
    int check()
    {
        //横向连线
        for(int i = 0; i < 3; i++)
        {
            if (state[i, 0] != 0 && state[i, 0] == state[i, 1] && state[i, 1] == state[i, 2])
            {
                return state[i, 0];
            }
        }

        //纵向连线
        for(int j = 0; j < 3; j++)
        {
            if (state[0, j] != 0 && state[0, j] == state[1, j] && state[1, j] == state[2, j])
            {
                return state[0, j];
            }
        }

        //斜向连线
        if(state[1, 1] != 0 &&
            state[0, 0] == state[1, 1] && state[1, 1] == state[2,2] ||
            state[0, 2] == state[1, 1] && state[1, 1] == state[2, 0])
        {
            return state[1, 1];
        }

        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                if (state[i, j] == 0)
                {
                    return 0;
                }
            }
        }

        return 3;
    }

    void Update()
    {
        
    }
}
