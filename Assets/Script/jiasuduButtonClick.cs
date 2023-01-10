using UnityEngine;
using System.Collections;
using System.Threading;

public class jiasuduButtonClick : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (SnakeControl.SnakeCout < 21)
                return;
            SnakeControl.SnakeSpeed = 10;
        }

        if (Input.GetMouseButtonUp(1))
        {
            SnakeControl.SnakeSpeed = 5;
        }
    }

    public static int v = 1;

    public void VVV()
    {
        //先遍历得到这些身体坐标看看是不是x坐标相等，或者是y坐标相等

        if (SnakeControl.SnakeCout < 21)
            return;
        //得到蛇的长度
        v++;
        if (v % 2 == 0)
            SnakeControl.SnakeSpeed = 10;
        else
            SnakeControl.SnakeSpeed = 5;
    }
}