﻿using System.Collections.Generic;
using NXOpen;

namespace TSG_Library.UFuncs
{
    public partial class EditBlockForm
    {
        private double AlignEdgeDistanceNegZ(List<NXObject> movePtsHalf, List<NXObject> movePtsFull,
            List<Line> negZObjs, List<Line> allzAxisLines, double inputDist, double[] mappedBase, double[] mappedPoint)
        {
            double distance = MapAndConvert(inputDist, mappedBase, mappedPoint, 2);

            foreach (Line addLine in negZObjs) movePtsFull.Add(addLine);

            foreach (Line zAxisLine in allzAxisLines) ZStartPoint(distance, zAxisLine);

            MoveObjects(movePtsHalf, movePtsFull, distance, "Z", false);
            return distance;
        }


        private double AlignEdgeDistancePosZ(List<NXObject> movePtsHalf, List<NXObject> movePtsFull,
            List<Line> posZObjs, List<Line> allzAxisLines, double inputDist, double[] mappedBase, double[] mappedPoint)
        {
            double distance = MapAndConvert(inputDist, mappedBase, mappedPoint, 2);

            foreach (Line addLine in posZObjs) movePtsFull.Add(addLine);

            foreach (Line zAxisLine in allzAxisLines) ZEndPoint(distance, zAxisLine);

            MoveObjects(movePtsHalf, movePtsFull, distance, "Z", false);
            return distance;
        }


        private double AlignEdgeDistanceNegY(List<NXObject> movePtsHalf, List<NXObject> movePtsFull,
            List<Line> negYObjs, List<Line> allyAxisLines, double inputDist, double[] mappedBase, double[] mappedPoint)
        {
            double distance = MapAndConvert(inputDist, mappedBase, mappedPoint, 1);

            foreach (Line addLine in negYObjs) movePtsFull.Add(addLine);

            foreach (Line yAxisLine in allyAxisLines) YStartPoint(distance, yAxisLine);

            MoveObjects(movePtsHalf, movePtsFull, distance, "Y", false);
            return distance;
        }


        private double AlignEdgeDistancePosY(List<NXObject> movePtsHalf, List<NXObject> movePtsFull,
            List<Line> posYObjs, List<Line> allyAxisLines, double inputDist, double[] mappedBase, double[] mappedPoint)
        {
            double distance = MapAndConvert(inputDist, mappedBase, mappedPoint, 1);

            foreach (Line addLine in posYObjs) movePtsFull.Add(addLine);

            foreach (Line yAxisLine in allyAxisLines) YEndPoint(distance, yAxisLine);

            MoveObjects(movePtsHalf, movePtsFull, distance, "Y", false);
            return distance;
        }


        private double AlignEdgeDistanceNegX(List<NXObject> movePtsHalf, List<NXObject> movePtsFull,
            List<Line> negXObjs, List<Line> allxAxisLines, double inputDist, double[] mappedBase, double[] mappedPoint)
        {
            double distance = MapAndConvert(inputDist, mappedBase, mappedPoint, 0);

            foreach (Line addLine in negXObjs) movePtsFull.Add(addLine);

            foreach (Line xAxisLine in allxAxisLines) XStartPoint(distance, xAxisLine);

            MoveObjects(movePtsHalf, movePtsFull, distance, "X", false);
            return distance;
        }


        private double AlignEdgeDistancePosX(List<NXObject> movePtsHalf, List<NXObject> movePtsFull,
            List<Line> posXObjs, List<Line> allxAxisLines, double inputDist, double[] mappedBase, double[] mappedPoint)
        {
            double distance = MapAndConvert(inputDist, mappedBase, mappedPoint, 0);

            foreach (Line posXLine in posXObjs) movePtsFull.Add(posXLine);

            foreach (Line xAxisLine in allxAxisLines) XEndPoint(distance, xAxisLine);

            MoveObjects(movePtsHalf, movePtsFull, distance, "X", false);
            return distance;
        }
    }
}