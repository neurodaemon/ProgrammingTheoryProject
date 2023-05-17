using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UserControl : MonoBehaviour
{
    public Camera gameCamera;
    public GameObject marker;
    private Unit m_Selected = null;

    [SerializeField] private EventSystem eventSystem;

    public void HandleSelection()
    {
        PointerEventData eventData = new PointerEventData(eventSystem) { position = Input.mousePosition };
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        if (results.Count > 0)
        {
            m_Selected = results[0].gameObject.GetComponent<Unit>();
        }
    }

    public void HandleAction()
    {
        PointerEventData eventData = new PointerEventData(eventSystem) { position = Input.mousePosition };
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        if (results.Count > 0)
        {
            Unit unit = results[0].gameObject.GetComponent<Unit>();
            m_Selected.MainActionOnTarget(unit);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        marker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleSelection();
        }
        else if(m_Selected != null && Input.GetMouseButtonDown(1))
        {
            HandleAction();
        }

        MarkerHandling();
    }

    private void MarkerHandling()
    {
        if (m_Selected == null && marker.activeInHierarchy)
        {
            marker.SetActive(false);
            marker.transform.SetParent(null);
        }
        else if (m_Selected != null && marker.transform.parent != m_Selected.transform)
        {
            marker.SetActive(true);
            marker.transform.SetParent(m_Selected.transform, false);
            marker.transform.localPosition = Vector3.zero;
        }
    }
}
