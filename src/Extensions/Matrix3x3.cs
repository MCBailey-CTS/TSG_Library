﻿using System;
using System.Linq;
using NXOpen;
using NXOpen.Assemblies;
using TSG_Library.Geom;
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Global

namespace TSG_Library.Extensions
{
    public static partial class Extensions
    {
        #region Matrix3x3

        /// <summary>
        ///     Maps an orientation from one coordinate system to another.
        /// </summary>
        /// <param name="orientation">The components of the given Orientation with the input coordinate system.</param>
        /// <param name="inputCsys">The input coordinate system.</param>
        /// <param name="outputCsys">The output coordinate system.</param>
        /// <returns>The components of the Orientation with the output coordinate system.</returns>
        public static Matrix3x3 __MapCsysToCsys(
            Matrix3x3 orientation,
            CartesianCoordinateSystem inputCsys,
            CartesianCoordinateSystem outputCsys)
        {
#pragma warning disable CS0612 // Type or member is obsolete
            Vector3d mappedXVector = __MapCsysToCsys(orientation.__AxisX(), inputCsys, outputCsys);
            Vector3d mappedYVector = __MapCsysToCsys(orientation.__AxisY(), inputCsys, outputCsys);
#pragma warning restore CS0612 // Type or member is obsolete
            return mappedXVector.__ToMatrix3x3(mappedYVector);
        }


        public static Matrix3x3 __MirrorMap(this Matrix3x3 orientation, Surface.Plane plane,
            Component fromComponent, Component toComponent)
        {
            Vector3d newXVector = __MirrorMap(orientation.__AxisY(), plane, fromComponent, toComponent);

            Vector3d newYVector = __MirrorMap(orientation.__AxisX(), plane, fromComponent, toComponent);

            return newXVector.__ToMatrix3x3(newYVector);
        }

        public static Vector3d __AxisY(this Matrix3x3 matrix)
        {
            return new Vector3d(matrix.Yx, matrix.Yy, matrix.Yz);
        }

        public static Vector3d __AxisZ(this Matrix3x3 matrix)
        {
            return new Vector3d(matrix.Zx, matrix.Zy, matrix.Zz);
        }

        public static Matrix3x3 __MapAcsToWcs(this Matrix3x3 ori)
        {
            double[] xVec = __MapAcsToWcs(ori.__AxisX()).__ToArray();
            double[] yVec = __MapAcsToWcs(ori.__AxisY()).__ToArray();
            double[] zVec = __MapAcsToWcs(ori.__AxisZ()).__ToArray();
            return xVec.Concat(yVec).Concat(zVec).ToArray().__ToMatrix3x3();
        }


        public static double[] __Array(this Matrix3x3 matrix)
        {
            return new[]
            {
                matrix.Xx, matrix.Xy, matrix.Xz,
                matrix.Yx, matrix.Yy, matrix.Yz,
                matrix.Zx, matrix.Zy, matrix.Zz
            };
        }

        public static Vector3d __AxisX(this Matrix3x3 matrix)
        {
            return new Vector3d(matrix.Xx, matrix.Xy, matrix.Xz);
        }

        public static Matrix3x3 __Mirror(this Matrix3x3 matrix, Surface.Plane plane)
        {
            Vector3d newY = matrix.__AxisX().__Mirror(plane);
            Vector3d newX = matrix.__AxisY().__Mirror(plane);
            return newX.__ToMatrix3x3(newY);
        }

        [Obsolete(nameof(NotImplementedException))]
        public static Matrix3x3 __Mirror(
            this Matrix3x3 vector,
            Surface.Plane plane,
            Component from,
            Component to)
        {
            throw new NotImplementedException();
        }


        public static Matrix3x3 __Copy(this Matrix3x3 matrix)
        {
            double[] mtxDst = new double[9];
            ufsession_.Mtx3.Copy(matrix.__Array(), mtxDst);
            return mtxDst.__ToMatrix3x3();
        }

        public static double[,] __ToTwoDimArray(this Matrix3x3 matrix)
        {
            return new[,]
            {
                { matrix.Xx, matrix.Xy, matrix.Xz },
                { matrix.Yx, matrix.Yy, matrix.Yz },
                { matrix.Zx, matrix.Zy, matrix.Zz }
            };
        }

        public static double __Determinant(this Matrix3x3 matrix)
        {
            ufsession_.Mtx3.Determinant(matrix.__Array(), out double determinant);
            return determinant;
        }

        #endregion
    }
}