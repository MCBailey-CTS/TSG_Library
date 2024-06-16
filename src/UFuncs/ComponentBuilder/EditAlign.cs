﻿using System.Collections.Generic;
using NXOpen;
using NXOpen.Features;
using NXOpen.GeometricUtilities;
using NXOpen.UF;
using System;
using NXOpen.UserDefinedObjects;
using static TSG_Library.Extensions.Extensions;
using static NXOpen.UF.UFConstants;
using NXOpenUI;
using System.Globalization;
using NXOpen.Assemblies;
using System.Windows.Forms;
using TSG_Library.Utilities;
using NXOpen.Utilities;
using NXOpen.Preferences;
using TSG_Library.Properties;

namespace TSG_Library.UFuncs
{
    public partial class EditBlockForm
    {

        private void ButtonEditAlign_Click(object sender, EventArgs e) => EditAlign();



        private void EditAlign()
        {
            try
            {
                bool isBlockComponent = SetDispUnits();


                if (_isNewSelection && _updateComponent is null)
                    SelectWithFilter_("Select Component to Align");

                EdgeAlign(isBlockComponent);
            }
            catch (Exception ex)
            {
                ex.__PrintException();
            }
            finally
            {
                Show();
            }
        }

    }
}
// 2045