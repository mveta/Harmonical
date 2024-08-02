using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DrumsSurface : MonoBehaviour
{
    [SerializeField]
    float speed;


    float elapsedTime = 0;
    float timeToPoint;


    private void Start()
    {
       
        float distanceToPoint = Vector3.Distance(transform.localPosition, Vector3.zero);
        timeToPoint = distanceToPoint / speed;
        
    }

    private void Update()
    {
        MoveUp();
    }
    public void MoveUp()
    {
        elapsedTime += Time.deltaTime;
        float elapsedPrcntg = elapsedTime / timeToPoint;
        elapsedPrcntg = Mathf.SmoothStep(0, 1, elapsedPrcntg);

        transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, elapsedPrcntg);
    }


}
