using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
public class Move : MonoBehaviour 
{ 
private Transform m_Cam; 
private Vector3 movei; 
    private Vector3 m_Camforward; 
    const float gravity = -20; 
    public Vector3 velocityjump = new Vector3(0, 0, 0); 
    CharacterController cc; 
    public bool isGround; 
    public bool jump0, jump1, jump; 
    float forwardAmount, turnAmount; 
    public LayerMask ground; 
    public float velo; 
    void Start() 
    { 
        m_Cam = Camera.main.transform; 
        cc = GetComponent<CharacterController>(); 
    } 
    void Update() 
    { 
        isGround = Physics.Raycast(transform.position, Vector3.down, 0.07f, ground); 
        float x = Input.GetAxis("Horizontal"); 
        float z = Input.GetAxis("Vertical"); 
        Vector3 localMove = transform.InverseTransformVector(movei); 
        forwardAmount = localMove.z * 3; 
        m_Camforward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized; 
        movei = z * m_Camforward + x * m_Cam.right; 
        if (movei.magnitude > 1){ cc.Move(movei.normalized * Time.deltaTime *5); } 
        else { cc.Move(movei * Time.deltaTime *5); } 
 
        Height_Update(); 
 
        cc.Move(velocityjump * Time.deltaTime); 
        turnAmount = Mathf.Atan2(localMove.x, localMove.z); 
        if (movei != Vector3.zero) 
        { 
            transform.rotation *= Quaternion.Euler(0, turnAmount * 4.5f, 0); 
        } 
    } 
    void Height_Update() 
    { 
        if (!isGround || velocityjump.y == 8) { jump0 = true; }  
        else { jump0 = false; } 
        if (isGround && velocityjump.y == 0) { jump1 = true; } 
        else { jump1 = true; } 
        if(jump0 == false && jump1 == true) 
        { 
            if (Input.GetButtonDown("Jump")) 
            { 
                velocityjump.y = 8; 
                velo = 8; 
            } 
        }            
 
        if (isGround && velocityjump.y <= 0) 
        { 
            velocityjump.y = 0; 
            velo = 0; 
        } 
        else  
        { 
            velocityjump.y +=  gravity * Time.deltaTime; 
            velo +=  gravity  * Time.deltaTime; 
        } 
    } 
} 