using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviornmentController : MonoBehaviour
{
    [SerializeField] GameObject[] enviornmentElement;
    [SerializeField] Transform referencePoint;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(SumOfTwoNumbers(4, 9));
        StartCoroutine(CreateEnviornmentElement());
        
    }

    // Update is called once per frame
    //int SumOfTwoNumbers(int number1, int number2)
    //{
       // return number1 + number2;
    //}

    IEnumerator CreateEnviornmentElement() 
    {
        Vector3 offset = new Vector3(10, 0, 0);
        Instantiate(enviornmentElement[Random.Range(0, enviornmentElement.Length)], referencePoint.position + offset, Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(3, 6));
        StartCoroutine(CreateEnviornmentElement());
    }
}
