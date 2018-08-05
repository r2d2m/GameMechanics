### Vehicle Mechanics

#### Star wars BB-8
![BB8](/Assets/gifs/BB8-min.gif)
* BB-8 is a spherical droid character.
* A simple movement is implemented with Unity's Horizontal and Vertical input axes.
* The head's rotation along the droid's sphere is a linear interpolation between 0 and 15 degrees.
* Sphere's (Body) rotation in X and Z axes is calculated as linear distance traveled over the circumference of the circle times 360

    _θ<sub>x</sub> = (Linear distance traveled<sub>x</sub> / 2πr) * 360_

    _θ<sub>z</sub> = (Linear distance traveled<sub>z</sub> / 2πr) * 360_

* Rotation is then applied to the sphere as 
    gameObject.Rotate( _θ<sub>z</sub>_ , _0_ , _-θ<sub>x</sub>_ ); .


#### DJI Inspire drone
![DJI](/Assets/gifs/DJI-min.gif)
* 3 dimensional movement is handled by xinput controller.
* Upward and downward thrust is taken as two of the triggers input (Right trigger for upthrust and left for down).
* Pitch and roll inputs are Unity's Horizontal and Vertical axes (Left stick).
* Yaw input is Right stick's horizontal axis which rotates the drone about its Y axis.
* Animation for pitch and roll is a blend tree taking two parameters (Pitch and roll inputs).

#### Sail boat
![BB8](/Assets/gifs/Sailboat-min.gif)
* Sail boat can be turned using Horizontal input in Unity.
* The velocity scale of the sail boat is calculated as a dot product of wind direction and sail direction 

    _v = windDirectionVector . sailDirectionVector_
* This scalar value is applied to the boat's rigid body as 
    
    rb_sailboat.AddRelativeForce( sail boat's forward vector in local space * _v_ * speed, ForceMode.Acceleration );

#### Chopper
![BB8](/Assets/gifs/Chopper-min.gif)
* Inputs:
  * Upthrust: Left Shift
  * Down thrust: Left Ctrl
  * Pitch: W and S
  * Yaw: A and D.
* Force (Thrust) and torque (Yaw) is applied to game object's rigid body.
* Basic and non complex physics for a helicopter.
