class Boundary
{
    var xMin : float;
    var xMax : float;
    var zMin : float;
    var zMax : float;
}

var speed : float;
var tilt : float;
var boundary : Boundary;

function FixedUpdate () {
     var moveHorizontal : float= Input.GetAxis ("Horizontal");
     var moveVertical : float= Input.GetAxis ("Vertical");

     var movement : Vector3= new Vector3 (moveHorizontal, 0.0f, moveVertical);
    GetComponent.<Rigidbody>().velocity = movement * speed;

    GetComponent.<Rigidbody>().position = new Vector3 
    (
        Mathf.Clamp (GetComponent.<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
        0.0f, 
        Mathf.Clamp (GetComponent.<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
    );

    GetComponent.<Rigidbody>().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent.<Rigidbody>().velocity.x * -tilt);
}