using UnityEngine;


[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [SerializeField] [Range(0f, 20f)] float gradeSize;

    private void Update()
    {
       //  Vector3 snap;
       //  snap.x = Mathf.RoundToInt(transform.position.x / gradeSize) * gradeSize;
       // // snap.z = Mathf.RoundToInt(transform.position.z / gradeSize) * gradeSize;
       //  snap.y = Mathf.RoundToInt(transform.position.y / gradeSize) * gradeSize;
       //  transform.position = snap;
    }
}