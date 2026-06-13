using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private float G = UniversalVariables.G;
    [System.Serializable]
    public class planet
    {
        public string name;
        public GameObject physicalObject;
        public Vector3 position;
        public SphereCollider collider;
        public Rigidbody rigidBody;
        public Vector3 velocity;
    }

    public planet Earth = new planet();
    public planet Moon = new planet();
    public GameObject Camera;
    public VectorScript vectorScript1;
    public VectorScript vectorScript2;
    public TrailRenderer moonTrailRender;

    public List<planet> PlanetList = new List<planet>();

    private void Start()
    {
        PlanetList.Add(Earth);
        PlanetList.Add(Moon);
        Earth.rigidBody.mass = UniversalVariables.mass1;
        Moon.rigidBody.mass = UniversalVariables.mass2;
        float size1 = UniversalVariables.mass1 * 10;
        float size2 = UniversalVariables.mass2 * 10;
        Earth.physicalObject.transform.localScale += new Vector3(size1, size1, size1);
        Moon.physicalObject.transform.localScale += new Vector3(size2, size2, size2);
        Moon.physicalObject.transform.position = new Vector3(UniversalVariables.separation, 0, 0);
        Moon.rigidBody.AddForce(new Vector3(0, 0, UniversalVariables.intialSpeed * Moon.rigidBody.mass), ForceMode.Impulse);
        Camera.transform.position = new Vector3(Moon.physicalObject.transform.position.x / 2, 0, -Mathf.Abs(Moon.physicalObject.transform.position.x / 2));
        if (UniversalVariables.mass1 >= UniversalVariables.mass2)
        {
            Camera.transform.position = new Vector3(Camera.transform.position.x, 0, Camera.transform.position.z - Mathf.Abs(size1 / 2));
        }
        else
        {
            Camera.transform.position = new Vector3(Camera.transform.position.x, 0, Camera.transform.position.z - Mathf.Abs(size2 / 2));
        }
        vectorScript1.scaleVector(size1);
        vectorScript2.scaleVector(size2);
        if(UniversalVariables.collider == true)
        {
            Earth.collider.isTrigger = false;
            Moon.collider.isTrigger = false;
        }
        else
        {
            Earth.collider.isTrigger = true;
            Moon.collider.isTrigger = true;
        }
        moonTrailRender.enabled = true;
    }

    private void FixedUpdate()
    {
        Earth.position = Earth.physicalObject.transform.position;
        Moon.position = Moon.physicalObject.transform.position;
        Earth.velocity = Earth.rigidBody.linearVelocity;
        Moon.velocity = Moon.rigidBody.linearVelocity;

        foreach (planet p in PlanetList){
            List<Vector3> forces = new List<Vector3>();

            foreach (planet p2 in PlanetList)
            {
                if (p2.name != p.name)
                {
                    Vector3 Distance = p2.position - p.position;
                    float sqrDistance = Distance.sqrMagnitude;
                    Vector3 direction = Distance.normalized;
                    float masses = G * p.rigidBody.mass * p2.rigidBody.mass;
                    float force = masses / sqrDistance;
                    forces.Add(direction * force);
                }
            }
            Vector3 finalForce = new Vector3(0, 0, 0);
            foreach (Vector3 f in forces) 
            {
                finalForce += f;
            }
            p.rigidBody.AddForce(finalForce);
        };
        vectorScript1.updateVector(Earth.rigidBody.linearVelocity.normalized, Earth.rigidBody.linearVelocity.magnitude, Earth.physicalObject.transform.position);
        vectorScript2.updateVector(Moon.rigidBody.linearVelocity.normalized, Moon.rigidBody.linearVelocity.magnitude, Moon.physicalObject.transform.position);
    }
}
