﻿using System;
using System.Collections.Generic;
using System.Linq;
using NXOpen;
using TSG_Library.Attributes;
using static TSG_Library.Extensions.__Extensions_;
using static NXOpen.UF.UFConstants;
using Selection = TSG_Library.Ui.Selection;

namespace TSG_Library.UFuncs
{
    [UFunc(ufunc_copy_ref_sets)]
    [RevisionEntry("1.0", "2017", "06", "05")]
    [Revision("1.0.1", "Revision Log Created for NX 11.")]
    [RevisionEntry("1.1", "2017", "08", "22")]
    [Revision("1.1.1", "Signed so it will run outside of CTS.")]
    [RevisionEntry("11.1", "2023", "01", "09")]
    [Revision("11.1.1", "Removed validation")]
    public class CopyRefSets : _UFunc
    {
        public override void execute()
        {
            try
            {
                using (session_.__usingDisplayPartReset())
                {
                    var originalWorkPart = __work_part_;
                    var refSetName = new List<string>();
                    session_.SetUndoMark(Session.MarkVisibility.Visible, "Copy Reference Sets");
                    var fromComponent = Selection.SelectManyComponents().ToList();
                    var toComponents = Selection.SelectManyComponents().ToList();
                    var cycleRefSet = Tag.Null;

                    if(fromComponent.Count == 0 || toComponents.Count == 0)
                        return;

                    var copyFromPart = ufsession_.Assem.AskPrototypeOfOcc(fromComponent[0].Tag);

                    do
                    {
                        ufsession_.Obj.CycleObjsInPart(copyFromPart, UF_reference_set_type, ref cycleRefSet);

                        if(cycleRefSet == Tag.Null)
                            break;

                        ufsession_.Obj.AskName(cycleRefSet, out var name);

                        if(!((name != Refset_Body) & (name != "SUB_TOOL") & (name != Refset_EntirePart) &
                             (name != Refset_Empty)))
                            continue;

                        refSetName.Add(name);
                    } while (cycleRefSet != Tag.Null);

                    //------------------------------------------------------------------------------
                    // Make each copy to component the work part
                    // Create reference sets and add to current work part
                    //------------------------------------------------------------------------------

                    if(refSetName.Count == 0)
                        throw new Exception("There are no reference sets other than the component defaults");

                    foreach (var wpComponent in toComponents.Select(__c => __c))
                    {
                        if(!(wpComponent.Prototype is Part))
                            continue;

                        var part = (Part)wpComponent.Prototype;

                        if(part.PartUnits != BasePart.Units.Inches)
                            continue;

                        __work_component_ = wpComponent;
                        const int numOfMembers = 0;
                        var refSetArray = new List<Tag>();

                        foreach (var refName in refSetName)
                        {
                            var origin = new double[3];
                            ufsession_.Csys.AskWcs(out var wcs);
                            ufsession_.Csys.AskCsysInfo(wcs, out var wcsMatrix,
                                origin); // get origin of current work coordinate system
                            var matrixValue = new double[9];
                            ufsession_.Csys.AskMatrixValues(wcsMatrix, matrixValue); // gets the matrix values
                            ufsession_.Assem.CreateRefSet(refName, origin, matrixValue, refSetArray.ToArray(),
                                numOfMembers, out _);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.__PrintException();
            }
        }
    }
}