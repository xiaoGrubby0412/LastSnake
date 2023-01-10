using UnityEngine;
using System.Collections;

public class KnapsackItem : UIDragDropItem
{
    public Vector3 v3;

    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        this.transform.localPosition = Vector3.zero;
    }

    void Update()
    {
        float x, y;
        x = this.transform.localPosition.x;
        y = this.transform.localPosition.y;
        if (Mathf.Sqrt(x * x + y * y) < 60)
        {
            v3 = this.transform.localPosition;
            this.transform.localPosition = v3;
        }

        if (Mathf.Sqrt(x * x + y * y) >= 15)
            this.transform.localPosition = v3;
    }
}