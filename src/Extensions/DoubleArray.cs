﻿using NXOpen;

namespace TSG_Library.Extensions
{
    public static partial class Extensions_
    {
        private static Matrix3x3 _ToMatrix3x3(this double[] array)
        {
            return new Matrix3x3
            {
                Xx = array[0],
                Xy = array[1],
                Xz = array[2],
                Yx = array[3],
                Yy = array[4],
                Yz = array[5],
                Zx = array[6],
                Zy = array[7],
                Zz = array[8]
            };
        }

        public static Point3d _ToPoint3d(this double[] array)
        {
            return new Point3d(array[0], array[1], array[2]);
        }

        public static Vector3d _ToVector3d(this double[] array)
        {
            return new Vector3d(array[0], array[1], array[2]);
        }

        public static Vector3d __Multiply(this double d, Vector3d vector)
        {
            return vector._Multiply(d);
        }
    }
}