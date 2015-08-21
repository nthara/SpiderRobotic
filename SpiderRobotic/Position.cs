using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderRobotic
{
  
     public   class Position
        {

            public int x, y;
            public string heading;
            public char orientation;
            public Position()
            {

            }

            public Position(int _x, int _y, string _h)
            {
                // Calling constructer to initialize the Robetic Spider's postion


                this.x = _x;
                this.y = _y;
                this.heading = _h;
            }

            // NextPostion() method will change spider's postion and direction by passing argumnet _o(orientaion)
            public void CurrentPostion(char _o)
            {

                this.orientation = _o;
                string switchExpression = heading + "->" + orientation ;
                switch (switchExpression)
                {
                    // A switch section contains case lables for changing spider postion and headings direction by giving orientation command.
                    case "Left->F":

                        this.heading = "Left";
                        this.x = x - 1;

                        break;


                    case "Left->L":
                        this.heading = "Down";

                        break;

                    case "Left->R":
                        this.heading = "Up";
                        break;

                    case "Right->F":
                        this.heading = "Right";
                        this.x = x + 1;

                        break;

                    case "Right->L":
                        this.heading = "Up";
                        break;

                    case "Right->R":
                        this.heading = "Down";
                        break;


                    case "Down->F":

                        this.heading = "Down";
                        this.y = y - 1;

                        break;


                    case "Down->L":
                        this.heading = "Right";

                        break;

                    case "Down->R":
                        this.heading = "Left";
                        break;


                    case "Up->F":

                        this.heading = "Up";
                        this.y = y + 1;

                        break;


                    case "Up->L":
                        this.heading = "Left";

                        break;

                    case "Up->R":
                        this.heading = "Right";
                        break;

                    default:
                        Console.WriteLine("Wrong Direction/Orientation given!");
                        // You cannot "fall through" any switch section, including
                        // the last one.
                        break;
                }
            }


        }
   
}
