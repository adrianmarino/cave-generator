using UnityEngine;

namespace Generator.Generator
{
    public static class CameraSettings
    {
        public static void TwoDimnesion(Camera camera)
        {
            camera.transform.position = new Vector3(-0.6f, 58.88f, 19.4f);
            camera.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
            camera.orthographic = true;
        }  
        
        public static void ThreeDimnesion(Camera camera)
        {
            camera.transform.position = new Vector3(12.38594f, 45.88039f, -2.324471f);
            camera.transform.rotation = Quaternion.Euler(68.514f, -16.501f, 0f);
            camera.orthographic = false;
        }         
        
    }
}