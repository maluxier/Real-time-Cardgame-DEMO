using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BezierArrows : MonoBehaviour
{
    public GameObject ArrowHeadPrefab;//箭头头部
    public GameObject ArrowNodePrefab;//箭头身
    public int arrowNodeNum;//箭头身分段数量
    public float scaleFactor = 1f;//控制每个分段的尺寸

    private RectTransform origin;//箭头起点
    private List<RectTransform> arrowNodes = new List<RectTransform>();//每个分段的位置
    private List<Vector2> controlPoints = new List<Vector2>();//里面的元素表示曲线的几个节点
    private readonly List<Vector2> controlPointsFactors = new List<Vector2>() { new Vector2(-0.3f, 0.8f), new Vector2(0.1f, 1.4f) };
}
