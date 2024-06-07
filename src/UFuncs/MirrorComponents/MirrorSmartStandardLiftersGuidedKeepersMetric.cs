﻿using System;
using System.Collections.Generic;
using NXOpen;
using NXOpen.Assemblies;
using NXOpen.Features;
using TSG_Library.Geom;

namespace TSG_Library.UFuncs.UFuncUtilities.MirrorUtilities
{
    public class MirrorSmartStandardLiftersGuidedKeepersMetric : ILibraryComponent
    {
        public bool IsLibraryComponent(Component component)
        {
            if (!component.HasUserAttribute("LIBRARY", NXObject.AttributeType.String, -1))
                return false;

            // Check to see if it is a smart key metric
            return component.GetUserAttributeAsString("LIBRARY", NXObject.AttributeType.String, -1).ToUpper() ==
                   "SMART STANDARD LIFTERS GUIDED KEEPERS METRIC";
        }

        [Obsolete(nameof(NotImplementedException))]
        public void Mirror(
            Surface.Plane plane,
            Component mirroredComp,
            ExtractFace originalLinkedBody,
            Component fromComp,
            IDictionary<TaggedObject, TaggedObject> dict)
        {
            throw new KeyNotFoundException();
            //NXOpen.Features.ExtractFace mirroredLinkedBody = (NXOpen.Features.ExtractFace)dict[originalLinkedBody];

            //NXOpen.Point3d mirroredOrigin = fromComp._Origin()._Mirror(plane);

            //NXOpen.Matrix3x3 mirroredOrientation = fromComp._Orientation()._Mirror(plane);

            //NXOpen.Vector3d newXDir = mirroredOrientation._AxisX();

            //NXOpen.Vector3d newYDir = mirroredOrientation._AxisY()._Negate();

            //mirroredOrientation = newXDir._ToMatrix3x3(newYDir);

            //NXOpen.Assemblies.Component newFromComp = fromComp._OwningPart().ComponentAssembly.AddComponent(
            //    fromComp._Prototype(),
            //    "Entire Part",
            //    fromComp.Name,
            //    mirroredOrigin,
            //    mirroredOrientation,
            //    fromComp.Layer,
            //    out NXOpen.PartLoadStatus status);

            //NXOpen.Features.ExtractFaceBuilder builder = originalLinkedBody._OwningPart().Features.CreateExtractFaceBuilder(originalLinkedBody);

            //NXOpen.Body[] originalBodies = builder.ExtractBodyCollector.GetObjects().OfType<NXOpen.Body>().ToArray();

            //if (originalBodies.Length == 0)
            //    throw new System.InvalidOperationException("Unable to find bodies for smart key");

            //builder.Destroy();

            //status.Dispose();

            //Globals._WorkPart = mirroredComp._Prototype();

            //Globals.__work_component_ = mirroredComp;

            //NXOpen.Session.UndoMarkId markId2 = Globals.session_.SetUndoMark(NXOpen.Session.MarkVisibility.Visible, "Redefine Feature");

            //NXOpen.Features.EditWithRollbackManager rollBackManager = Globals._WorkPart.Features.StartEditWithRollbackManager(mirroredLinkedBody, markId2);

            //using (new Destroyer(rollBackManager))
            //{
            //    builder = Globals._WorkPart.Features.CreateExtractFaceBuilder(mirroredLinkedBody);

            //    newFromComp._ReferenceSet("Entire Part");

            //    using (new Destroyer(builder))
            //    {
            //        // For now we will just assume that every rule must be a DumbBodyRule
            //        IList<NXOpen.Body> mirrorBodies = originalBodies.Select(originalBody => (NXOpen.Body)newFromComp.FindOccurrence(originalBody)).ToList();

            //        NXOpen.SelectionIntentRule mirrorBodyDumbRule = Globals._WorkPart.ScRuleFactory.CreateRuleBodyDumb(mirrorBodies.ToArray());

            //        builder.ExtractBodyCollector.ReplaceRules(new[] { mirrorBodyDumbRule }, false);

            //        builder.Associative = true;

            //        builder.CommitFeature();

            //    }
            //}

            //newFromComp._ReferenceSet("BODY");
        }
    }
}