using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public float speed = 10.0f;
    public Camera camera; 

    void Zooming(){

        if(Input.GetAxis("Mouse ScrollWheel") < 0){
            if(camera.transform.position[0]<100){
                camera.transform.Translate(0,0,Input.GetAxis("Mouse ScrollWheel") * speed);
            }
        }
        else if(Input.GetAxis("Mouse ScrollWheel") > 0){
            if(camera.transform.position[0]>20){
                camera.transform.Translate(0,0,Input.GetAxis("Mouse ScrollWheel") * speed);
            }
        }
    }

    void Panning(){
        if (Input.GetMouseButton(1)){

            camera.transform.Rotate(-Input.GetAxis("Mouse X"),0,0,Space.World);
            camera.transform.Rotate(0,0,-Input.GetAxis("Mouse Y"),Space.World);
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
