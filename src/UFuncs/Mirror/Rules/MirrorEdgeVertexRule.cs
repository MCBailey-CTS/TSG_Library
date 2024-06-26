﻿using System;
using System.Collections.Generic;
using System.Linq;
using NXOpen;
using NXOpen.Assemblies;
using NXOpen.Features;
using TSG_Library.Extensions;
using TSG_Library.Geom;
using TSG_Library.UFuncs.MirrorComponents.Features;

namespace TSG_Library.UFuncs.Mirror.Rules
{
    public class MirrorEdgeVertexRule : BaseMirrorRule
    {
        public override SelectionIntentRule.RuleType RuleType { get; } = SelectionIntentRule.RuleType.EdgeVertex;


        public override SelectionIntentRule Mirror(SelectionIntentRule originalRule, Feature originalFeature,
            Surface.Plane plane, Component originalComp, IDictionary<TaggedObject, TaggedObject> dict)
        {
            Component component = (Component)dict[originalComp];
            Part part = component.__Prototype();
            Feature feature = (Feature)dict[originalFeature];
            ((EdgeVertexRule)originalRule).GetData(out Edge startEdge, out bool isFromStart);
            Body body = startEdge.GetBody();
            Body body2;
            if (!dict.ContainsKey(body))
            {
                feature.Suppress();
                originalFeature.Suppress();
                Feature parentFeatureOfBody = originalComp.__Prototype().Features.GetParentFeatureOfBody(body);
                BodyFeature bodyFeature = (BodyFeature)dict[parentFeatureOfBody];
                if (bodyFeature.GetBodies().Length != 1)
                    throw new InvalidOperationException("Invalid number of bodies for feature");

                body2 = bodyFeature.GetBodies()[0];
            }
            else
            {
                body2 = (Body)dict[body];
            }

            Point3d newStart = startEdge.__StartPoint()._MirrorMap(plane, originalComp, component);
            Point3d newEnd = startEdge.__EndPoint()._MirrorMap(plane, originalComp, component);
            Edge edge2 = body2.GetEdges().FirstOrDefault(edge => edge.__HasEndPoints(newStart, newEnd));
            if (edge2 == null) throw new InvalidOperationException("Could not find mirror edge");

            return part.ScRuleFactory.CreateRuleEdgeVertex(edge2, isFromStart);
        }
    }



}