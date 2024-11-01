using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//相机云台设置
public class Camera_Gimbal : MonoBehaviour
{

    public static Camera_Gimbal cameragimbal;
    private Input_rotate inputRotate;

    private void Awake()
    {
        if(cameragimbal == null)
        {
            cameragimbal = this;
        }
    }
    private void Start()
    {
        inputRotate=GetComponent<Input_rotate>();
    }




    public void set_gimbal(Vector3 target)
    {
        StartCoroutine(gimbal_(target));
    }

    IEnumerator gimbal_(Vector3 target)
    {
        /* bool istar = true;
          while(istar)
          {
              if (Vector3.SqrMagnitude(transform.position - target) > 0.1f)
              {
                  transform.localPosition = Vector3.MoveTowards(transform.position, target + new Vector3(0, 0, 1), 1f);
                  yield return null;
              }
              else
              {
                  istar = false;
                Debug.LogWarning("1111成");

            }
        }*/

        inputRotate.enabled = false;
        while (transform.localPosition != target + new Vector3(0, 0, 1))
        {
          /*  var att=transform.position - target;
            Quaternion lookater= Quaternion.LookRotation(att);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookater, 1f);*/

            transform.localPosition = Vector3.MoveTowards(transform.localPosition, target + new Vector3(0, 0, 1), 10 * Time.deltaTime);
            yield return null;
        }
        transform.LookAt(target);
        yield return new WaitForSeconds(1);
        inputRotate.enabled = true;

    }



}
