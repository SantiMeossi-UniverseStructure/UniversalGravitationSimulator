using UnityEngine;

public class VectorScript : MonoBehaviour
{
    private float cylindetScaleZ = 1f;
    public float modelScale = 0.25f;
    private float distortion;

    public void scaleVector(float size)
    {
        size = size / 2;
        transform.localScale = new Vector3(size, size, size);
        distortion = 1 / modelScale;
    }

    public void updateVector(Vector3 rotation, float module, Vector3 position)
    {
        if (rotation != Vector3.zero) {
            gameObject.SetActive(true);
            gameObject.transform.position = position;
            Transform model = transform.Find("Vector3D");
            Transform cylinder = model.transform.Find("Cylinder");
            Transform cone = model.transform.Find("Cone");

            model.rotation = Quaternion.LookRotation(rotation);
            cylinder.transform.localScale += new Vector3(0, 0, module - cylindetScaleZ);
            cylindetScaleZ += module - cylindetScaleZ;
            cone.transform.localPosition = new Vector3(0, 0, cylindetScaleZ * distortion);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
