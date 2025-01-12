﻿
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using iTin.Hardware.Specification.Smbios;

namespace iTin.Hardware.Specification.Dmi
{
    /// <inheritdoc/>
    /// <summary>
    /// Represents a collection of objects <see cref="SmbiosStructure"/> available on a motherboard.
    /// </summary>
    public sealed class BaseBoardContainedElementCollection : ReadOnlyCollection<SmbiosStructure>
    {
        #region constructor/s

        #region [internal] BaseBoardContainedElementCollection(IEnumerable<SmbiosStructure>): Initialize a new instance of the class
        /// <inheritdoc/>
        /// <summary>
        /// Initialize a new instance of the class <see cref="BaseBoardContainedElementCollection"/>.
        /// </summary>
        /// <param name="elements">Item list.</param>
        internal BaseBoardContainedElementCollection(IEnumerable<SmbiosStructure> elements) : base(elements.ToList())
        {
        }
        #endregion

        #endregion

        #region public override methods

        #region [public] {override} (string) ToString(): Returns a class String that represents the current object
        /// <summary>
        /// Returns a class <see cref="string"/> that represents the current object.
        /// </summary>
        /// <returns>
        /// Object <see cref="string"/> that represents the current <see cref="AdditionalInformationEntryCollection"/> class.
        /// </returns>
        /// <remarks>
        /// This method returns a string that includes the number of available items.
        /// </remarks>                                    
        public override string ToString() => $"Elements = {Items.Count}";
        #endregion

        #endregion              
    }
}
