﻿using System;
using System.Collections.Generic;
using System.Linq;
using NXOpen;
using NXOpen.Assemblies;
using NXOpen.UF;
using NXOpen.Utilities;
using static NXOpen.UF.UFConstants;
// ReSharper disable UnusedVariable

namespace TSG_Library.Utilities
{
    internal static class SelectWithFilter
    {
        private static readonly Session TheSession = Session.GetSession();

        private static readonly UFSession Ufs = UFSession.GetUFSession();

        public static Body SelectedCompBody;

        public static List<string> NonValidCandidates;

        private static readonly UFUi.SelInitFnT Ip = init_proc;

        private static readonly UFUi.SelFilterFnT Fp = filter_proc;

        public static void GetSelectedWithFilter(string prompt)
        {
            SelectedCompBody = SelectComponent(prompt);
        }

        public static Body SelectComponent(string prompt)
        {
            double[] cursor = new double[3];
            Ufs.Ui.LockUgAccess(UF_UI_FROM_CUSTOM);
            try
            {
                Ufs.Ui.SelectWithSingleDialog(prompt, prompt, UF_UI_SEL_SCOPE_ANY_IN_ASSEMBLY, Ip, IntPtr.Zero,
                    out int response, out Tag selectedObj,
                    cursor, out Tag view);
                Ufs.Ui.UnlockUgAccess(UF_UI_FROM_CUSTOM);
                if (response != UF_UI_OBJECT_SELECTED || selectedObj == Tag.Null) return null;
                Body comp = (Body)NXObjectManager.Get(selectedObj);
                comp.Unhighlight();
                return comp;
            }
            catch (NXException ex)
            {
                TheSession.ListingWindow.Open();
                TheSession.ListingWindow.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                Ufs.Ui.UnlockUgAccess(UF_UI_FROM_CUSTOM);
            }
        }

        public static int filter_proc(Tag @object, int[] type, IntPtr userData, IntPtr select)
        {
            Body obj1 = (Body)NXObjectManager.Get(@object);
            Component objComp = obj1.OwningComponent;
            if (objComp == null) return UF_UI_SEL_ACCEPT;
            bool isFound = NonValidCandidates.Where(name => objComp.Name != string.Empty)
                .Any(name => objComp.Name.ToLower().Contains(name));
            return isFound ? UF_UI_SEL_REJECT : UF_UI_SEL_ACCEPT;
        }

        public static int init_proc(IntPtr select, IntPtr userdata)
        {
            UFUi.Mask[] maskTriples = new UFUi.Mask[1];
            maskTriples[0].object_type = UF_solid_type;
            maskTriples[0].object_subtype = UF_solid_body_subtype;
            maskTriples[0].solid_type = 0;
            Ufs.Ui.SetSelMask(select, UFUi.SelMaskAction.SelMaskClearAndEnableSpecific, 1, maskTriples);
            Ufs.Ui.SetSelProcs(select, Fp, null, userdata);
            return UF_UI_SEL_SUCCESS;
        }
    }
}