﻿using System;
using NXOpen;
using NXOpen.Assemblies;
using TSG_Library.Attributes;
using TSG_Library.Geom;

namespace TSG_Library.Extensions
{
    [ExtensionsAspect]
    public static class __Arc__
    {
        [Obsolete(nameof(NotImplementedException))]
        public static Arc __Mirror(
            this Arc arc,
            Surface.Plane plane)
        {
            throw new NotImplementedException();
        }

        [Obsolete(nameof(NotImplementedException))]
        public static Arc __Mirror(
            this Arc arc,
            Surface.Plane plane,
            Component from,
            Component to)
        {
            throw new NotImplementedException();
        }

        public static Point3d __CenterPoint(this Arc arc)
        {
            return arc.CenterPoint;
        }

        public static double __EndAngle(this Arc arc)
        {
            return arc.EndAngle;
        }

        public static bool __IsClosed(this Arc arc)
        {
            return arc.IsClosed();
        }

        public static bool __IsReference(this Arc arc)
        {
            return arc.IsReference;
        }

        public static NXMatrix __Matrix(this Arc arc)
        {
            return arc.Matrix;
        }

        public static Matrix3x3 __Orientation(this Arc arc)
        {
            return arc.__Matrix().__Element();
        }

        public static double __Radius(this Arc arc)
        {
            return arc.Radius;
        }
    }
}