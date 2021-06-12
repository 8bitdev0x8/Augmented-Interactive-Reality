using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaceContent : MonoBehaviour {

    [SerializeField] ARRaycastManager raycastManager;
    [SerializeField] GraphicRaycaster raycasterCanvas;
    [SerializeField] PhysicsRaycaster raycasterUI;
    [SerializeField] PhysicsRaycaster raycasterAR;
    public GameObject[] contentPrefab;
    public GameObject placementIndicator;
    public int selection;

    private ARRaycastManager ARRaycastManager;
    private Pose placementPose;
    private bool placementPoseIsValid = false;

     void Start()
    {
       ARRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    private void Update() {

        UpdatePlacementPose();
        UpdatePlacementIndicator();

        if (placementPoseIsValid && Input.GetMouseButtonDown(0) && !IsClickOverUI()) {
        
            List<ARRaycastHit> hitPoints = new List<ARRaycastHit>();
            raycastManager.Raycast(Input.mousePosition, hitPoints, TrackableType.Planes);

            if (hitPoints.Count > 0) {
                Pose pose = hitPoints[0].pose;
                //Instantiate(contentPrefab, pose.position, pose.rotation, transform); //add new cube every time
                Instantiate(contentPrefab[selection], placementPose.position, placementPose.rotation, transform);

                //transform.rotation = pose.rotation;
                //transform.position = pose.position;
            }
        }
    }

    public void sofa()
    {
        selection = 0;
        Toast.Instance.Show ("Sofa Selected");
        //Debug.Log("Sofa Selected");
    }

    public void cube()
    {
        selection = 1;
        Toast.Instance.Show ("Cube Selected");

        //Debug.Log("Cube Selected");

    }
    public void table()
    {
        selection = 2;
        Toast.Instance.Show ("Table Selected");
        //Debug.Log("Sofa Selected");
    }
    public void tableset()
    {
        selection = 3;
        Toast.Instance.Show ("TableSet Selected");
        //Debug.Log("Sofa Selected");
    }


    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        ARRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;

            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
        }
    }

    bool IsClickOverUI() {
        //dont place content if pointer is over ui element
        PointerEventData data = new PointerEventData(EventSystem.current) {
            position = Input.mousePosition
        };
        List<RaycastResult> results = new List<RaycastResult>();
        raycasterCanvas.Raycast(data, results);
        raycasterUI.Raycast(data, results);
        raycasterAR.Raycast(data, results);

        results.RemoveAll(r => r.gameObject.tag == "plane");
        results.RemoveAll(r => r.gameObject.tag == "indicator");


        return results.Count > 0;
    }
}

