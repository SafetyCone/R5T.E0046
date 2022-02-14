﻿using System;


namespace R5T.E0046.Library
{
    /// <summary>
    /// Allows specifying a sort order for using directive blocks.
    /// </summary>
    public class UsingDirectiveBlockSortOrder
    {
        #region Static

        public static UsingDirectiveBlockSortOrder From(params string[] blockLabels)
        {
            var output = new UsingDirectiveBlockSortOrder(blockLabels);
            return output;
        }

        #endregion


        public string[] BlockLabels { get; }


        public UsingDirectiveBlockSortOrder(string[] blockLabels)
        {
            this.BlockLabels = blockLabels;
        }
    }
}
