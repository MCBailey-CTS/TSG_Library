﻿using System;
using System.Windows.Forms;
using NXOpen;
using NXOpen.Assemblies;
using TSG_Library.Extensions;

namespace TSG_Library.UFuncs.UFuncUtilities.DesignCheckUtilities
{
    [Obsolete]
    public class PositionOverride : IDesignCheck
    {
        //public bool IsPartValidForCheck(Part part, out string message)
        //{
        //    message = "";
        //    return !(part.ComponentAssembly.RootComponent is null);
        //}

        public DCResult PerformCheck(Part part, out TreeNode result_node)
        {
            result_node = part.__TreeNode();
            return DCResult.fail;
        }

        [Obsolete]
        public TreeNode PerformCheck(Part part)
        {
            TreeNode part_node = part.__TreeNode();

            foreach (Component child in part.ComponentAssembly.RootComponent.GetChildren())
                if (child.GetPositionOverrideType() != PositionOverrideType.Explicit)
                    part_node.Nodes.Add(child.__TreeNode());

            return part_node;
        }
    }
}