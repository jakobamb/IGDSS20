using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public float scrollSensitivity = 10.0f;
    public float panSensitivity = 0.3f;
    public Camera camera; 
    private Vector3 startPos = new Vector3(0,0,0);

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
            camera.transform.Translate(delta.y * panSensitivity, 0, -delta.x * panSensitivity, Space.World);
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
