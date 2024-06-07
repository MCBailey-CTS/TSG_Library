﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NXOpen;
using NXOpen.Assemblies;
using NXOpen.Features;
using NXOpen.GeometricUtilities;
using NXOpen.Layer;
using NXOpen.Positioning;
using NXOpen.Utilities;
using TSG_Library.Attributes;
using TSG_Library.Disposable;
using TSG_Library.Enum;
using TSG_Library.Exceptions;
using TSG_Library.Geom;
using TSG_Library.Utilities;
using static TSG_Library.Extensions6;
using static TSG_Library.Extensions.Extensions_;
using Curve = NXOpen.Curve;

namespace TSG_Library.Extensions
{
    [ExtensionsAspect]
    public static class __BasePart__
    {
        public enum CurveOrientations
        {
            /// <summary>Along the tangent vector of the curve at the point</summary>
            Tangent,

            /// <summary>Along the normal vector of the curve at the point</summary>
            Normal,

            /// <summary>Along the binormal vector of the curve at the point</summary>
            Binormal
        }
        //public static NXOpen.Assemblies.Component __AddComponent(
        //   this NXOpen.BasePart basePart,
        //   NXOpen.BasePart partToAdd,
        //   string referenceSet = "Entire Part",
        //   string componentName = null,
        //   NXOpen.Point3d? origin = null,
        //   NXOpen.Matrix3x3? orientation = null,
        //   int layer = 1)
        //{
        //    basePart.__AssertIsWorkPart();
        //    NXOpen.Point3d __origin = origin ?? new NXOpen.Point3d(0d, 0d, 0d);
        //    NXOpen.Matrix3x3 __orientation = orientation ?? new NXOpen.Matrix3x3
        //    {
        //        Xx = 1,
        //        Xy = 0,
        //        Xz = 0,
        //        Yx = 0,
        //        Yy = 1,
        //        Yz = 0,
        //        Zx = 0,
        //        Zy = 0,
        //        Zz = 1,
        //    };

        //    string __name = componentName ?? basePart.Leaf;
        //    return basePart.ComponentAssembly.AddComponent(partToAdd, referenceSet, __name, __origin, __orientation, layer, out _);
        //}

        public static void __NXOpenBasePart(BasePart base_part)
        {
            //base_part.Annotations
            //base_part.Arcs
            //base_part.Axes
            //base_part.CanBeDisplayPart
            //base_part.Close
            //base_part.ComponentAssembly
            //base_part.CoordinateSystems
            //base_part.CreateReferenceSet
            //base_part.Curves
            //base_part.Datums
            //base_part.Directions
            //base_part.Displayed
            //base_part.Ellipses
            //base_part.Expressions
            //base_part.BaseFeatures
            //base_part.DeleteReferenceSet
            //base_part.Features
            //base_part.FullPath
            //base_part.GetAllReferenceSets
            //base_part.GetHistoryInformation
            //base_part.GetMinimallyLoadedParts
            //base_part.Grids
            //base_part.HasAnyMinimallyLoadedChildren
            //base_part.HasWriteAccess
            //base_part.Hyperbolas
            //base_part.IsFullyLoaded
            //base_part.IsModified
            //base_part.IsReadOnly
            //base_part.LayerCategories
            //base_part.Layers
            //base_part.Leaf
            //base_part.Lines
            //base_part.LoadFully
            //base_part.LoadThisPartFully
            //base_part.LoadThisPartPartially
            //base_part.ModelingViews
            //base_part.NXMatrices
            //base_part.Parabolas
            //base_part.PartLoadState
            //base_part.PartUnits
            //base_part.Planes
            //base_part.Points
            //base_part.Reopen
            //base_part.ReverseBlankAll
            //base_part.Save
            //base_part.SaveAs
            //base_part.ScCollectors
            //base_part.ScRuleFactory
            //base_part.Sections
            //base_part.Undisplay
            //base_part.UniqueIdentifier
            //base_part.UnitCollection
            //base_part.UserDefinedObjectManager
            //base_part.Views
            //base_part.WCS
        }

        /// <summary>
        ///     Creates a cylinder feature, given base point, direction, height and diameter<br />
        ///     expressions
        /// </summary>
        /// <param name="basePart">THe part to place the Cyclinder in</param>
        /// <param name="axisPoint">The point at base of cylinder</param>
        /// <param name="axisVector">The cylinder axis vector (length doesn't matter)</param>
        /// <param name="height">The cylinder height</param>
        /// <param name="diameter">The cylinder diameter</param>
        /// <returns>An NX.Cylinder feature</returns>
        internal static Cylinder __CreateCylinder(
            this BasePart basePart,
            Point3d axisPoint,
            Vector3d axisVector,
            double height,
            double diameter)
        {
            basePart.__AssertIsWorkPart();
            var part = __work_part_;
            var cylinderBuilder = part.Features.CreateCylinderBuilder(null);

            using (session_.using_builder_destroyer(cylinderBuilder))
            {
                cylinderBuilder.Type = CylinderBuilder.Types.AxisDiameterAndHeight;
                cylinderBuilder.BooleanOption.Type = BooleanOperation.BooleanType.Create;
                cylinderBuilder.Diameter.RightHandSide = diameter.ToString();
                cylinderBuilder.Height.RightHandSide = height.ToString();
                var origin = _Point3dOrigin;
                var direction = part.Directions.CreateDirection(origin, axisVector,
                    SmartObject.UpdateOption.WithinModeling);
                cylinderBuilder.Axis.Direction = direction;
                cylinderBuilder.Axis.Point = part.Points.CreatePoint(axisPoint);
                var cylinder = (Cylinder)cylinderBuilder.Commit();
                return cylinder;
            }
        }


        public static SetWorkPartContextQuietly __UsingSetWorkPartQuietly(this BasePart basePart)
        {
            return new SetWorkPartContextQuietly(basePart);
        }


        public static Point __CreatePoint(this BasePart part, Point3d point3D)
        {
            return part.Points.CreatePoint(point3D);
        }

        public static bool __HasDrawingSheet(this BasePart part, string drawingSheetName)
        {
            return ((Part)part).__HasDrawingSheet(drawingSheetName, StringComparison.Ordinal);
        }

        public static TreeNode __TreeNode(this BasePart part)
        {
            return new TreeNode(part.Leaf) { Tag = part };
        }

        public static string __AskDetailOp(this BasePart part)
        {
            return part.Leaf._AskDetailOp();
        }

        public static bool __IsPartDetail(this BasePart part)
        {
            return part.Leaf._IsPartDetail();
        }


        //ufsession_.Part.CheckPartWritable
        //ufsession_.Part.AskUnits
        //ufsession_.Part.AskStatus
        //ufsession_.Part.AddToRecentFileList
        //ufsession_.Part.AskNthPart
        //ufsession_.Part.AskNumParts
        //ufsession_.Part.ClearHistoryList
        //ufsession_.Part.CloseAll();

        //public static TreeNode _TreeNode(this NXOpen.BasePart part) => new TreeNode(part.Leaf) { Tag = part };

        public static bool __HasDrawingSheet(
            this BasePart part,
            string drawingSheetName,
            StringComparison stringComparison)
        {
            return part.__ToPart().DrawingSheets.ToArray()
                .Any(sheet => string.Equals(sheet.Name, drawingSheetName, stringComparison));
        }

        public static Part __ToPart(this BasePart basePart)
        {
            return (Part)basePart;
        }


        public static Expression __FindExpressionOrNull(this BasePart part, string expressionName)
        {
            return part.__FindExpressionOrNull(expressionName, StringComparison.OrdinalIgnoreCase);
        }

        public static Expression __FindExpressionOrNull(this BasePart part, string expressionName,
            StringComparison stringComparison)
        {
            return part.Expressions.Cast<Expression>()
                .SingleOrDefault(expression => expression.Name.Equals(expressionName, stringComparison));
        }

        //public static bool _HasModelingView(this NXOpen.BasePart part, string modelingViewName)
        //{
        //    return part._FindModelingViewOrNull(modelingViewName) != null;
        //}

        public static ModelingView __FindModelingViewOrNull(this BasePart part, string modelingViewName)
        {
            return part.ModelingViews.ToArray().SingleOrDefault(view => view.Name == modelingViewName);
        }

        public static ModelingView __FindModelingView(this BasePart part, string modelingViewName)
        {
            return part.__FindModelingViewOrNull(modelingViewName) ?? throw new Exception(
                $"Could not find modeling view in part \"{part.Leaf}\" with name \"{modelingViewName}\".");
        }

        [Obsolete]
        public static IEnumerable<BasePart> __DescendantParts(this BasePart nxPart)
        {
            //return nxPart.ComponentAssembly?.RootComponent._Descendants(true, true, true)
            //            .Where(__c => __c._IsLoaded())
            //            .Select(__c => __c._Prototype())
            //            .DistinctBy(__p => __p.Tag)
            //            ??
            //            new NXOpen.BasePart[] { nxPart };
            throw new NotImplementedException();
        }

        public static bool __IsCasting(this BasePart part)
        {
            if(!part.__IsPartDetail())
                return false;

            var materials = Ucf.StaticRead(Ucf.ConceptControlFile, ":CASTING_MATERIALS:",
                ":END_CASTING_MATERIALS:", StringComparison.OrdinalIgnoreCase).ToArray();
            const string material = "MATERIAL";

            if(!Regex.IsMatch(part.Leaf, Regex_Detail))
                return false;

            if(!part.HasUserAttribute(material, NXObject.AttributeType.String, -1))
                return false;

            var materialValue = part.GetUserAttributeAsString(material, NXObject.AttributeType.String, -1);

            return materialValue != null && materials.Any(s => materialValue.Contains(s));
        }

        /// <summary>Constructs a fillet arc from three points</summary>
        /// <param name="p0">First point</param>
        /// <param name="pa">Apex point</param>
        /// <param name="p1">Last point</param>
        /// <param name="radius">Radius</param>
        /// <returns>An NXOpen.Arc representing the fillet</returns>
        /// <remarks>
        ///     <para>
        ///         The fillet will be tangent to the lines p0-pa and pa-p1.
        ///         Its angular span will we be less than 180 degrees.
        ///     </para>
        /// </remarks>
        internal static Arc __CreateArcFillet(
            this BasePart basePart,
            Point3d p0,
            Point3d pa,
            Point3d p1,
            double radius)
        {
            var arc = Geom.Curve.Arc.Fillet(p0, pa, p1, radius);
            return basePart.__CreateArc(arc.Center, arc.AxisX, arc.AxisY, arc.Radius, arc.StartAngle, arc.EndAngle);
        }

        /// <summary>
        ///     Creates a <see cref="NXOpen.Features.BooleanFeature" />
        /// </summary>
        /// <param name="target">Target body</param>
        /// <param name="toolBodies">Array of tool bodies</param>
        /// <param name="booleanType">Type of boolean operation (unions, subtract, etc.)</param>
        /// <returns>NX.Boolean feature formed by operation</returns>
        internal static BooleanFeature __CreateBoolean(this BasePart basePart,
            Body target, Body[] toolBodies, Feature.BooleanType booleanType)
        {
            basePart.__AssertIsWorkPart();
            var part = __work_part_;
            var builder = part.Features.CreateBooleanBuilder(null);

            using (session_.using_builder_destroyer(builder))
            {
                builder.Operation = booleanType;
                builder.Target = target;
                foreach (var body in toolBodies)
                    //#pragma warning disable CS0618 // Type or member is obsolete
                    builder.Tools.Add(body);
                //#pragma warning restore CS0618 // Type or member is obsolete
                var boolean =
                    (BooleanFeature)(Feature)builder.Commit();
                return boolean;
            }
        }

        public static void __AssertIsDisplayPart(this BasePart basePart)
        {
            if(session_.Parts.Display.Tag != basePart.Tag)
                throw new ArgumentException($"Part must be display part to {nameof(__AssertIsDisplayPart)}");
        }

        public static void __AssertIsDisplayOrWorkPart(this BasePart basePart)
        {
            if(session_.Parts.Display.Tag != basePart.Tag || session_.Parts.Work.Tag != basePart.Tag)
                throw new PartIsNotWorkOrDisplayException();
        }

        public static TaggedObject[] __CycleByName(this BasePart basePart, string name)
        {
            basePart.__AssertIsWorkPart();
            var _tag = Tag.Null;
            var list = new List<TaggedObject>();

            while (true)
            {
                ufsession_.Obj.CycleByName(name, ref _tag);

                if(_tag == Tag.Null)
                    break;

                list.Add(session_.GetObjectManager().GetTaggedObject(_tag));
            }

            return list.ToArray();
        }

        /// <summary>Creates an NX.Block with two points and height</summary>
        /// <param name="matrix">Orientation (see remarks)</param>
        /// <param name="originPoint">The origin-point of the block (in absolute coordinates</param>
        /// <param name="cornerPoint">The corner-point of the block</param>
        /// <param name="height">Height</param>
        /// <returns>An NX.Block object</returns>
        internal static Block __CreateBlock(this BasePart basePart, Matrix3x3 matrix,
            Point3d originPoint, Point3d cornerPoint, double height)
        {
            basePart.__AssertIsWorkPart();
            var part = __work_part_;
            var wcsOrientation = __display_part_.WCS._Orientation();
            __display_part_.WCS._Orientation(matrix);
            var builder = part.Features.CreateBlockFeatureBuilder(null);

            using (session_.using_builder_destroyer(builder))
            {
                builder.Type = BlockFeatureBuilder.Types.TwoPointsAndHeight;
                builder.BooleanOption.Type = BooleanOperation.BooleanType.Create;
                builder.SetTwoPointsAndHeight(originPoint, cornerPoint, height.ToString());
                __display_part_.WCS._Orientation(wcsOrientation);
                return (Block)builder.Commit();
            }
        }

        /// <summary>Creates an NX.Block from two diagonal points</summary>
        /// <param name="matrix">Orientation</param>
        /// <param name="originPoint">The origin-point of the block (in absolute coordinates</param>
        /// <param name="cornerPoint">The corner-point of the block </param>
        /// <returns>An NX.Block object</returns>
        internal static Block __CreateBlock(this BasePart basePart, Matrix3x3 matrix,
            Point3d originPoint, Point3d cornerPoint)
        {
            basePart.__AssertIsWorkPart();
            var part = __work_part_;
            var wcsOrientation = __wcs_.Orientation.Element;
            __wcs_.SetDirections(matrix._AxisX(), matrix._AxisY());
            var builder = part.Features.CreateBlockFeatureBuilder(null);

            using (session_.using_builder_destroyer(builder))
            {
                builder.Type = BlockFeatureBuilder.Types.DiagonalPoints;
                builder.BooleanOption.Type = BooleanOperation.BooleanType.Create;
                builder.SetTwoDiagonalPoints(originPoint, cornerPoint);
                var block = (Block)builder.Commit();
                __wcs_.SetDirections(wcsOrientation._AxisX(), Wcs.__Orientation().Element._AxisY());
                return block;
            }
        }

        [Obsolete(nameof(NotImplementedException))]
        public static TaggedObject[] __CycleObjsInPart1(this BasePart basePart, string name)
        {
            //basePart._AssertIsWorkPart();
            //NXOpen.Tag _tag = NXOpen.Tag.Null;
            //var list = new List<NXOpen.TaggedObject>();

            //while (true)
            //{
            //    ufsession_.Obj.CycleObjsInPart1(name, ref _tag);

            //    if (_tag == NXOpen.Tag.Null)
            //        break;

            //    list.Add(session_.GetObjectManager().GetTaggedObject(_tag));
            //}

            //return list.ToArray();
            throw new NotImplementedException();
        }

        public static void __Reopen(this BasePart basePart, ReopenScope scope = ReopenScope.PartAndSubassemblies,
            ReopenMode mode = ReopenMode.ReopenAll)
        {
            ufsession_.Part.Reopen(basePart.Tag, (int)scope, (int)mode, out _);
        }


        public static bool __IsModified(this BasePart basePart)
        {
            return ufsession_.Part.IsModified(basePart.Tag);
        }

        public static DatumCsys __AbsoluteDatumCsys(this BasePart basePart)
        {
            return basePart.Features
                .OfType<DatumCsys>()
                .First();
        }

        public static Feature __CreateTextFeature(
            this BasePart part,
            string note,
            Point3d origin,
            Matrix3x3 orientation,
            double length,
            double height,
            string font,
            TextBuilder.ScriptOptions script)
        {
            var textBuilder = part.Features.CreateTextBuilder(null);

            using (new Destroyer(textBuilder))
            {
                textBuilder.PlanarFrame.AnchorLocation =
                    RectangularFrameBuilder.AnchorLocationType.MiddleCenter;
                textBuilder.PlanarFrame.WScale = 100.0;
                textBuilder.PlanarFrame.Length.RightHandSide = $"{length}";
                textBuilder.PlanarFrame.Height.RightHandSide = $"{height}";
                textBuilder.PlanarFrame.WScale = 75d;
                textBuilder.SelectFont(font, script);
                textBuilder.TextString = note;
                var point2 = part.Points.CreatePoint(origin);
                var csys =
                    part.CoordinateSystems.CreateCoordinateSystem(origin, orientation, true);
                textBuilder.PlanarFrame.CoordinateSystem = csys;
                textBuilder.PlanarFrame.UpdateOnCoordinateSystem();
                var workView = session_.Parts.Work.ModelingViews.WorkView;
                textBuilder.PlanarFrame.AnchorLocator.SetValue(point2, workView, origin);
                return (Text)textBuilder.Commit();
            }
        }

        public static void __SetWcsToAbsolute(this BasePart part)
        {
            part.WCS.SetOriginAndMatrix(_Point3dOrigin, _Matrix3x3Identity);
        }

        public static void __Save(this BasePart part, bool save_child_components = false,
            bool close_after_save = false)
        {
            part.Save(
                save_child_components ? BasePart.SaveComponents.True : BasePart.SaveComponents.False,
                close_after_save ? BasePart.CloseAfterSave.True : BasePart.CloseAfterSave.False);
        }

        /// <summary>Creates a layer category with a given name</summary>
        /// <param name="name">Name of layer category</param>
        /// <param name="description">Description of layer category</param>
        /// <param name="layers">Layers to be placed into the category</param>
        /// <returns>An NX.Category object</returns>
        /// <exception cref="ArgumentException"></exception>
        internal static Category __CreateCategory(this BasePart basePart, string name,
            string description, params int[] layers)
        {
            basePart.__AssertIsWorkPart();

            try
            {
                return __work_part_.LayerCategories.CreateCategory(name, description, layers);
            }
            catch (NXException ex)
            {
                if(ex.ErrorCode == 3515007)
                {
                    var message = "A category with the given name already exists.";
                    var ex2 = new ArgumentException(message, ex);
                    throw ex2;
                }

                throw new ArgumentException("unknown error", ex);
            }
        }

        /// <summary>
        ///     Creates a Snap.NX.Chamfer feature
        /// </summary>
        /// <param name="edge">Edge used to chamfer</param>
        /// <param name="distance">Offset distance</param>
        /// <param name="offsetFaces">
        ///     The offsetting method used to determine the size of the chamfer If true, the<br />
        ///     edges of the chamfer face will be constructed by offsetting the faces adjacent<br />
        ///     to the selected edge If false, the edges of the chamfer face will be constructed<br />
        ///     by offsetting the selected edge along the adjacent faces
        /// </param>
        /// <returns>An NX.Chamfer object</returns>
        internal static Chamfer __CreateChamfer(this BasePart basePart, Edge edge,
            double distance, bool offsetFaces)
        {
            basePart.__AssertIsWorkPart();
            var part = __work_part_;
            var chamferBuilder = part.Features.CreateChamferBuilder(null);

            using (session_.using_builder_destroyer(chamferBuilder))
            {
                chamferBuilder.Option = ChamferBuilder.ChamferOption.SymmetricOffsets;

                chamferBuilder.Method = offsetFaces
                    ? ChamferBuilder.OffsetMethod.FacesAndTrim
                    : ChamferBuilder.OffsetMethod.EdgesAlongFaces;

                chamferBuilder.FirstOffset = distance.ToString();
                chamferBuilder.SecondOffset = distance.ToString();
                chamferBuilder.Tolerance = DistanceTolerance;
                var scCollector = part.ScCollectors.CreateCollector();
                var edgeTangentRule = part.__CreateRuleEdgeTangent(edge);
                var rules = new SelectionIntentRule[1] { edgeTangentRule };
                scCollector.ReplaceRules(rules, false);
                chamferBuilder.SmartCollector = scCollector;
                var feature = chamferBuilder.CommitFeature();
                return (Chamfer)feature;
            }
        }

        /// <summary>
        ///     Creates a chamfer object
        /// </summary>
        /// <param name="edge">Edge used to chamfer</param>
        /// <param name="distance1">Offset distance1</param>
        /// <param name="distance2">Offset distance2</param>
        /// <param name="offsetFaces">
        ///     The offsetting method used to determine the size of the chamfer If true, the<br />
        ///     edges of the chamfer face will be constructed by offsetting the faces adjacent<br />
        ///     to the selected edge If false, the edges of the chamfer face will be constructed<br />
        ///     by offsetting the selected edge along the adjacent faces
        /// </param>
        /// <returns>An NX.Chamfer object</returns>
        internal static Chamfer __CreateChamfer(this BasePart basePart, Edge edge,
            double distance1, double distance2, bool offsetFaces)
        {
            basePart.__AssertIsWorkPart();
            var part = __work_part_;
            var chamferBuilder = part.Features.CreateChamferBuilder(null);

            using (session_.using_builder_destroyer(chamferBuilder))
            {
                chamferBuilder.Option = ChamferBuilder.ChamferOption.TwoOffsets;
                chamferBuilder.Method = offsetFaces
                    ? ChamferBuilder.OffsetMethod.FacesAndTrim
                    : ChamferBuilder.OffsetMethod.EdgesAlongFaces;
                chamferBuilder.FirstOffset = distance1.ToString();
                chamferBuilder.SecondOffset = distance2.ToString();
                chamferBuilder.Tolerance = DistanceTolerance;
                var scCollector = part.ScCollectors.CreateCollector();
                var edgeTangentRule = part.ScRuleFactory.CreateRuleEdgeTangent(edge, null,
                    false, AngleTolerance, false, false);
                var rules = new SelectionIntentRule[1] { edgeTangentRule };
                scCollector.ReplaceRules(rules, false);
                chamferBuilder.SmartCollector = scCollector;
                var feature = chamferBuilder.CommitFeature();
                return (Chamfer)feature;
            }
        }

        /// <summary>Creates a chamfer object</summary>
        /// <param name="edge">Edge used to chamfer</param>
        /// <param name="distance">Offset distance</param>
        /// <param name="angle">Offset angle</param>
        /// <returns>An NX.Chamfer object</returns>
        internal static Chamfer __CreateChamfer(this BasePart basePart, Edge edge,
            double distance, double angle)
        {
            basePart.__AssertIsWorkPart();
            var part = __work_part_;
            var chamferBuilder = part.Features.CreateChamferBuilder(null);

            using (session_.using_builder_destroyer(chamferBuilder))
            {
                chamferBuilder.Option = ChamferBuilder.ChamferOption.OffsetAndAngle;
                chamferBuilder.FirstOffset = distance.ToString();
                chamferBuilder.Angle = angle.ToString();
                chamferBuilder.Tolerance = DistanceTolerance;
                var scCollector = part.ScCollectors.CreateCollector();
                var edgeTangentRule = part.ScRuleFactory.CreateRuleEdgeTangent(edge, null,
                    true, AngleTolerance, false, false);
                var rules = new SelectionIntentRule[1] { edgeTangentRule };
                scCollector.ReplaceRules(rules, false);
                chamferBuilder.SmartCollector = scCollector;
                chamferBuilder.AllInstances = false;
                var feature = chamferBuilder.CommitFeature();
                return (Chamfer)feature;
            }
        }

        /// <summary>Creates a datum axis object</summary>
        /// <param name="icurve">Icurve is an edge or a curve</param>
        /// <param name="arcLengthPercent">Percent arcLength, in range 0 to 100</param>
        /// <param name="curveOrientation">The curve orientation used by axis</param>
        /// <returns>An NX.DatumAxis object</returns>
        internal static DatumAxisFeature __CreateDatumAxis(
            this BasePart basePart,
            ICurve icurve,
            double arcLengthPercent,
            CurveOrientations curveOrientation)
        {
            basePart.__AssertIsWorkPart();
            var datumAxisBuilder = __work_part_.Features.CreateDatumAxisBuilder(null);

            using (session_.using_builder_destroyer(datumAxisBuilder))
            {
                datumAxisBuilder.Type = DatumAxisBuilder.Types.OnCurveVector;
                datumAxisBuilder.ArcLength.IsPercentUsed = true;
                datumAxisBuilder.ArcLength.Expression.RightHandSide = arcLengthPercent.ToString();
                datumAxisBuilder.CurveOrientation =
                    (DatumAxisBuilder.CurveOrientations)curveOrientation;
                datumAxisBuilder.IsAssociative = true;
                datumAxisBuilder.IsAxisReversed = false;
                datumAxisBuilder.Curve.Value = icurve;
                datumAxisBuilder.ArcLength.Path.Value = (TaggedObject)icurve;
                datumAxisBuilder.ArcLength.Update(OnPathDimensionBuilder.UpdateReason.Path);
                return (DatumAxisFeature)datumAxisBuilder.Commit();
            }
        }

        /// <summary>Creates an edge blend object</summary>
        /// <param name="edges">Edge array used to blend</param>
        /// <param name="radius">Radius of a regular blend</param>
        /// <returns>An NX.EdgeBlend object</returns>
        internal static EdgeBlend __CreateEdgeBlend(this BasePart basePart, double radius,
            Edge[] edges)
        {
            basePart.__AssertIsWorkPart();
            var part = __work_part_;
            var edgeBlendBuilder = part.Features.CreateEdgeBlendBuilder(null);

            using (session_.using_builder_destroyer(edgeBlendBuilder))
            {
                _ = edgeBlendBuilder.LimitsListData;
                var scCollector = part.ScCollectors.CreateCollector();
                var array = new Edge[edges.Length];

                for (var i = 0; i < array.Length; i++)
                    array[i] = edges[i];

                var edgeMultipleSeedTangentRule =
                    part.ScRuleFactory.CreateRuleEdgeMultipleSeedTangent(
                        array,
                        AngleTolerance,
                        true);

                var rules = new SelectionIntentRule[1] { edgeMultipleSeedTangentRule };
                scCollector.ReplaceRules(rules, false);
                edgeBlendBuilder.Tolerance = DistanceTolerance;
                edgeBlendBuilder.AllInstancesOption = false;
                edgeBlendBuilder.RemoveSelfIntersection = true;
                edgeBlendBuilder.ConvexConcaveY = false;
                edgeBlendBuilder.RollOverSmoothEdge = true;
                edgeBlendBuilder.RollOntoEdge = true;
                edgeBlendBuilder.MoveSharpEdge = true;
                edgeBlendBuilder.TrimmingOption = false;
                edgeBlendBuilder.OverlapOption = EdgeBlendBuilder.Overlap.AnyConvexityRollOver;
                edgeBlendBuilder.BlendOrder = EdgeBlendBuilder.OrderOfBlending.ConvexFirst;
                edgeBlendBuilder.SetbackOption = EdgeBlendBuilder.Setback.SeparateFromCorner;
                edgeBlendBuilder.AddChainset(scCollector, radius.ToString());
                var feature = edgeBlendBuilder.CommitFeature();
                return (EdgeBlend)feature;
            }
        }

        /// <summary>Creates an extract object</summary>
        /// <param name="faces">The face array which will be extracted</param>
        /// <returns>An NX.ExtractFace feature</returns>
        internal static ExtractFace __CreateExtractFace(this BasePart basePart,
            Face[] faces)
        {
            basePart.__AssertIsDisplayPart();
            var part = __work_part_;
            var builder = part.Features.CreateExtractFaceBuilder(null);

            using (session_.using_builder_destroyer(builder))
            {
                builder.FaceOption = ExtractFaceBuilder.FaceOptionType.FaceChain;
                var array = new Face[faces.Length];

                for (var i = 0; i < faces.Length; i++)
                    array[i] = faces[i];

                var faceDumbRule = part.ScRuleFactory.CreateRuleFaceDumb(array);
                var rules = new SelectionIntentRule[1] { faceDumbRule };
                builder.FaceChain.ReplaceRules(rules, false);
                var extract = (ExtractFace)builder.CommitFeature();
                return extract;
            }
        }

        public static Extrude __CreateExtrude(
            this BasePart part,
            Curve[] curves,
            Vector3d direction,
            double start,
            double end)
        {
            part.__AssertIsWorkPart();
            var builder = part.Features.CreateExtrudeBuilder(null);

            using (session_.using_builder_destroyer(builder))
            {
                SelectionIntentRule[] rules = { part.ScRuleFactory.CreateRuleCurveDumb(curves) };
                builder.Section = __display_part_.Sections.CreateSection();
                builder.Section.AddToSection(rules, null, null, null, _Point3dOrigin, Section.Mode.Create,
                    false);
                builder.Limits.StartExtend.Value.Value = start;
                builder.Limits.EndExtend.Value.Value = end;

                builder.Direction = part.Directions.CreateDirection(
                    curves[0]._StartPoint(),
                    direction,
                    SmartObject.UpdateOption.WithinModeling);

                return (Extrude)builder.Commit();
            }
        }


        public static CartesianCoordinateSystem __CreateCsys(
            this BasePart part,
            Point3d origin,
            Matrix3x3 orientation,
            bool makeTemporary = true)
        {
            // Creates and NXMatrix with the orientation of the {orientation}.
            var matrix = part.__OwningPart().NXMatrices.Create(orientation);
            // The tag to hold the csys.
            Tag csysId;

            if(makeTemporary)
                ufsession_.Csys.CreateTempCsys(origin._ToArray(), matrix.Tag, out csysId);
            else
                ufsession_.Csys.CreateCsys(origin._ToArray(), matrix.Tag, out csysId);

            return (CartesianCoordinateSystem)NXObjectManager.Get(csysId);
        }

        public static CartesianCoordinateSystem __CreateCsys(this BasePart part,
            bool makeTemporary = true)
        {
            return part.__CreateCsys(_Point3dOrigin, _Matrix3x3Identity, makeTemporary);
        }

        internal static OffsetCurve __CreateOffsetLine(
            this BasePart basePart,
            ICurve icurve,
            Point point,
            string height,
            string angle,
            bool reverseDirection)
        {
            basePart.__AssertIsWorkPart();
            var part = __work_part_;
            var offsetCurveBuilder = part.Features.CreateOffsetCurveBuilder(null);

            using (session_.using_builder_destroyer(offsetCurveBuilder))
            {
                offsetCurveBuilder.Type = OffsetCurveBuilder.Types.Draft;
                offsetCurveBuilder.InputCurvesOptions.InputCurveOption =
                    CurveOptions.InputCurve.Retain;
                offsetCurveBuilder.CurveFitData.Tolerance = DistanceTolerance;
                offsetCurveBuilder.PointOnOffsetPlane = point;
                offsetCurveBuilder.DraftHeight.RightHandSide = height;
                offsetCurveBuilder.DraftAngle.RightHandSide = angle;
                offsetCurveBuilder.ReverseDirection = reverseDirection;
                var section = offsetCurveBuilder.CurvesToOffset;
                section.AddICurve(icurve);
                var feature = offsetCurveBuilder.CommitFeature();
                offsetCurveBuilder.CurvesToOffset.CleanMappingData();
                return feature as OffsetCurve;
            }
        }


        private static void __VarBlend(
            this BasePart part,
            Edge edge,
            double[] arclengthPercents,
            double[] radii)
        {
            part.__AssertIsWorkPart();
            var edgeBlendBuilder = part.Features.CreateEdgeBlendBuilder(null);

            using (session_.using_builder_destroyer(edgeBlendBuilder))
            {
                var scCollector = part.ScCollectors.CreateCollector();
                var edges = new Edge[1] { edge };
                var edgeDumbRule = part.ScRuleFactory.CreateRuleEdgeDumb(edges);
                var rules = new SelectionIntentRule[1] { edgeDumbRule };
                scCollector.ReplaceRules(rules, false);
                edgeBlendBuilder.AddChainset(scCollector, "5");
                var parameter = arclengthPercents[0].ToString();
                var parameter2 = arclengthPercents[1].ToString();
                var radius = radii[0].ToString();
                var radius2 = radii[1].ToString();
                Point smartPoint = null;
                edgeBlendBuilder.AddVariablePointData(edge, parameter, radius, "3.333", "0.6", smartPoint,
                    false, false);
                edgeBlendBuilder.AddVariablePointData(edge, parameter2, radius2, "3.333", "0.6", smartPoint,
                    false, false);
                edgeBlendBuilder.Tolerance = DistanceTolerance;
                edgeBlendBuilder.AllInstancesOption = false;
                edgeBlendBuilder.RemoveSelfIntersection = true;
                edgeBlendBuilder.PatchComplexGeometryAreas = true;
                edgeBlendBuilder.LimitFailingAreas = true;
                edgeBlendBuilder.ConvexConcaveY = false;
                edgeBlendBuilder.RollOverSmoothEdge = true;
                edgeBlendBuilder.RollOntoEdge = true;
                edgeBlendBuilder.MoveSharpEdge = true;
                edgeBlendBuilder.TrimmingOption = false;
                edgeBlendBuilder.OverlapOption = EdgeBlendBuilder.Overlap.AnyConvexityRollOver;
                edgeBlendBuilder.BlendOrder = EdgeBlendBuilder.OrderOfBlending.ConvexFirst;
                edgeBlendBuilder.SetbackOption = EdgeBlendBuilder.Setback.SeparateFromCorner;
                edgeBlendBuilder.CommitFeature();
            }
        }


        public static Component __RootComponentOrNull(this BasePart nxPart)
        {
            return nxPart.ComponentAssembly?.RootComponent;
        }

        public static Component __RootComponent(this BasePart nxPart)
        {
            return nxPart.__RootComponentOrNull() ?? throw new ArgumentException();
        }

        public static void __Save(this BasePart part)
        {
            part.__Save(BasePart.SaveComponents.True);
        }

        public static void __Save(this BasePart part, BasePart.SaveComponents saveComponents)
        {
            part.Save(saveComponents, BasePart.CloseAfterSave.False);
        }


        public static bool __IsSee3DData(this BasePart part)
        {
            var regex = new Regex("SEE(-|_| )3D(-|_| )DATA");

            if(!part.HasUserAttribute("DESCRIPTION", NXObject.AttributeType.String, -1))
                return false;

            var descriptionValue =
                part.GetUserAttributeAsString("DESCRIPTION", NXObject.AttributeType.String, -1);
            return descriptionValue != null && regex.IsMatch(descriptionValue.ToUpper());
        }


        /// <summary>Creates a tube feature, given spine and inner/outer diameters</summary>
        /// <param name="spine">The centerline (spine) of the tube</param>
        /// <param name="outerDiameter">Outer diameter</param>
        /// <param name="innerDiameter">Inner diameter</param>
        /// <param name="createBsurface">If true, creates a single b-surface for the inner and outer faces of the tube</param>
        /// <returns>An NX.Tube object</returns>
        internal static Tube __CreateTube(
            this BasePart basePart,
            Curve spine,
            double outerDiameter,
            double innerDiameter,
            bool createBsurface)
        {
            basePart.__AssertIsWorkPart();
            var part = __work_part_;
            var tubeBuilder = part.Features.CreateTubeBuilder(null);

            using (session_.using_builder_destroyer(tubeBuilder))
            {
                tubeBuilder.Tolerance = DistanceTolerance;
                tubeBuilder.OuterDiameter.RightHandSide = outerDiameter.ToString();
                tubeBuilder.InnerDiameter.RightHandSide = innerDiameter.ToString();
                tubeBuilder.OutputOption = TubeBuilder.Output.MultipleSegments;

                if(createBsurface)
                    tubeBuilder.OutputOption = TubeBuilder.Output.SingleSegment;

                var section = tubeBuilder.PathSection;
                section.AddICurve(spine);
                tubeBuilder.BooleanOption.Type = BooleanOperation.BooleanType.Create;
                var tube = (Tube)tubeBuilder.CommitFeature();
                return tube;
            }
        }


        /// <summary>Creates an NX.Point object from given coordinates</summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="z">z coordinate</param>
        /// <returns>An invisible NXOpen.Point object (a "smart point")</returns>
        internal static Point __CreatePointInvisible(this BasePart basePart, double x, double y, double z)
        {
            basePart.__AssertIsWorkPart();
            var part = __work_part_;
            var coordinates = new Point3d(x, y, z);
            var point = part.Points.CreatePoint(coordinates);
            point.SetVisibility(SmartObject.VisibilityOption.Invisible);
            return point;
        }


        /// <summary>Creates an NX.Point object</summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="z">z coordinate</param>
        /// <returns>An NX.Point object</returns>
        internal static Point __CreatePoint(this BasePart basePart, double x, double y, double z)
        {
            basePart.__AssertIsWorkPart();
            var uFSession = ufsession_;
            var point_coords = new double[3] { x, y, z };
            uFSession.Curve.CreatePoint(point_coords, out var point);
            return (Point)session_._GetTaggedObject(point);
        }

        /// <summary>Creates a point from xy-coordinates (assumes z=0)</summary>
        /// <param name="x">x-coordinate</param>
        /// <param name="y">y-coordinate</param>
        /// <returns>A <see cref="T:Snap.NX.Point">Snap.NX.Point</see> object</returns>
        public static Point __CreatePoint(this BasePart basePart, double x, double y)
        {
            return basePart.__CreatePoint(x, y, 0.0);
        }


        public static void __Close(this BasePart part, bool close_whole_tree = false,
            bool close_modified = false)
        {
            var __close_whole_tree = close_whole_tree
                ? BasePart.CloseWholeTree.True
                : BasePart.CloseWholeTree.False;

            var __close_modified = close_modified
                ? BasePart.CloseModified.CloseModified
                : BasePart.CloseModified.DontCloseModified;

            part.Close(__close_whole_tree, __close_modified, null);
        }


        ///// <summary>Constructs a NXOpen.Arc from center, rotation matrix, radius, angles</summary>
        ///// <param name="center">Center point (in absolute coordinates)</param>
        ///// <param name="matrix">Orientation</param>
        ///// <param name="radius">Radius</param>
        ///// <param name="angle1">Start angle (in degrees)</param>
        ///// <param name="angle2">End angle (in degrees)</param>
        ///// <returns>A <see cref="NXOpen.Arc">NXOpen.Arc</see> object</returns>
        //public static NXOpen.Arc Arc(
        //    this NXOpen.BasePart part,
        //    NXOpen.Point3d center,
        //    NXOpen.Matrix3x3 matrix,
        //    double radius,
        //    double angle1,
        //    double angle2)
        //{
        //    NXOpen.Vector3d axisX = matrix._AxisX();
        //    NXOpen.Vector3d axisY = matrix._AxisY();
        //    return part.__CreateArc(center, axisX, axisY, radius, angle1, angle2);
        //}


        public static PointFeature __CreatePointFeature(this BasePart basePart,
            Point3d point3D)
        {
            var point = basePart.__CreatePoint(point3D);
            var builder = basePart.BaseFeatures.CreatePointFeatureBuilder(null);

            using (session_.using_builder_destroyer(builder))
            {
                builder.Point = point;
                return (PointFeature)builder.Commit();
            }
        }


        public static DatumAxis __CreateFixedDatumAxis(this BasePart part, Point3d start,
            Point3d end)
        {
            return part.Datums.CreateFixedDatumAxis(start, end);
        }


        public static ScCollector __CreateScCollector(this BasePart part,
            params SelectionIntentRule[] intentRules)
        {
            if(intentRules.Length == 0)
                throw new ArgumentException($"Cannot create {nameof(ScCollector)} from 0 {nameof(intentRules)}.",
                    nameof(intentRules));

            var collector = part.ScCollectors.CreateCollector();
            collector.ReplaceRules(intentRules, false);
            return collector;
        }

        public static Section __CreateSection(
            this BasePart part,
            SelectionIntentRule[] intentRules,
            NXObject seed,
            NXObject startConnector = null,
            NXObject endConnector = null,
            Point3d helpPoint = default,
            Section.Mode mode = Section.Mode.Create)
        {
            if(intentRules.Length == 0)
                throw new ArgumentException($"Cannot create {nameof(Section)} from 0 {nameof(intentRules)}.",
                    nameof(intentRules));

            var section = part.Sections.CreateSection();
            section.AddToSection(intentRules, seed, startConnector, endConnector, helpPoint, mode);
            return section;
        }

        public static DatumAxis __CreateFixedDatumAxis(this BasePart part, Point3d origin,
            Vector3d vector)
        {
            return part.Datums.CreateFixedDatumAxis(origin, origin._Add(vector));
        }


        /// <summary>
        ///     Created an offset face object
        /// </summary>
        /// <param name="faces">Offset faces</param>
        /// <param name="distance">Offset distace</param>
        /// <param name="direction">Offset direction</param>
        /// <returns>An NX.OffsetFace object</returns>
        internal static OffsetFace __CreateOffsetFace(this BasePart basePart,
            Face[] faces, double distance, bool direction)
        {
            basePart.__AssertIsWorkPart();
            var part = __work_part_;
            var offsetFaceBuilder = part.Features.CreateOffsetFaceBuilder(null);

            using (session_.using_builder_destroyer(offsetFaceBuilder))
            {
                offsetFaceBuilder.Distance.RightHandSide = distance.ToString();
                var array = new SelectionIntentRule[faces.Length];

                for (var i = 0; i < faces.Length; i++)
                {
                    var boundaryFaces = new Face[0];
                    array[i] = part.ScRuleFactory.CreateRuleFaceTangent(faces[i], boundaryFaces);
                }

                offsetFaceBuilder.FaceCollector.ReplaceRules(array, false);
                offsetFaceBuilder.Direction = direction;
                var offsetFace = (OffsetFace)offsetFaceBuilder.Commit();
                return offsetFace;
            }
        }

        /// <summary>Creates a line tangent to two curves</summary>
        /// <param name="icurve1">The first curve or edge</param>
        /// <param name="helpPoint1">A point near the desired tangency point on the first curve</param>
        /// <param name="icurve2">The second curve or edge</param>
        /// <param name="helpPoint2">A point near the desired tangency point on the second curve</param>
        /// <returns>A <see cref="T:Snap.NX.Line">Snap.NX.Line</see> object</returns>
        /// <remarks>
        ///     <para>
        ///         The line will start and end at the tangency points on the two curves.
        ///     </para>
        ///     <para>
        ///         The help points do not have to lie on the curves, just somewhere near the desired tangency points.
        ///     </para>
        ///     <para>
        ///         If the two given curves are not coplanar, then the second curve is projected to the plane of the first curve,
        ///         and a tangent line is constructed between the first curve and the projected one.
        ///     </para>
        /// </remarks>
        [Obsolete(nameof(NotImplementedException))]
        public static Line __CreateLineTangent(
            this BasePart basePart,
            ICurve icurve1,
            Point3d helpPoint1,
            ICurve icurve2,
            Point3d helpPoint2)
        {
            basePart.__AssertIsWorkPart();
            icurve1.__IsLinearCurve();
            icurve1.__IsPlanar();
            icurve2.__IsLinearCurve();
            icurve2.__IsPlanar();
            var value = icurve1.__Parameter(icurve1.__StartPoint());
            var plane = new Surface.Plane(icurve1.__StartPoint(), icurve1.__Binormal(value));
            helpPoint1 = helpPoint1.Project(plane);
            helpPoint2 = helpPoint2.Project(plane);
            var workPart = __work_part_;
            AssociativeLine associativeLine = null;
            var associativeLineBuilder =
                workPart.BaseFeatures.CreateAssociativeLineBuilder(associativeLine);

            using (session_.using_builder_destroyer(associativeLineBuilder))
            {
                associativeLineBuilder.StartPointOptions = AssociativeLineBuilder.StartOption.Tangent;
                associativeLineBuilder.StartTangent.SetValue(icurve1, null, helpPoint1);
                associativeLineBuilder.EndPointOptions = AssociativeLineBuilder.EndOption.Tangent;
                associativeLineBuilder.EndTangent.SetValue(icurve2, null, helpPoint2);
                associativeLineBuilder.Associative = false;
                associativeLineBuilder.Commit();
                var nXObject = associativeLineBuilder.GetCommittedObjects()[0];
                return (Line)nXObject;
            }
        }

        /// <summary>Creates a line at a given angle, tangent to a given curve</summary>
        /// <param name="icurve">A curve or edge lying in a plane parallel to the XY-plane</param>
        /// <param name="angle">An angle measured relative to the X-axis</param>
        /// <param name="helpPoint">A point near the desired tangency point</param>
        /// <returns>A <see cref="T:Snap.NX.Line">Snap.NX.Line</see> object</returns>
        /// <remarks>
        ///     <para>
        ///         The line created has "infinite" length; specifically, its length is
        ///         limited by the bounding box of the model.
        ///     </para>
        /// </remarks>
        /// <exception cref="T:System.ArgumentException">
        ///     The input curve is a line, is non-planar, or does not lie in a plane
        ///     parallel to the XY-plane
        /// </exception>
        [Obsolete(nameof(NotImplementedException))]
        public static Line __CreateLineTangent(this BasePart basePart, ICurve icurve, double angle,
            Point3d helpPoint)
        {
            //basePart.__AssertIsWorkPart();
            //icurve.__IsLinearCurve();
            //icurve.__IsPlanar();
            //NXOpen.Session.UndoMarkId markId = SetUndoMark(NXOpen.Session.MarkVisibility.Invisible, "Snap_TangentLineAngle999");
            //NXOpen.Part workPart = __work_part_;
            //NXOpen.Features.AssociativeLine associativeLine = null;
            //NXOpen.Features.AssociativeLineBuilder associativeLineBuilder = workPart.BaseFeatures.CreateAssociativeLineBuilder(associativeLine);

            //using (session_.using_builder_destroyer(associativeLineBuilder))
            //{
            //    associativeLineBuilder.StartPointOptions = NXOpen.Features.AssociativeLineBuilder.StartOption.Tangent;
            //    associativeLineBuilder.StartTangent.SetValue(icurve, null, helpPoint);
            //    associativeLineBuilder.EndPointOptions = NXOpen.Features.AssociativeLineBuilder.EndOption.AtAngle;
            //    associativeLineBuilder.EndAtAngle.Value = DatumAxis(_Point3dOrigin, _Point3dOrigin._Add(_Vector3dX())).DatumAxis;
            //    associativeLineBuilder.EndAngle.RightHandSide = angle.ToString();
            //    associativeLineBuilder.Associative = false;
            //    associativeLineBuilder.Commit();
            //    NXOpen.Line obj = (NXOpen.Line)associativeLineBuilder.GetCommittedObjects()[0];
            //    NXOpen.Point3d position = obj.StartPoint;
            //    NXOpen.Point3d position2 = obj.EndPoint;
            //    NXOpen.Point3d[] array = Compute.ClipRay(new Geom.Curve.Ray(position, position2._Subtract(position)));
            //    UndoToMark(markId, "Snap_TangentLineAngle999");
            //    DeleteUndoMark(markId, "Snap_TangentLineAngle999");
            //    return Line(array[0], array[1]);
            //}

            throw new NotImplementedException();
        }

        /// <summary>Creates an offset curve feature from given curves, direction, distance</summary>
        /// <param name="curves">Array of curves to be offset</param>
        /// <param name="distance">Offset distance</param>
        /// <param name="reverseDirection">
        ///     If true, reverse direction of offset. The default direction is the normal of<br />
        ///     the array of curves.
        /// </param>
        /// <remarks>
        ///     The resulting NX.OffsetCurve object may consist of many curves. Use the Curves<br />
        ///     property of this object to get the curves themselves.<br /><br />
        ///     This function doesn't accept a single line as input. Please us the function OffsetLine<br />
        ///     if you want to offset a single line.
        /// </remarks>
        /// <returns>A Snap.NX.OffsetCurve object</returns>
        [Obsolete(
            "Deprecated in NX8.5, please use Snap.Create.OffsetCurve(double, double, NXOpen.Point3d, NXOpen.Vector3d, params NX.ICurve[]) instead.")]
        internal static OffsetCurve __CreateOffsetCurve(this BasePart basePart,
            ICurve[] curves, double distance, bool reverseDirection)
        {
            basePart.__AssertIsWorkPart();
            var part = __work_part_;
            var offsetCurveBuilder = part.Features.CreateOffsetCurveBuilder(null);

            using (session_.using_builder_destroyer(offsetCurveBuilder))
            {
                offsetCurveBuilder.Type = OffsetCurveBuilder.Types.Distance;
                offsetCurveBuilder.InputCurvesOptions.InputCurveOption =
                    CurveOptions.InputCurve.Retain;
                offsetCurveBuilder.CurveFitData.Tolerance = DistanceTolerance;
                offsetCurveBuilder.TrimMethod = OffsetCurveBuilder.TrimOption.ExtendTangents;
                offsetCurveBuilder.CurvesToOffset.DistanceTolerance = DistanceTolerance;
                offsetCurveBuilder.CurvesToOffset.AngleTolerance = AngleTolerance;
                offsetCurveBuilder.CurvesToOffset.ChainingTolerance = ChainingTolerance;
                offsetCurveBuilder.CurvesToOffset.SetAllowedEntityTypes(Section.AllowTypes.OnlyCurves);
                offsetCurveBuilder.CurvesToOffset.AllowSelfIntersection(true);
                offsetCurveBuilder.OffsetDistance.RightHandSide = distance.ToString();
                offsetCurveBuilder.ReverseDirection = reverseDirection;
                var section = offsetCurveBuilder.CurvesToOffset;

                for (var i = 0; i < curves.Length; i++)
                    section.AddICurve(curves);

                var feature = offsetCurveBuilder.CommitFeature();
                return feature as OffsetCurve;
            }
        }

        /// <summary>Creates an offset curve feature from given curves, direction, distance</summary>
        /// <param name="icurves">Array of curves to be offset</param>
        /// <param name="height">Draft height</param>
        /// <param name="angle">Draft angle</param>
        /// <param name="reverseDirection">
        ///     If true, reverse direction of offset.<br />
        ///     The default direction is close to the normal of the array of curves.
        /// </param>
        /// <remarks>
        ///     The resulting NX.OffsetCurve object may consist of many curves. Use the Curves<br />
        ///     property of this object to get the curves themselves.<br /><br />
        ///     This function doesn't accept a single line as input. Please us the function OffsetLine<br />
        ///     if you want to offset a single line.
        /// </remarks>
        /// <returns>A Snap.NX.OffsetCurve object</returns>
        internal static OffsetCurve __CreateOffsetCurve(
            this BasePart basePart,
            ICurve[] icurves,
            double height,
            double angle,
            bool reverseDirection)
        {
            basePart.__AssertIsWorkPart();
            var part = __work_part_;
            var offsetCurveBuilder = part.Features.CreateOffsetCurveBuilder(null);

            using (session_.using_builder_destroyer(offsetCurveBuilder))
            {
                offsetCurveBuilder.Type = OffsetCurveBuilder.Types.Draft;
                offsetCurveBuilder.InputCurvesOptions.InputCurveOption =
                    CurveOptions.InputCurve.Retain;
                offsetCurveBuilder.CurveFitData.Tolerance = DistanceTolerance;
                offsetCurveBuilder.DraftHeight.RightHandSide = height.ToString();
                offsetCurveBuilder.DraftAngle.RightHandSide = angle.ToString();
                offsetCurveBuilder.ReverseDirection = reverseDirection;
                var section = offsetCurveBuilder.CurvesToOffset;

                for (var i = 0; i < icurves.Length; i++)
                    section.AddICurve(icurves);

                var feature = offsetCurveBuilder.CommitFeature();
                offsetCurveBuilder.CurvesToOffset.CleanMappingData();
                return feature as OffsetCurve;
            }
        }

        /// <summary>
        ///     Creates an offset curve feature from given curves, direction, distance
        /// </summary>
        /// <remarks>
        ///     This function doesn't accept an array consisting of a single line as input.
        ///     The resulting NX.OffsetCurve object may consist of many curves. Use the Curves
        ///     property of this object to get the curves themselves.
        ///     Offsets of lines and arcs will again be lines and arcs, respectively. Offsets
        ///     of splines and ellipses will be splines that approximate the exact offsets to
        ///     with DistanceTolerance.
        /// </remarks>
        /// <param name="curves">Array of base curves to be offset</param>
        /// <param name="distance">Offset distance</param>
        /// <param name="helpPoint">A help point on the base curves</param>
        /// <param name="helpVector">The offset direction (roughly) at the help point</param>
        /// <returns>A Snap.NX.OffsetCurve object</returns>
        internal static OffsetCurve __CreateOffsetCurve(
            this BasePart basePart,
            ICurve[] curves,
            double distance,
            Point3d helpPoint,
            Vector3d helpVector)
        {
            basePart.__AssertIsWorkPart();
            var part = __work_part_;
            var offsetCurveBuilder = part.Features.CreateOffsetCurveBuilder(null);

            using (session_.using_builder_destroyer(offsetCurveBuilder))
            {
                offsetCurveBuilder.Type = OffsetCurveBuilder.Types.Distance;
                offsetCurveBuilder.InputCurvesOptions.InputCurveOption =
                    CurveOptions.InputCurve.Retain;
                offsetCurveBuilder.CurveFitData.Tolerance = DistanceTolerance;
                offsetCurveBuilder.CurveFitData.AngleTolerance = AngleTolerance;
                offsetCurveBuilder.CurvesToOffset.SetAllowedEntityTypes(Section.AllowTypes.OnlyCurves);
                offsetCurveBuilder.CurvesToOffset.AllowSelfIntersection(true);
                offsetCurveBuilder.OffsetDistance.RightHandSide = distance.ToString();
                var section = offsetCurveBuilder.CurvesToOffset;
                section.AddICurve(curves);
#pragma warning disable CS0618 // Type or member is obsolete
                offsetCurveBuilder.ReverseDirection =
                    IsReverseDirection(offsetCurveBuilder, curves, helpPoint, helpVector);
#pragma warning restore CS0618 // Type or member is obsolete
                var feature = offsetCurveBuilder.CommitFeature();
                return feature as OffsetCurve;
            }
        }

        /// <summary>
        ///     Creates an offset curve feature from given curves, direction, distance
        /// </summary>
        /// <remarks>
        ///     The resulting NX.OffsetCurve object may consist of many curves. Use the Curves<br />
        ///     property of this object to get the curves themselves.<br /><br />
        ///     Offsets of lines and arcs will again be lines and arcs, respectively. Offsets
        ///     of splines and ellipses will be splines that approximate the exact offsets to
        ///     with DistanceTolerance.<br /><br />
        ///     This function doesn't accept an array consisting of a single line as input.
        ///     <remarks />
        ///     <param name="curves">Array of curves to be offset</param>
        ///     <param name="height">Draft height</param>
        ///     <param name="angle">Draft angle</param>
        ///     <param name="helpPoint">A help point on the base curves</param>
        ///     <param name="helpVector">The offset direction (roughly) at the help point</param>
        ///     <returns>A Snap.NX.OffsetCurve object</returns>
        internal static OffsetCurve __CreateOffsetCurve(
            this BasePart basePart,
            ICurve[] curves,
            double height,
            double angle,
            Point3d helpPoint,
            Vector3d helpVector)
        {
            basePart.__AssertIsWorkPart();
            var part = __work_part_;
            var offsetCurveBuilder = part.Features.CreateOffsetCurveBuilder(null);

            using (session_.using_builder_destroyer(offsetCurveBuilder))
            {
                offsetCurveBuilder.Type = OffsetCurveBuilder.Types.Draft;
                offsetCurveBuilder.InputCurvesOptions.InputCurveOption =
                    CurveOptions.InputCurve.Retain;
                offsetCurveBuilder.CurveFitData.Tolerance = DistanceTolerance;
                offsetCurveBuilder.DraftHeight.RightHandSide = height.ToString();
                offsetCurveBuilder.DraftAngle.RightHandSide = angle.ToString();
                var section = offsetCurveBuilder.CurvesToOffset;
                section.AddICurve(curves);
#pragma warning disable CS0618 // Type or member is obsolete
                offsetCurveBuilder.ReverseDirection =
                    IsReverseDirection(offsetCurveBuilder, curves, helpPoint, helpVector);
#pragma warning restore CS0618 // Type or member is obsolete
                var feature = offsetCurveBuilder.CommitFeature();
                offsetCurveBuilder.CurvesToOffset.CleanMappingData();
                return feature as OffsetCurve;
            }
        }


        /// <summary>
        ///     Creates an offset curve feature from given curve, direction, distance
        /// </summary>
        /// <param name="icurve">Array of curves to be offset</param>
        /// <param name="point">Point on offset plane</param>
        /// <param name="distance">Offset Distance</param>
        /// <param name="reverseDirection">
        ///     If true, reverse direction of offset. The default direction is the normal of<br />
        ///     the array of curves.
        /// </param>
        /// <remarks>
        ///     The resulting NX.OffsetCurve object may consist of many curves. Use the Curves<br />
        ///     property of this object to get the curves themselves.<br /><br />
        ///     This function only accept a single line as input. Please us the function Offset<br />
        ///     if you want to offset a non-linear curve.
        /// </remarks>
        /// <returns>A Snap.NX.OffsetCurve object</returns>
        internal static OffsetCurve __CreateOffsetLine(
            this BasePart basePart,
            ICurve icurve,
            Point point,
            string distance,
            bool reverseDirection)
        {
            basePart.__AssertIsWorkPart();
            var part = __work_part_;
            var offsetCurveBuilder = part.Features.CreateOffsetCurveBuilder(null);

            using (session_.using_builder_destroyer(offsetCurveBuilder))
            {
                offsetCurveBuilder.Type = OffsetCurveBuilder.Types.Distance;
                offsetCurveBuilder.InputCurvesOptions.InputCurveOption =
                    CurveOptions.InputCurve.Retain;
                offsetCurveBuilder.CurveFitData.Tolerance = DistanceTolerance;
                offsetCurveBuilder.OffsetDistance.RightHandSide = distance;
                offsetCurveBuilder.ReverseDirection = reverseDirection;
                offsetCurveBuilder.PointOnOffsetPlane = point;
                var section = offsetCurveBuilder.CurvesToOffset;
                section.AddICurve(icurve);
                var feature = offsetCurveBuilder.CommitFeature();
                offsetCurveBuilder.CurvesToOffset.CleanMappingData();
                return feature as OffsetCurve;
            }
        }


        /// <summary>Creates a fillets with two given curves</summary>
        /// <param name="curve1">First curve for the fillet</param>
        /// <param name="curve2">Second curve for the fillet</param>
        /// <param name="radius">Radius of the fillet</param>
        /// <param name="center">Approximate fillet center expressed as absolute coordinates</param>
        /// <param name="doTrim">If true, indicates that the input curves should get trimmed by the fillet</param>
        /// <returns>An NX.Arc object</returns>
        internal static Arc __CreateArcFillet(
            this BasePart basePart,
            Curve curve1,
            Curve curve2,
            double radius,
            Point3d center,
            bool doTrim)
        {
            basePart.__AssertIsWorkPart();
            var curve_objs = new Tag[2] { curve1.Tag, curve2.Tag };
            var array = center._ToArray();
            var array2 = new int[3];
            var arc_opts = new int[3];
            if(doTrim)
            {
                array2[0] = 1;
                array2[1] = 1;
            }
            else
            {
                array2[0] = 0;
                array2[1] = 0;
            }

            ufsession_.Curve.CreateFillet(0, curve_objs, array, radius, array2, arc_opts, out var fillet_obj);
            return (Arc)session_._GetTaggedObject(fillet_obj);
        }

        public static void __AssertIsWorkPart(this BasePart basePart)
        {
            if(__work_part_.Tag != basePart.Tag)
                throw new AssertWorkPartException(basePart);
        }


        /// <summary>Creates a Snap.NX.TrimBody feature</summary>
        /// <param name="targetBody">The target body will be trimmed</param>
        /// <param name="toolBody">The sheet body used to trim target body</param>
        /// <param name="direction">The default direction is the normal of the sheet body.</param>
        /// <returns>A Snap.NX.TrimBody feature</returns>
        internal static TrimBody2 __CreateTrimBody(this BasePart basePart,
            Body targetBody, Body toolBody, bool direction)
        {
            var part = __work_part_;
            var trimBody2Builder = part.Features.CreateTrimBody2Builder(null);

            using (session_.using_builder_destroyer(trimBody2Builder))
            {
                trimBody2Builder.Tolerance = DistanceTolerance;
                trimBody2Builder.BooleanTool.ExtrudeRevolveTool.ToolSection.DistanceTolerance = DistanceTolerance;
                trimBody2Builder.BooleanTool.ExtrudeRevolveTool.ToolSection.ChainingTolerance = ChainingTolerance;
                var scCollector = part.ScCollectors.CreateCollector();
                var bodies = new Body[1] { targetBody };
                var bodyDumbRule = part.ScRuleFactory.CreateRuleBodyDumb(bodies);
                var rules = new SelectionIntentRule[1] { bodyDumbRule };
                scCollector.ReplaceRules(rules, false);
                trimBody2Builder.TargetBodyCollector = scCollector;
                var rules2 = new SelectionIntentRule[1]
                    { part.ScRuleFactory.CreateRuleFaceBody(toolBody) };
                trimBody2Builder.BooleanTool.FacePlaneTool.ToolFaces.FaceCollector.ReplaceRules(rules2,
                    false);
                trimBody2Builder.BooleanTool.ReverseDirection = direction;
                return (TrimBody2)trimBody2Builder.Commit();
            }
        }

        /// <summary>Creates a Snap.NX.TrimBody feature</summary>
        /// <param name="targetBody">The target body will be trimmed</param>
        /// <param name="toolDatumPlane">The datum plane used to trim target body</param>
        /// <param name="direction">Trim direction. The default direction is the normal of the datum plane.</param>
        /// <returns>A Snap.NX.TrimBody feature</returns>
        internal static TrimBody2 __CreateTrimBody(this BasePart basePart,
            Body targetBody, DatumPlane toolDatumPlane, bool direction)
        {
            var part = __work_part_;
            var trimBody2Builder = part.Features.CreateTrimBody2Builder(null);

            using (session_.using_builder_destroyer(trimBody2Builder))
            {
                trimBody2Builder.Tolerance = DistanceTolerance;
                trimBody2Builder.BooleanTool.ExtrudeRevolveTool.ToolSection.DistanceTolerance = DistanceTolerance;
                trimBody2Builder.BooleanTool.ExtrudeRevolveTool.ToolSection.ChainingTolerance = ChainingTolerance;
                var scCollector = part.ScCollectors.CreateCollector();
                var bodies = new Body[1] { targetBody };
                var bodyDumbRule = part.ScRuleFactory.CreateRuleBodyDumb(bodies);
                var rules = new SelectionIntentRule[1] { bodyDumbRule };
                scCollector.ReplaceRules(rules, false);
                trimBody2Builder.TargetBodyCollector = scCollector;
                var array = new SelectionIntentRule[1];
                var faces = new DatumPlane[1] { toolDatumPlane };
                array[0] = part.ScRuleFactory.CreateRuleFaceDatum(faces);
                trimBody2Builder.BooleanTool.FacePlaneTool.ToolFaces.FaceCollector.ReplaceRules(array,
                    false);
                trimBody2Builder.BooleanTool.ReverseDirection = direction;
                var feature = trimBody2Builder.CommitFeature();
                return (TrimBody2)feature;
            }
        }


        /// <summary>Creates a "widget" body for examples and testing</summary>
        /// <returns>An NX.Body</returns>
        /// <remarks>
        ///     <para>
        ///         The widget object is shown in the pictures below.
        ///     </para>
        ///     <para>
        ///         <img src="../Images/widget.png" />
        ///     </para>
        ///     <para>
        ///         This object is useful for examples and testing because it has many different
        ///         types of faces and edges. The faces are named, for easy reference in example
        ///         code, as outlined below.
        ///     </para>
        ///     <para>
        ///         <list type="table">
        ///             <listheader>
        ///                 <term>Face Name</term>
        ///                 <description>Face Description</description>
        ///             </listheader>
        ///             <item>
        ///                 <term>CYAN_REVOLVED</term><description>Revolved face on left end</description>
        ///             </item>
        ///             <item>
        ///                 <term>MAGENTA_TORUS_BLEND</term><description>Toroidal face with minor radius = 10</description>
        ///             </item>
        ///             <item>
        ///                 <term>TEAL_CONE</term><description>Large conical face</description>
        ///             </item>
        ///             <item>
        ///                 <term>YELLOW_SPHERE</term><description>Spherical face with diameter = 15</description>
        ///             </item>
        ///             <item>
        ///                 <term>PINK_CYLINDER_HOLE</term><description>Cylindrical hole with diameter = 20</description>
        ///             </item>
        ///             <item>
        ///                 <term>RED_BSURFACE_BLEND</term>
        ///                 <description>B-surface representing a variable radius blend</description>
        ///             </item>
        ///             <item>
        ///                 <term>BLUE_CYLINDER_VERTICAL</term>
        ///                 <description>Vertical cylindrical face with diameter = 30</description>
        ///             </item>
        ///             <item>
        ///                 <term>TAN_PLANE_TOP</term><description>Planar face on top</description>
        ///             </item>
        ///             <item>
        ///                 <term>ORANGE_BLEND</term><description>Blend face with radius = 7</description>
        ///             </item>
        ///             <item>
        ///                 <term>GREEN_EXTRUDED</term><description>Extruded face on right-hand end</description>
        ///             </item>
        ///             <item>
        ///                 <term>GREY_PLANE_BACK</term><description>Large planar face on back</description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </remarks>
        [Obsolete(nameof(NotImplementedException))]
        public static Body __Widget()
        {
            //NXOpen.Point3d origin = _Point3dOrigin;
            //NXOpen.Vector3d axisX = Extensions._Vector3dX();
            //NXOpen.Vector3d axisY = Extensions._Vector3dY();
            //NXOpen.Vector3d axisZ = Extensions._Vector3dZ();
            //double num = 48.0;
            //double num2 = 40.0;
            //double num3 = 30.0;
            //double[] diameters = new double[2] { num, num2 };
            //double num4 = 80.0;
            //double num5 = 2.0 * num3;
            //NXOpen.Body body = Cone(origin, axisY, diameters, 90).GetBodies()[0];
            //NXOpen.Body body2 = Cylinder(new NXOpen.Point3d(0.0, num4 / 2.0, 0.0), axisZ, num5, num3).GetBodies()[0];
            //NXOpen.Line line = Line(0.0 - num, 0.0, 0.9 * num, 0.0 - num, num4, 0.7 * num);
            //NXOpen.Body body3 = ExtrudeSheet(new NXOpen.ICurve[1] { line }, axisX, 200);
            //NXOpen.Line line2 = Line(0.0, -10.0, -2.0 * num, 0.0, num4 + 10.0, -2.0 * num);
            //NXOpen.Body body4 = ExtrudeSheet(new NXOpen.ICurve[1] { line2 }, axisZ, 200);
            //TrimBody(body2, body3, direction: true);
            //NXOpen.Body body5 = TrimBody(body2, body4, direction: false).GetBodies()[0];
            //NXOpen.Body body6 = Unite(TrimBody(body, body4, direction: false), body5);
            //NXOpen.Edge[] edges = body6.Edges;
            //foreach (NXOpen.Edge edge in edges)
            //{
            //    double[] arclengthPercents = new double[2] { 0.0, 100.0 };
            //    double[] radii = new double[2] { 9.0, 4.0 };
            //    bool flag = edge.SolidEdgeType == NXOpen.Edge.EdgeType.Intersection;
            //    bool flag2 = edge.Vertices.Length > 1;
            //    if (flag && flag2)
            //    {
            //        VarBlend(edge, arclengthPercents, radii);
            //    }
            //}

            //NXOpen.Point3d position = new NXOpen.Point3d(0.0, 0.0, num / 2.0);
            //NXOpen.Point3d position2 = new NXOpen.Point3d(0.0, 5.0, 0.0);
            //NXOpen.Point3d position3 = new NXOpen.Point3d(0.0, 0.0, (0.0 - num) / 2.0);
            //NXOpen.Spline spline = BezierCurve(position, position2, position3);
            //NXOpen.Body body7 = ExtrudeSheet(new NXOpen.ICurve[1] { spline }, -axisX, num).Body;
            //NXOpen.Body targetBody = TrimBody(body6, body7, direction: true);
            //position = new NXOpen.Point3d(0.0, num4 + 10.0, 0.0);
            //position2 = new NXOpen.Point3d(0.0, num4, 20.0);
            //position3 = new NXOpen.Point3d(0.0, num4 - 15.0, 25.0);
            //NXOpen.Spline spline2 = BezierCurve(position, position2, position3);
            //NXOpen.Body body8 = RevolveSheet(new NXOpen.ICurve[1] { spline2 }, _Point3dOrigin, Extensions._AxisY());
            //NXOpen.Body body9 = TrimBody(targetBody, body8, direction: true);
            //NXOpen.Edge edge2 = null;
            //NXOpen.Edge edge3 = null;
            //edges = body9.Edges;
            //foreach (NXOpen.Edge edge4 in edges)
            //{
            //    bool num6 = edge4.SolidEdgeType == NXOpen.Edge.EdgeType.Circular;
            //    bool flag3 = edge4.ArcLength > 1.2 * num2;
            //    if (num6 && flag3)
            //    {
            //        edge2 = edge4;
            //    }

            //    if (edge4.ObjectSubType == ObjectTypes.SubType.EdgeIntersection)
            //    {
            //        edge3 = edge4;
            //    }
            //}

            //EdgeBlend(10, edge2);
            //EdgeBlend(7, edge3);
            //NXOpen.Body body10 = Cylinder(new NXOpen.Point3d(0.0 - num, 0.3 * num4, 0.0), axisX, 200, 20).Body;
            //NXOpen.Body body11 = Subtract(body9, body10).Body;
            //NXOpen.Body body12 = Sphere(new NXOpen.Point3d((0.0 - num2) / 2.0, 0.7 * num4, 0.0), 15).Body;
            //Snap.NX.Feature feature = Unite(body11, body12);
            //NXOpen.Body body13 = feature.Body;
            //Snap.NX.Feature.Orphan(feature);
            //Snap.NX.NXObject.Delete(body7, body4, body3, body8);
            //Snap.NX.NXObject.Delete(line2, line, spline, spline2);
            //body13.Color = System.Drawing.Color.Black;
            //NXOpen.Face[] faces = body13.Faces;
            //foreach (NXOpen.Face face in faces)
            //{
            //    if (face.SolidFaceType == Face.FaceType.Planar)
            //    {
            //        face.Color = System.Drawing.Color.Tan;
            //        face.Name = "TAN_PLANE_TOP";
            //        if (System.Math.Abs(face.Normal(0.5, 0.5).X) > 0.9)
            //        {
            //            face.Color = System.Drawing.Color.Gray;
            //            face.Name = "GREY_PLANE_BACK";
            //        }
            //    }

            //    if (face.ObjectSubType == ObjectTypes.SubType.FaceCylinder)
            //    {
            //        face.Color = System.Drawing.Color.Blue;
            //        face.Name = "BLUE_CYLINDER_VERTICAL";
            //        if (face.Edges.Length == 2)
            //        {
            //            face.Color = System.Drawing.Color.Salmon;
            //            face.Name = "PINK_CYLINDER_HOLE";
            //        }
            //    }

            //    if (face.ObjectSubType == ObjectTypes.SubType.FaceCone)
            //    {
            //        face.Color = System.Drawing.Color.Teal;
            //        face.Name = "TEAL_CONE";
            //    }

            //    if (face.ObjectSubType == ObjectTypes.SubType.FaceBsurface)
            //    {
            //        face.Color = System.Drawing.Color.Red;
            //        face.Name = "RED_BSURFACE_BLEND";
            //    }

            //    if (face.ObjectSubType == ObjectTypes.SubType.FaceTorus)
            //    {
            //        face.Color = System.Drawing.Color.Magenta;
            //        face.Name = "MAGENTA_TORUS_BLEND";
            //    }

            //    if (face.ObjectSubType == ObjectTypes.SubType.FaceBlend)
            //    {
            //        face.Color = System.Drawing.Color.Orange;
            //        face.Name = "ORANGE_BLEND";
            //    }

            //    if (face.ObjectSubType == ObjectTypes.SubType.FaceExtruded)
            //    {
            //        face.Color = System.Drawing.Color.Green;
            //        face.Name = "GREEN_EXTRUDED";
            //    }

            //    if (face.ObjectSubType == ObjectTypes.SubType.FaceSphere)
            //    {
            //        face.Color = System.Drawing.Color.Yellow;
            //        face.Name = "YELLOW_SPHERE";
            //    }

            //    if (face.ObjectSubType == ObjectTypes.SubType.FaceRevolved)
            //    {
            //        face.Color = System.Drawing.Color.Cyan;
            //        face.Name = "CYAN_REVOLVED";
            //    }
            //}

            //return body13;
            throw new NotImplementedException();
        }

        /// <summary>Creates a BoundedPlane object</summary>
        /// <param name="boundingCurves">Array of curves forming the boundary</param>
        /// <returns> A <see cref="T:Snap.NX.BoundedPlane">Snap.NX.BoundedPlane</see> object</returns>
        /// <remarks>
        ///     <para>
        ///         The boundary curves are input in a single list, which can include both periphery curves
        ///         and curves bounding holes. The order of the curves in the array does not matter.
        ///     </para>
        /// </remarks>
        internal static BoundedPlane __CreateBoundedPlane(this BasePart basePart,
            params Curve[] boundingCurves)
        {
            basePart.__AssertIsWorkPart();

            if(boundingCurves.Length == 0)
                throw new ArgumentOutOfRangeException();

            var part = __work_part_;
            var boundedPlaneBuilder = part.Features.CreateBoundedPlaneBuilder(null);

            using (boundedPlaneBuilder._using_builder())
            {
                boundedPlaneBuilder.BoundingCurves.SetAllowedEntityTypes(Section.AllowTypes.OnlyCurves);
                boundedPlaneBuilder.BoundingCurves.AllowSelfIntersection(false);
                var section = boundedPlaneBuilder.BoundingCurves;
                section.AddICurve(boundingCurves);
                return (BoundedPlane)boundedPlaneBuilder.Commit();
            }
        }


        /// <summary>Unites an array of tool bodies with a target body</summary>
        /// <param name="targetBody">Target body</param>
        /// <param name="toolBodies">Array of tool bodies</param>
        /// <returns><see cref="T:Snap.NX.Boolean">Snap.NX.Boolean</see> feature formed by uniting tools with target</returns>
        public static BooleanFeature __CreateUnite(this BasePart basePart,
            Body targetBody, params Body[] toolBodies)
        {
            return basePart.__CreateBoolean(targetBody, toolBodies, Feature.BooleanType.Unite);
        }

        /// <summary>Subtracts an array of tool bodies from a target body</summary>
        /// <param name="targetBody">Target body</param>
        /// <param name="toolBodies">Array of tool bodies</param>
        /// <returns><see cref="T:Snap.NX.Boolean">Snap.NX.Boolean</see> feature formed by subtracting tools from target</returns>
        public static BooleanFeature __CreateSubtract(this BasePart basePart,
            Body targetBody, params Body[] toolBodies)
        {
            return basePart.__CreateBoolean(targetBody, toolBodies, Feature.BooleanType.Subtract);
        }

        /// <summary>Intersects an array of tool bodies with a target body</summary>
        /// <param name="targetBody">Target body</param>
        /// <param name="toolBodies">Array of tool bodies</param>
        /// <returns><see cref="T:Snap.NX.Boolean">Snap.NX.Boolean</see> feature formed by intersecting tools with target</returns>
        public static BooleanFeature __CreateIntersect(this BasePart basePart,
            Body targetBody, params Body[] toolBodies)
        {
            return basePart.__CreateBoolean(targetBody, toolBodies, Feature.BooleanType.Intersect);
        }


        public static void __SetAsDisplayPart(this BasePart part)
        {
            __display_part_ = (Part)part;
        }

        public static bool __HasReferenceSet(this BasePart part, string referenceSet)
        {
            return part.GetAllReferenceSets().SingleOrDefault(set => set.Name == referenceSet) != null;
        }

        public static ReferenceSet __FindReferenceSetOrNull(this BasePart nxPart, string refsetTitle)
        {
            return nxPart.GetAllReferenceSets().SingleOrDefault(set => set.Name == refsetTitle);
        }

        public static ReferenceSet __FindReferenceSet(this BasePart nxPart, string refsetTitle)
        {
            return nxPart.__FindReferenceSetOrNull(refsetTitle)
                   ??
                   throw new Exception(
                       $"Could not find reference set with title \"{refsetTitle}\" in part \"{nxPart.Leaf}\".");
        }


        public static Block __DynamicBlockOrNull(this BasePart nxPart)
        {
            return nxPart.Features
                .OfType<Block>()
                .SingleOrDefault(block => block.Name == "DYNAMIC BLOCK");
        }

        public static Block __DynamicBlock(this BasePart nxPart)
        {
            return nxPart.__DynamicBlockOrNull()
                   ??
                   throw new Exception("Could not find ");
        }

        public static bool __HasDynamicBlock(this BasePart part)
        {
            return part.__DynamicBlockOrNull() != null;
        }

        public static bool __Is999(this BasePart part)
        {
            var match = Regex.Match(part.Leaf, Regex_Detail);
            //GFolderWithCtsNumber.DetailPart.DetailExclusiveRegex.Match(nxPart.Leaf);
            if(!match.Success) return false;
            var detailNumber = int.Parse(match.Groups[3].Value);
            return detailNumber >= 990 && detailNumber <= 1000;
        }


        public static bool __IsJckScrew(this BasePart part)
        {
            return part.Leaf.ToLower().EndsWith("-jck-screw");
        }

        public static bool __IsJckScrewTsg(this BasePart part)
        {
            return part.Leaf.ToLower().EndsWith("-jck-screw-tsg");
        }

        public static bool __IsShcs(this BasePart part)
        {
            return part.Leaf.ToLower().Contains("-shcs-");
        }

        public static bool __IsFastener(this BasePart part)
        {
            return part.__IsDwl() || part.__IsJckScrew() || part.__IsJckScrewTsg() || part.__IsShcs();
        }

        public static bool __IsDwl(this BasePart part)
        {
            return part.Leaf.ToLower().Contains("-dwl-");
        }

        public static void __SetStringAttribute(this BasePart part, string title, string value)
        {
            part.SetUserAttribute(title, -1, value, Update.Option.Now);
        }

        //public static NXOpen.Assemblies.Component __RootComponent(this NXOpen.BasePart part)
        //{
        //    return part.ComponentAssembly.RootComponent;
        //}

        //public static bool __HasDynamicBlock(this NXOpen.BasePart part)
        //{
        //    return part.Features
        //                .ToArray()
        //                .OfType<NXOpen.Features.Block>()
        //                .Any(__b => __b.Name == "DYNAMIC BLOCK");
        //}

        /// <summary>
        ///     Returns all objects in a given part on all layers regardless of their
        ///     current status or displayability.This includes temporary (system created) objects.
        ///     It does not return expressions.
        ///     This function returns the tag of the object that was found. To continue
        ///     cycling, pass the returned object in as the second argument to this
        ///     function.
        ///     NOTE: You are strongly advised to avoid doing anything to non-alive
        ///     objects unless you are familiar with their use.NX may delete or reuse
        ///     these objects at any time. Some of these objects do not get filed with
        ///     the part.
        ///     NOTE: This routine is invalid for partially loaded parts.If you call this
        ///     function using a partially loaded part, it returns a NULL_TAG from
        ///     the beginning of the cycle.
        ///     Do not attempt to delete objects when cycling the database in a loop. Problems
        ///     can occur when trying to read the next object when the current object has been
        ///     deleted. To delete objects, save an array with the objects in it, and then
        ///     when you have completed cycling, use UF_OBJ_delete_array_of_objects to delete
        ///     the saved array of objects.
        /// </summary>
        /// <param name="part"></param>
        /// <param name="_object"></param>
        /// <returns></returns>
        [Obsolete(nameof(NotImplementedException))]
        public static TaggedObject[] __CycleAll(this BasePart part)
        {
            //var objects = new List<NXOpen.TaggedObject>();

            //ufsession_.Obj.CycleAll

            throw new NotImplementedException();
        }

        public static BodyDumbRule __CreateRuleBodyDumb(this BasePart part, params Body[] bodies)
        {
            if(bodies.Length == 0)
                throw new ArgumentException($"Cannot create rule from 0 {nameof(bodies)}.", nameof(bodies));

            return part.ScRuleFactory.CreateRuleBodyDumb(bodies);
        }

        public static CurveDumbRule __CreateRuleCurveDumb(this BasePart part,
            params Curve[] curves)
        {
            if(curves.Length == 0)
                throw new ArgumentException($"Cannot create rule from 0 {nameof(curves)}.", nameof(curves));

            return part.ScRuleFactory.CreateRuleCurveDumb(curves);
        }

        public static EdgeDumbRule __CreateRuleEdgeDumb(this BasePart part, params Edge[] edges)
        {
            if(edges.Length == 0)
                throw new ArgumentException($"Cannot create rule from 0 {nameof(edges)}.", nameof(edges));

            return part.ScRuleFactory.CreateRuleEdgeDumb(edges);
        }

        public static FaceDumbRule __CreateRuleFaceDumb(this BasePart part, params Face[] faces)
        {
            if(faces.Length == 0)
                throw new ArgumentException($"Cannot create rule from 0 {nameof(faces)}.", nameof(faces));

            return part.ScRuleFactory.CreateRuleFaceDumb(faces);
        }

        public static EdgeFeatureRule __CreateRuleEdgeFeature(this BasePart part,
            params Feature[] features)
        {
            if(features.Length == 0)
                throw new ArgumentException($"Cannot create rule from 0 {nameof(features)}.", nameof(features));

            return part.ScRuleFactory.CreateRuleEdgeFeature(features);
        }

        public static FaceFeatureRule __CreateRuleFaceFeature(this BasePart part,
            params Feature[] features)
        {
            if(features.Length == 0)
                throw new ArgumentException($"Cannot create rule from 0 {nameof(features)}.", nameof(features));

            return part.ScRuleFactory.CreateRuleFaceFeature(features);
        }

        public static CurveFeatureRule __CreateRuleCurveFeature(this BasePart part,
            params Feature[] features)
        {
            if(features.Length == 0)
                throw new ArgumentException($"Cannot create rule from 0 {nameof(features)}.", nameof(features));

            return part.ScRuleFactory.CreateRuleCurveFeature(features);
        }

        public static CurveFeatureChainRule __CreateRuleCurveFeatureChain(
            this BasePart part,
            Feature[] features,
            Curve startCurve,
            Curve endCurve = null,
            bool isFromSeedStart = true,
            double gapTolerance = 0.001)
        {
            if(features.Length == 0)
                throw new ArgumentException($"Cannot create rule from 0 {nameof(features)}.", nameof(features));

            return part.ScRuleFactory.CreateRuleCurveFeatureChain(features, startCurve, endCurve, isFromSeedStart,
                gapTolerance);
        }


        /// <summary>Constructs a circle from center, rotation matrix, radius</summary>
        /// <param name="center">Center point (in absolute coordinates)</param>
        /// <param name="matrix">Orientation matrix</param>
        /// <param name="radius">Radius</param>
        /// <returns>A <see cref="Arc_">Arc_</see> object</returns>
        [Obsolete]
        public static Arc __CreateCircle(this BasePart part, Point3d center,
            Matrix3x3 matrix, double radius)
        {
            //return part.__CreateArc(part, center, matrix._AxisX(), matrix._AxisY(), radius, 0.0, 360.0);
            throw new NotImplementedException();
        }

        /// <summary>Creates an NX.Arc from center, axes, radius, angles in degrees</summary>
        /// <param name="center">Center point (in absolute coordinates)</param>
        /// <param name="axisX">Unit NXOpen.Vector3d along X-axis (where angle = 0)</param>
        /// <param name="axisY">Unit NXOpen.Vector3d along Y-axis (where angle = 90)</param>
        /// <param name="radius">Radius</param>
        /// <param name="angle1">Start angle (in degrees)</param>
        /// <param name="angle2">End angle (in degrees)</param>
        /// <returns>An NX.Arc object</returns>
        public static Arc __CreateArc(
            this BasePart basePart,
            Point3d center,
            Vector3d axisX,
            Vector3d axisY,
            double radius,
            double angle1,
            double angle2)
        {
            basePart.__AssertIsWorkPart();
            var radians1 = DegreesToRadians(angle1);
            var radians2 = DegreesToRadians(angle2);
            var ori = axisX._ToMatrix3x3(axisY);
            var matrix = basePart.NXMatrices.Create(ori);
            return basePart.Curves.CreateArc(center, matrix, radius, radians1, radians2);
        }

        //public static NXOpen.Features.BooleanFeature __CreateSubtract(this NXOpen.BasePart part, NXOpen.Body target, params NXOpen.Body[] tools)
        //{
        //    NXOpen.Features.BooleanBuilder booleanBuilder = part.Features.CreateBooleanBuilder(null);

        //    using (session_.using_builder_destroyer(booleanBuilder))
        //    {
        //        booleanBuilder.Operation = NXOpen.Features.Feature.BooleanType.Subtract;
        //        booleanBuilder.Target = target;
        //        booleanBuilder.ToolBodyCollector = part.ScCollectors.CreateCollector();
        //        NXOpen.SelectionIntentRule[] rules = new[] { part.ScRuleFactory.CreateRuleBodyDumb(tools) };
        //        booleanBuilder.ToolBodyCollector.ReplaceRules(rules, false);
        //        return (NXOpen.Features.BooleanFeature)booleanBuilder.Commit();
        //    }
        //}


        public static void __CreateInterpartExpression(
            this BasePart part,
            Expression source_expression,
            string destination_name)
        {
            if(part.Tag != __display_part_.Tag)
                throw new Exception("Part must be displayed part to create interpart expressions");

            var
                builder = __display_part_.Expressions.CreateInterpartExpressionsBuilder();

            using (new Destroyer(builder))
            {
                builder.SetExpressions(new[] { source_expression }, new[] { destination_name });
                builder.Commit();
            }
        }


        //public static NXOpen.Positioning.ComponentConstraint constrain_occ_proto_distance_abs_csys(
        //    this NXOpen.BasePart part,
        //    NXOpen.Assemblies.Component component,
        //    string exp_xy,
        //    string exp_xz,
        //    string exp_yz)
        //{
        //    if (__work_part_.Tag != __display_part_.Tag)
        //        throw new Exception("Display part must be Work part");

        //    if (!__occ_plane.IsOccurrence)
        //        throw new Exception("Occurrence plane for constraint was actually a prototype.");

        //    if (__proto_plane.IsOccurrence)
        //        throw new Exception("Prototype plane for constraint was actually an occurrence.");

        //    part._AssertIsDisplayPart();
        //    NXOpen.Session.UndoMarkId markId3 = session_.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Start");
        //    NXOpen.Positioning.ComponentPositioner component_positioner1 = part.ComponentAssembly.Positioner;
        //    component_positioner1.ClearNetwork();
        //    component_positioner1.BeginAssemblyConstraints();
        //    NXOpen.Positioning.Network component_network1 = component_positioner1.EstablishNetwork();
        //    NXOpen.Positioning.ComponentConstraint componentConstraint1 = (NXOpen.Positioning.ComponentConstraint)component_positioner1.CreateConstraint(true);
        //    componentConstraint1.ConstraintType = NXOpen.Positioning.Constraint.Type.Distance;
        //    create_const_ref_occ(componentConstraint1, __occ_plane);
        //    create_const_ref_proto(componentConstraint1, __proto_plane);
        //    componentConstraint1.SetExpression(__distance_or_expression_name);
        //    component_network1.AddConstraint(componentConstraint1);
        //    component_network1.Solve();
        //    component_positioner1.ClearNetwork();
        //    session_.UpdateManager.AddToDeleteList(component_network1);
        //    session_.UpdateManager.DoUpdate(markId3);
        //    component_positioner1.EndAssemblyConstraints();
        //    session_.DisplayManager.BlankObjects(new[] { componentConstraint1.GetDisplayedConstraint() });
        //    return componentConstraint1;
        //}

        public static ComponentConstraint __ConstrainOccProtoDistance(
            this BasePart part,
            DatumPlane __occ_plane,
            DatumPlane __proto_plane,
            string __distance_or_expression_name)
        {
            if(__work_part_.Tag != __display_part_.Tag)
                throw new Exception("Display part must be Work part");

            if(!__occ_plane.IsOccurrence)
                throw new Exception("Occurrence plane for constraint was actually a prototype.");

            if(__proto_plane.IsOccurrence)
                throw new Exception("Prototype plane for constraint was actually an occurrence.");

            part.__AssertIsDisplayPart();
            var markId3 = session_.SetUndoMark(Session.MarkVisibility.Visible, "Start");
            var component_positioner1 = part.ComponentAssembly.Positioner;
            component_positioner1.ClearNetwork();
            component_positioner1.BeginAssemblyConstraints();
            var component_network1 = component_positioner1.EstablishNetwork();
            var componentConstraint1 =
                (ComponentConstraint)component_positioner1.CreateConstraint(true);
            componentConstraint1.ConstraintType = Constraint.Type.Distance;
            componentConstraint1.__CreateConstRefOcc(__occ_plane);
            componentConstraint1.__CreateConstRefProto(__proto_plane);
            componentConstraint1.SetExpression(__distance_or_expression_name);
            component_network1.AddConstraint(componentConstraint1);
            component_network1.Solve();
            component_positioner1.ClearNetwork();
            session_.UpdateManager.AddToDeleteList(component_network1);
            session_.UpdateManager.DoUpdate(markId3);
            component_positioner1.EndAssemblyConstraints();
            session_.DisplayManager.BlankObjects(new[] { componentConstraint1.GetDisplayedConstraint() });
            return componentConstraint1;
        }

        /// <summary>
        ///     Creates a TrimBody feature by trimming with a face
        /// </summary>
        /// <param name="part">The part to create the feature in</param>
        /// <param name="targetBody">The target body to be trimmed</param>
        /// <param name="toolFace">The face used to trim the target body</param>
        /// <param name="direction">Trim direction. The default direction is the normal of the face.</param>
        /// <returns>A Snap.NX.TrimBody object</returns>
        public static TrimBody2 __CreateTrimBody(this BasePart part, Body targetBody,
            Face toolFace, bool direction)
        {
            part.__AssertIsWorkPart();
            var trimBody2Builder = part.Features.CreateTrimBody2Builder(null);

            using (session_.using_builder_destroyer(trimBody2Builder))
            {
                trimBody2Builder.Tolerance = DistanceTolerance;
                trimBody2Builder.BooleanTool.ExtrudeRevolveTool.ToolSection.DistanceTolerance = DistanceTolerance;
                trimBody2Builder.BooleanTool.ExtrudeRevolveTool.ToolSection.ChainingTolerance = ChainingTolerance;
                var scCollector = part.ScCollectors.CreateCollector();
                var bodies = new Body[1] { targetBody };
                var bodyDumbRule = part.ScRuleFactory.CreateRuleBodyDumb(bodies);
                var rules = new SelectionIntentRule[1] { bodyDumbRule };
                scCollector.ReplaceRules(rules, false);
                trimBody2Builder.TargetBodyCollector = scCollector;
                var rules2 = new SelectionIntentRule[1]
                    { part.ScRuleFactory.CreateRuleFaceBody(toolFace.GetBody()) };
                trimBody2Builder.BooleanTool.FacePlaneTool.ToolFaces.FaceCollector.ReplaceRules(rules2,
                    false);
                trimBody2Builder.BooleanTool.ReverseDirection = direction;
                return (TrimBody2)trimBody2Builder.Commit();
            }
        }

        public static CartesianCoordinateSystem __AbsoluteCsys(this BasePart part)
        {
            ufsession_.Modl.AskDatumCsysComponents(part.__AbsoluteDatumCsys().Tag, out var csys_tag, out _,
                out _, out _);
            return (CartesianCoordinateSystem)session_._GetTaggedObject(csys_tag);
        }

        public static void __ReplaceRefSets(this BasePart part, Component[] __components,
            string __refset_name)
        {
            part.ComponentAssembly.ReplaceReferenceSetInOwners(__refset_name, __components);
        }

        public static Expression __FindExpression(this BasePart part, string __expression_name)
        {
            try
            {
                return part.Expressions.FindObject(__expression_name);
            }
            catch (NXException ex) when (ex.ErrorCode == 3520016)
            {
                throw NXException.Create(ex.ErrorCode,
                    $"Could not find expression '{__expression_name}' in part {part.Leaf}");
            }
        }

        public static void __Fit(this BasePart part)
        {
            part.ModelingViews.WorkView.Fit();
        }

        public static void __RightClickOpenAssemblyWhole(this BasePart part)
        {
            if(session_.Parts.Display is null)
                throw new Exception("There is no open display part to right click open assembly");

            if(__work_part_.Tag != __display_part_.Tag)
                throw new Exception("DisplayPart does not equal __work_part_");

            if(__display_part_.Tag != part.Tag)
                throw new Exception($"Part {part.Leaf} is not the current display part");

            __display_part_.ComponentAssembly.OpenComponents(
                ComponentAssembly.OpenOption.WholeAssembly,
                new[] { part.ComponentAssembly.RootComponent },
                out _);
        }

        public static Component __AddComponent(
            this BasePart part,
            string path,
            string referenceSet = "Entire Part",
            string componentName = null,
            Point3d? origin = null,
            Matrix3x3? orientation = null,
            int layer = 1)
        {
            var __origin = origin ?? _Point3dOrigin;
            var __orientation = orientation ?? _Matrix3x3Identity;
            return part.__AddComponent(session_.find_or_open(path), referenceSet, componentName, __origin,
                __orientation, layer);
        }


        public static Component __AddComponent(
            this BasePart part,
            BasePart prototype,
            string referenceSet = "Entire Part",
            string componentName = null,
            Point3d? origin = null,
            Matrix3x3? orientation = null,
            int layer = 1)
        {
            var __origin = origin ?? _Point3dOrigin;
            var __orientation = orientation ?? _Matrix3x3Identity;
            return part.ComponentAssembly.AddComponent(prototype, referenceSet, componentName, __origin, __orientation,
                layer, out _);
        }


        /// <summary>Constructs a NXOpen.Arc from center, axes, radius, angles</summary>
        /// <param name="center">Center point (in absolute coordinates)</param>
        /// <param name="axisX">Unit vector along X-axis (where angle = 0)</param>
        /// <param name="axisY">Unit vector along Y-axis (where angle = 90)</param>
        /// <param name="radius">Radius</param>
        /// <param name="angle1">Start angle (in degrees)</param>
        /// <param name="angle2">End angle (in degrees)</param>
        /// <returns> A <see cref="NXOpen.Arc">NXOpen.Arc</see> object</returns>
        internal static Arc __CreateArc1(
            this BasePart basePart,
            Point3d center,
            Vector3d axisX,
            Vector3d axisY,
            double radius,
            double angle1,
            double angle2)
        {
            basePart.__AssertIsWorkPart();
            var startAngle = DegreesToRadians(angle1);
            var endAngle = DegreesToRadians(angle2);
            return __work_part_.Curves.CreateArc(center, axisX, axisY, radius, startAngle, endAngle);
        }

        public static PartCollection.SdpsStatus __SetActiveDisplay(this BasePart __part)
        {
            if(session_.Parts.AllowMultipleDisplayedParts != PartCollection.MultipleDisplayedPartStatus.Enabled)
                throw new Exception("Session does not allow multiple displayed parts");

            return session_.Parts.SetActiveDisplay(
                __part,
                DisplayPartOption.AllowAdditional,
                PartDisplayPartWorkPartOption.UseLast,
                out _);
        }

        /// <summary>Constructs a fillet arc from three points</summary>
        /// <param name="p0">First point</param>
        /// <param name="pa">Apex point</param>
        /// <param name="p1">Last point</param>
        /// <param name="radius">Radius</param>
        /// <returns>A Geom.Arc representing the fillet</returns>
        /// <remarks>
        ///     <para>
        ///         The fillet will be tangent to the lines p0-pa and pa-p1.
        ///         Its angular span will we be less than 180 degrees.
        ///     </para>
        /// </remarks>
        [Obsolete]
        public static Arc __CreateFillet(
            this BasePart part,
            Point3d p0,
            Point3d pa,
            Point3d p1,
            double radius)
        {
            //NXOpen.Vector3d vector = p0._Subtract(pa)._Unit();
            //NXOpen.Vector3d vector2 = p1._Subtract(pa)._Unit();
            //NXOpen.Vector3d vector3 = vector._Add(vector2);
            //double num = vector._Angle(vector2) / 2.0;
            //double num2 = radius / Math.SinD(num);
            //NXOpen.Point3d center = vector3._Multiply(num2)._Add(pa);
            //NXOpen.Vector3d vector4 = vector3._Negate();
            //NXOpen.Vector3d vector5 = vector2._Subtract(vector)._Unit();
            //double num3 = 90.0 - num;
            //double startAngle = 0.0 - num3;
            //double endAngle = num3;
            //return part.__CreateArc(center, vector4, vector5, radius, startAngle, endAngle);
            throw new NotImplementedException();
        }


        /// <summary>Creates a datum axis with a given origin and direction</summary>
        /// <param name="origin">The origin of the datum axis</param>
        /// <param name="direction">The direction of the datum axis</param>
        /// <returns> A <see cref="T:Snap.NX.DatumAxis">Snap.NX.DatumAxis</see> object</returns>
        [Obsolete(nameof(NotImplementedException))]
        public static DatumAxisFeature __CreateDatumAxis(this BasePart part,
            Point3d origin, Vector3d direction)
        {
            //return CreateDatumAxis(origin, direction);
            throw new NotImplementedException();
        }

        public static NXMatrix __CreateNXMatrix(this BasePart basePart, Matrix3x3 matrix)
        {
            return basePart.NXMatrices.Create(matrix);
        }

        public static CoordinateSystem __CreateCsys(this BasePart basePart, Vector3d vector3D)
        {
            var orientation = basePart.__CreateNXMatrix(vector3D._ToMatrix3x3());

            return basePart.__CreateCoordinateSystem(_Point3dOrigin, orientation);
        }
    }
}
// 2362