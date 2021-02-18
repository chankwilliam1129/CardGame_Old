using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierArrows : MonoBehaviour
{

    [Tooltip("The prefab of arrow head")]
    public GameObject ArrowHeadPrefab;

    [Tooltip("The prefab of arrow node")]
    public GameObject ArrowNodePrefab;

    [Tooltip("The number of arrow node")]
    public int arrowNodeNum;

    public float scaleFacter = 1f;

    /// <summary>
    ///  pos P0
    /// </summary>
    private RectTransform origin;


    /// <summary>
    /// node transform
    /// </summary>
    private List<RectTransform> arrowNodes = new List<RectTransform>();

    private List<Vector2> controlPoints = new List<Vector2>();

    private readonly List<Vector2> controlPointFactors = new List<Vector2> { new Vector2(-0.3f, 0.8f), new Vector2(0.1f, 1.4f) };

    private void Awake()
    {
        this.origin = this.GetComponent<RectTransform>();

        for(int i = 0; i < this.arrowNodeNum; ++i)
        {
            this.arrowNodes.Add(Instantiate(this.ArrowNodePrefab, this.transform).GetComponent<RectTransform>());
        }

        this.arrowNodes.Add(Instantiate(this.ArrowHeadPrefab, this.transform).GetComponent<RectTransform>());

        this.arrowNodes.ForEach(a => a.GetComponent<RectTransform>().position = new Vector2(-1000, -1000));

        for(int i = 0; i < 4; ++i)
        {
            this.controlPoints.Add(Vector2.zero);
        }
    }


    // Update is called once per frame
    void Update()
    {
        //P0
        this.controlPoints[0] = new Vector2(this.origin.position.x, this.origin.position.y);

        this.controlPoints[3] = new Vector2(Input.mousePosition.x, Input.mousePosition.y);


        this.controlPoints[1] = this.controlPoints[0] + (this.controlPoints[3] - this.controlPoints[0]) * this.controlPointFactors[0];

        this.controlPoints[2] = this.controlPoints[0] + (this.controlPoints[3] - this.controlPoints[0]) * this.controlPointFactors[1];


        for(int i = 0; i < this.arrowNodes.Count;++i)
        {
            var t = Mathf.Log(1f * i / (this.arrowNodes.Count - 1) + 1f, 2f);


            this.arrowNodes[i].position = Mathf.Pow(1 - t, 3) * this.controlPoints[0] +
                3 * Mathf.Pow(1 - t, 2) * t * this.controlPoints[1] +
                3 * (1 - t) * Mathf.Pow(t, 2) * this.controlPoints[2] +
                Mathf.Pow(t, 3) * this.controlPoints[3];

            if(i > 0)
            {
                var euler = new Vector3(0, 0, Vector2.SignedAngle(Vector2.up, this.arrowNodes[i].position - this.arrowNodes[i - 1].position));
                this.arrowNodes[i].rotation = Quaternion.Euler(euler);
            }

            var scale = this.scaleFacter * (1f - 0.03f * (this.arrowNodes.Count - 1 - i));
            this.arrowNodes[i].localScale = new Vector3(scale, scale, 1f);

        }

        this.arrowNodes[0].transform.rotation = this.arrowNodes[1].transform.rotation;

    }
}
