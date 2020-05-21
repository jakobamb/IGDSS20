using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public float scrollSensitivity = 10.0f;
    public float panSensitivity = 0.3f;
    public Camera camera; 
    private Vector3 startPos = new Vector3(0,0,0);

    public GameManager gameManager;

    void Zooming(){
        if(Input.GetAxis("Mouse ScrollWheel") < 0f){
            if(camera.transform.position[1]<120){
                camera.transform.Translate(0,0,Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity);
            }
        }
        else if(Input.GetAxis("Mouse ScrollWheel") > 0f){
            if(camera.transform.position[1]>20){
                camera.transform.Translate(0,0,Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity);
            }
        }
    }

    void Panning(){
        if (Input.GetMouseButtonDown(1)){
            startPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(1))
        {
            Vector3 delta = Input.mousePosition - startPos;
            Vector3 translateVector = new Vector3(delta.y * panSensitivity, 0, -delta.x * panSensitivity);
            Vector3 newPosition = camera.transform.position + translateVector;
            Vector2 mapBounds = gameManager.mapGenerator.getMapBounds();
            
            if(newPosition.x >= mapBounds[0] && newPosition.z >= mapBounds[0] && 
                newPosition.x <= mapBounds[1] && newPosition.z <= mapBounds[1])
            {
                // check for limits
                camera.transform.Translate(delta.y * panSensitivity, 0, -delta.x * panSensitivity, Space.World);
            }

            startPos = Input.mousePosition;
        }
    }

    void getInfo(){
        if (Input.GetMouseButtonDown(0)){

            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        
            if (Physics.Raycast(ray, out hit)) {
                Transform objectHit = hit.transform;
                
                Debug.Log(objectHit);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Zooming();
        Panning();
        getInfo();

    }
}
