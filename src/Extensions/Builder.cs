﻿using NXOpen;
using TSG_Library.Disposable;

namespace TSG_Library.Extensions
{
    public static partial class Extensions
    {
        #region Builder

        public static Destroyer __UsingBuilder(this Builder builder)
        {
            return new Destroyer(builder);
        }

        #endregion
    }
}