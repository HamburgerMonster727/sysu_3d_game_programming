using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe : MonoBehaviour{   
    private int[,] board = new int[3,3];   //棋盘格子            
    private int turn = 1;                  //玩家回合，1为O，2为X                                
    public Texture2D Background;
    public Texture2D ButtonO;
    public Texture2D ButtonX;
    public Texture2D ButtonSpace;

    void Start(){
        init();
    }

    private void OnGUI(){
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.red;
        style.normal.background = null;
        style.fontSize = 50;

        GUI.Label(new Rect(0, 0, 500, 1000), Background);

        GUI.Label(new Rect(150, 55, 200, 50), "井字棋",style);

        if(GUI.Button(new Rect(170, 550, 100, 50), "重新开始")){
            init();
        }
        
        style.fontSize = 20;
        int state = State();
        if(state == 0){
            GUI.Label(new Rect(130, 145, 200, 50), "  现在是玩家" + turn + "的回合", style);
        }
        else if(state == 1){
            GUI.Label(new Rect(130, 145, 200, 50), "       玩家1获胜", style);
        }
        else if(state == 2){
            GUI.Label(new Rect(130, 145, 200, 50), "       玩家2获胜", style);
        }
        else if(state == 3){
            GUI.Label(new Rect(200, 145, 200, 50), "平局", style);
        }

        boardbutton();
    }

    //初始化棋盘格子的值为0,并且生成空棋盘
    void init(){
        turn = 1;
        for(int x = 0; x < 3; x++){
            for(int y = 0; y < 3; y++){
                board[x,y] = 0;
                GUI.Button(new Rect(75 + x * 100, 200 + y * 100, 100, 100), ButtonSpace);
            }
        }
    }

    //判断当前是否有玩家获胜或者平局
    int State(){
        int count = 0;
        //判断横竖是否有三连
        for(int x = 0; x < 3; x++){   
            if(board[x,0] == board[x,1] && board[x,0] == board[x,2] && board[x,0] != 0){
                return board[x, 0];
            }
                
            if(board[0,x] == board[1,x] && board[0,x] == board[2,x] && board[0,x] != 0){
                return board[0,x];
            }
            //判断是否全部格子已被下棋
            for(int y = 0; y <3; y++){
                if(board[x,y] == 0){
                    count++;
                }
            }
        }
        //判断对角线是否有三连
        if(board[0,0] != 0 && board[0,0] == board[1,1] && board[0,0] == board[2,2]){
            return board[0, 0];
        } 
        if(board[2,0] != 0 && board[2,0] == board[1,1] && board[2,0] == board[0,2]){
            return board[2,0];
        }
        //平局
        return count == 0 ? 3 : 0;
    }

    //点击改变棋盘
    void boardbutton(){
        for(int x = 0; x < 3; x++){
            for(int y = 0; y < 3; y++){
                if(board[x,y] == 0){
                    //当格子被点击时，改变棋盘所对应的格子的值，O为1，X为2
                    if(GUI.Button(new Rect(75 + x * 100, 200 + y * 100, 100, 100), ButtonSpace) && State() == 0){
                        board[x,y] = turn;
                        turn = turn == 1 ? 2 : 1;
                    }
                }
                //根据改变的格子的值，生成X或者O格子
                else if(board[x,y] == 1){
                    GUI.Button(new Rect(75 + x * 100, 200 + y * 100, 100, 100), ButtonO);
                }
                else if(board[x,y] == 2){
                    GUI.Button(new Rect(75 + x * 100, 200 + y * 100, 100, 100), ButtonX);
                }
            }
        }
    }
}
