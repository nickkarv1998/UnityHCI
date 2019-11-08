using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class pointer : MonoBehaviour
{

    public float m_DefaultLenght = 5.0f;
    public GameObject m_Dot;
    public VRInputModule m_inputModule;

    public LineRenderer m_lineRenderer = null;

    private void Awake()
    {
        m_lineRenderer = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateLine();
    }

    private void UpdateLine()
    {
        // Use default or distance
        PointerEventData data = m_inputModule.GetData();
        float targetlenght = data.pointerCurrentRaycast.distance == 0 ? m_DefaultLenght : data.pointerCurrentRaycast.distance;



        //Raycast
        RaycastHit hit = CreateRayCast(targetlenght);

        //Default
        Vector3 endPosition = transform.position + (transform.forward * targetlenght);

        //based on hit
        if (hit.collider != null)
            endPosition = hit.point;

        //set position of the dot
        m_Dot.transform.position = endPosition;

        //set linerenderer
        m_lineRenderer.SetPosition(0, transform.position);
        m_lineRenderer.SetPosition(1, endPosition);
    }

    private RaycastHit CreateRayCast(float length)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out hit, m_DefaultLenght);

        return hit;
    }
}
