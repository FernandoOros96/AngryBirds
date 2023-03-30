using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHYSICS
{
    public class VPlane
    {
        public Vec2  normal;
        public float distance;

        public VPlane(Vec2 normal, float distance)
        {
            this.normal = normal;
            this.distance = distance;
        }
        /*
        public float GetDistanceToPoint(Vector3 point)
        {
            return Vec2.Dot(normal, point) - distance;
        }

        public Vec2 GetClosestPoint(Vector3 point)
        {
            float distanceToPoint = GetDistanceToPoint(point);
            return point - distanceToPoint * normal;
        }

        public void ApplyForce(VPoint point, float strength)
        {
            float distanceToPoint = GetDistanceToPoint(point.position);
            if (distanceToPoint < 0)
            {
                point.ApplyForce(normal * strength * Mathf.Abs(distanceToPoint));
            }
        }
        */
    }
}
