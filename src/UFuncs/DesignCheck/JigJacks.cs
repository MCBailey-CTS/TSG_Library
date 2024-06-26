﻿using System;
using System.Windows.Forms;
using NXOpen;
using TSG_Library.Extensions;

namespace TSG_Library.UFuncs.UFuncUtilities.DesignCheckUtilities
{
    [Obsolete]
    public class JigJacks : IDesignCheck
    {
        //public bool IsPartValidForCheck(Part part, out string message)
        //{
        //    message = "";
        //    return true;
        //}

        public DCResult PerformCheck(Part part, out TreeNode result_node)
        {
            result_node = part.__TreeNode();
            return DCResult.fail;
        }

        //public IEnumerable<DesignCheckResult> Validate(NXOpen.Part part)
        //{
        //    NXOpen.Point3d[] childrenPositions = part.ComponentAssembly
        //                                .RootComponent
        //                                .GetChildren()
        //                                .Where(component => !component.IsSuppressed)
        //                                .Where(component => component.Prototype is NXOpen.Part)
        //                                // todo need to put this into a file
        //                                .Where(component => component._IsJckScrewTsg())
        //                                .Select(component => component._Origin())
        //                                .ToArray()
        //                            ?? new NXOpen.Point3d[0];
        //    switch (childrenPositions.Length)
        //    {
        //        case 0:
        //            yield return new DesignCheckResult(Result.Ignore, part, this, "Part didn't contain any valid jig jacks.");
        //            yield break;
        //        case 1:
        //            yield return new DesignCheckResult(Result.Fail, part, this, "Part contains only one valid jig jack.");
        //            yield break;
        //        default:
        //            yield return new DesignCheckResult(IsInchGrid(childrenPositions), part, this, "");
        //            yield break;
        //    }
        //}

        public static bool IsInchGrid(Point3d[] jjPoint3D, double tolerance = .0001)
        {
            switch (jjPoint3D.Length)
            {
                case 0:
                    throw new ArgumentException();
                case 1:
                    return true;
                default:
                    bool isInch = false;
                    const double maxSize = 72;
                    Point3d baseLocation = jjPoint3D[0];

                    for (int i = 1; i < jjPoint3D.Length; i++)
                    {
                        double distance1 = System.Math.Sqrt(
                            System.Math.Pow(baseLocation.X - jjPoint3D[i].X, 2) +
                            System.Math.Pow(baseLocation.Y - jjPoint3D[i].Y, 2) +
                            System.Math.Pow(baseLocation.Z - jjPoint3D[i].Z, 2));

                        for (int j = 1; j < maxSize; j++)
                            if (System.Math.Abs(distance1 - j) < tolerance)
                            {
                                isInch = true;
                                break;
                            }

                        if (isInch)
                            continue;

                        for (int k = 1; k < maxSize; k++)
                        {
                            for (int m = 1; m < maxSize; m++)
                            {
                                double distance2 = System.Math.Sqrt(System.Math.Pow(k, 2) + System.Math.Pow(m, 2));

                                if (!(System.Math.Abs(distance1 - distance2) < tolerance))
                                    continue;

                                isInch = true;
                                break;
                            }

                            if (isInch)
                                break;
                        }
                    }

                    return isInch;
            }
        }

        public TreeNode PerformCheck(Part part)
        {
            throw new NotImplementedException();
        }
    }
}