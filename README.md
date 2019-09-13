
# 一、简答题
## 1. 解释 游戏对象（GameObjects）和 资源（Assets）的区别和联系。
 + **游戏对象（GameObjects）**：指的是游戏中代表人物、道具和场景的基本对象，它们直接出现在游戏场景中，是游戏场景的基本组成部分，是资源整合的具体表现。例如玩家、敌人、游戏场景、NPC等，游戏对象是一种容器。通过向其中加入不同的组件，可以获得具有不同外观和行为的游戏对象。
 + **资源（Assests）**：指的是能应用在游戏中的素材，通常包含脚本（Scripts）、预设（Prefabs）、场景（Scences）、声音等。资源可以作为模板，可实例化成游戏中具体的对象，能够被多个游戏对象使用。
## 2. 下载几个游戏案例，分别总结资源、对象组织的结构（指资源的目录组织结构与游戏对象树的层次结构）
+ **资源的目录组织结构**：主要包括游戏对象、预设、场景、脚本、声音、图像、材质等。
+ **游戏对象树的层次结构**：包含了每一个当前场景的游戏对象，类似于多个父子继承关系。当在场景中增加或删除对象，层次结构视图中相应的对象则会出现或消失。
## 3. 编写一个代码，使用 debug 语句来验证MonoBehaviour 基本行为或事件触发的条件
+ 基本行为包括 Awake() Start() Update() FixedUpdate() LateUpdate()
+ 常用事件包括 OnGUI() OnDisable() OnEnable()
```c
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Awake!");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start!");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update!");
    }
    void FixedUpdate()
    {
        Debug.Log("FixedUpadate!");   
    }
    void LateUpdate()
    {
        Debug.Log("LateUpdate!");    
    }

    void OnGUI()
    {
        Debug.Log("OnGUI!");
    }
    void OnDisable()
    {
        Debug.Log("OnDisable!");
    }
    void OnEnable()
    {
        Debug.Log("OnEnable!");
    }
}
```
## 4. 查找脚本手册，了解 GameObject，Transform，Component 对象
### ① 分别翻译官方对三个对象的描述（Description）
+ GameObject 是 Unity 中代表人物、道具和场景的的基本对象。它们本身并没有完成多少工作，但是它们充当组件的容器，实现具体的功能。
+ Transform 是对象的位置、旋转和比例。场景中的每个对象都有一个变换，它用于存储和操作对象的位置、旋转和缩放。每个变换都可以有一个父类，它允许分层次地应用位置、旋转和缩放。
+ Component 是游戏中对象和行为的细节，是用来绑定到游戏对象上的一组相关属性。它是每个游戏对象的功能部分，本质上是一个类的实例。
### ② 描述下图中 table 对象（实体）的属性、table 的 Transform 的属性、table 的部件。
+ 本题目要求是把可视化图形编程界面与 Unity API 对应起来，当你在 Inspector 面板上每一个内容，应该知道对应 API。
+ 例如：table 的对象是 GameObject，第一个选择框是 activeSelf 属性。
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190911214737692.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FpYW9femhhbmc=,size_16,color_FFFFFF,t_70)
table 的对象是 GameObject，第一个选择框是 activeSelf 属性，第二个文本框是对象名称，第三个选择框是 static 属性。第二行是 Tag 属性和 Layer 属性，第三行是 Prefab 属性。
Transform 属性包括 Position，Rotation，Scale 属性。Component 对象有 Transform，Cube（Mesh Filter），Box Collider，Mesh Renderer。
### ③ 用 UML 图描述三者的关系
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190911231300475.jpg?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FpYW9femhhbmc=,size_16,color_FFFFFF,t_70)
## 5. 整理相关学习资料，编写简单代码验证一下技术的实现：
+ **查找对象**
	通过对象名称查找：public static GameObject Find(string name)
	通过标签查找单个对象：public static GameObject FindWithTag(string tag)
	通过标签查找多个对象：public  static GameObject[] FindGameObjectsWithTags(string tag)
+ **添加子对象**
public static GameObject CreatePrimitive(Primitive Typetype)
+ **遍历对象树**
foreach(Transform child in transform) { Debug.Log(child.gameObject); };
+ **清除所有子对象**
foreach(Transform child in transform) { Destroy(child.gameObject); }
```c
        //查找对象
        var cube = GameObject.Find("chair1"); //通过对象名称查找
        if (cube != null)
        {
            Debug.Log("Find chair1");
        }
        var sphere = GameObject.FindWithTag("Sphere"); //通过标签查找
        if (sphere != null)
        {
            Debug.Log("Find Sphere");
        }

        //添加子对象
        GameObject cube_temp = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube_temp.transform.parent = cube.transform;
        cube_temp.transform.position = new Vector3(2, 2, 1);

        //遍历对象树
        foreach(Transform child in transform)
        {
            Debug.Log(child.gameObject);
        }

        //清除所有子对象
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
```
## 6. 资源预设（Prefabs）与对象克隆（clone）
+ 预设（Prefabs）有什么好处？
资源预设能够预制好包含完整组件和属性的游戏对象，相当于一个类模板。预设使对象和资源能够重复利用，能够提高效率，方便迅速创建大量相同属性的对象，降低出错的概率。
+ 预设与对象克隆（clone or copy or Instantiate of Unity Object）关系？
修改预设，所有通过预设实例化的游戏对象会发生相应的变化；而对象克隆只是对对象的复制，新对象与克隆本体之间没有关联，不会相互影响。
+ 制作 table 预制，写一段代码将 table 预制资源实例化成游戏对象
```c
    void Start()
    {
        GameObject objPrefab = (GameObject)Resources.Load("table");
        Instantiate(objPrefab);
        objPrefab.transform.position = new Vector3(3, 3, 3);
    }
```
# 二、编程实践，小游戏
+ 游戏内容：井字棋 或 贷款计算器 或 简单计算器 等等
+ 技术限制：仅允许使用 IMGUI 构建 UI
+ 作业目的：
	+ 了解 OnGUI() 事件，提升 debug 能力
	+ 提升阅读 API 文档能力
1. [项目地址](https://github.com/Buyiai/TicTacToe)
2. 完成效果图
![在这里插入图片描述](https://img-blog.csdnimg.cn/20190913013832327.png?x-oss-process=image/watermark,type_ZmFuZ3poZW5naGVpdGk,shadow_10,text_aHR0cHM6Ly9ibG9nLmNzZG4ubmV0L3FpYW9femhhbmc=,size_16,color_FFFFFF,t_70)
3. 实现过程
+ 成员变量：
```c
    private int turn = 1; //记录是谁的回合，turn为1是圈的回合，-1是叉的回合
    private int result = 0; //游戏进行中为0，圈赢为1，叉赢为2，平局为3
    private int[,] state = new int[3, 3]; 
    //0代表未下棋，1代表格子里是圈，2代表格子里是叉

    public Texture2D img;
    public Texture2D img1;
    public Texture2D img2;
```
声明三个私有变量，turn 记录是谁的回合，result 记录游戏结果，state 记录井字棋状态。img 为背景图片，img1 代表圈，img2 代表叉。
+ 初始化：
```c
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
```
+ 显示井字棋和下棋的逻辑实现：
```c
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
```
通过 OnGUI 的方法生成井字棋。圈下棋的位置 state[i][j] 值为1，叉下棋的位置 state[i][j] 值为2。游戏进行中，state[i][j] 值为0且按钮被点击时，就将对应的值赋为1或2。
+ 判断游戏结果：
```c
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
```
检查是否游戏结束，若返回0则代表游戏仍在进行中，返回1则表示圈赢，返回2则表示叉赢，返回3则表示平局。
4. 完整代码
```c
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
```
5. [演示视频](https://www.bilibili.com/video/av67524414/)
# 三、思考题【选做】
1. 微软 XNA 引擎的 Game 对象屏蔽了游戏循环的细节，并使用一组虚方法让继承者们完成它们，我们称这种设计为“模板方法模式”。
+ 为什么是“模板方法”模式而不是“策略模式”呢?
在模板方法模式（Template Pattern）中，一个抽象类公开定义了执行它的方法的方式/模板。它的子类可以按需要重写方法实现，但调用将以抽象类中定义的方式进行。在策略模式（Strategy Pattern）中，一个类的行为或其算法可以在运行时更改。
微软 XNA 引擎的 Game 对象使用虚方法让子类完成游戏循环的细节，不必更改类的算法，大大提高了代码的可复用性，更加符合模板方法的定义，故称这种设计为模板方法模式。
2. 将游戏对象组成树型结构，每个节点都是游戏对象（或数）。
+ 尝试解释组合模式（Composite Pattern / 一种设计模式）。
组合模式（Composite Pattern），又叫部分整体模式，是用于把一组相似的对象当作一个单一的对象。组合模式依据树形结构来组合对象，用来表示部分以及整体层次。这种类型的设计模式属于结构型模式，它创建了对象组的树形结构。这种模式创建了一个包含自己对象组的类。该类提供了修改相同对象组的方式。
+ 使用 BroadcastMessage() 方法，向子对象发送消息。你能写出 Broadcast Message() 的伪代码吗？
父对象：
```c
void Start()
{
    this.BroadcastMessage("test");
}
```
子对象：
```c
void test()
{
    Debug.Log("Child!");
}
```
3. 一个游戏对象用许多部件描述不同方面的特征。我们设计坦克（Tank）游戏对象不是继承于 GameObject 对象，而是 GameObject 添加一组行为部件（Component）。
+ 这是什么设计模式？
装饰器模式（Decorator Pattern）。
+ 为什么不用继承设计特殊的游戏对象？
如果使用继承方法设计特殊的游戏对象，由于继承为类引入静态特征，并且随着扩展功能的增多，子类会膨胀，代码会变得十分复杂。而装饰器模式（Decorator Pattern）允许向一个现有的对象添加新的功能，同时又不改变其结构。这种模式创建了一个装饰类，用来包装原有的类，并在保持类方法签名完整性的前提下，提供了额外的功能。
