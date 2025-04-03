/*利用Unity自带库使摄像头固定视角朝向。 */
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
public class LookAt : MonoBehaviour 
{ 
    public Transform playerhead; 
    void Update() 
    { 
        transform.LookAt(playerhead.transform); 
    } 
} 

/*利用unity子物品跟随父物品的特性，在角色身上挂载一个空物品，让主摄像机成为这个空物品的子物品。以实现摄像头的旋转。 */
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
public class Roll : MonoBehaviour 
{ 
    private Quaternion i0; 
    Rigidbody turn; 
    public float turning = 10; 
    public Transform updown; 
    void Start() 
    { 
     turn = GetComponent<Rigidbody>(); 
    } 
    void Update() 
    { 
        Cursor.lockState = CursorLockMode.Locked;//锁定指针到视图中心 
        Cursor.visible = false;//隐藏指针 
        float camerax = Input.GetAxis("Mouse X"); 
        if (Input.GetKey(KeyCode.LeftAlt))  
        { 
            Cursor.lockState = CursorLockMode.None; 
            Cursor.visible = true; 
            camerax = 0; 
        } 
        float turnAmountx = Mathf.Atan2(camerax, 1); 
        i0 = turn.rotation * Quaternion.Euler(0, turnAmountx * turning, 0); 
        turn.MoveRotation(i0); 
    } 
} 

/*实现摄像头上下移动的代码。 */
using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
 
public class UpDown : MonoBehaviour 
{ 
    public Transform maincamera,player,playerhead; 
 
    void Start() 
    { 
 
    } 
    void Update() 
    { 
        float cameray = Input.GetAxis("Mouse Y"); 
        if (Input.GetKey(KeyCode.LeftAlt)) 
        { 
            cameray = 0; 
        } 
        maincamera.position += new Vector3(0, cameray, 0);  
float jk = maincamera.position.y - player.position.y ; 
if (jk <= 0) { maincamera.transform.localPosition =new Vector3(maincamera.localPosition.x,player.localPosition.y , maincamera.localPosition.z); } 
if (jk > 2) { maincamera.transform.localPosition = new Vector3(maincamera.localPosition.x,2 + player.localPosition.y, maincamera.localPosition.z); } 
transform.LookAt(playerhead.transform); 
} 
} 