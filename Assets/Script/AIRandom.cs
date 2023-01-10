using UnityEngine;
using System.Collections;

public class AIRandom
{
    //public static float AIx=1,AIy=0;
    // Use this for initialization

    //给蛇产生随机位置 在需要的时候调用
    //0和1和-1表示
    public float AIXrandom(float x, float y)
    {
        float ax = Random.Range(x, y);
        return ax;
    }

    public float AIYrandom(float x, float y)
    {
        float ay = Random.Range(x, y);
        return ay;
    }
}