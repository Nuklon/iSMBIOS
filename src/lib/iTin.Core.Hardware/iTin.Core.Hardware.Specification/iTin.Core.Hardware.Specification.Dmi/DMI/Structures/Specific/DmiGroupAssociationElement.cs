﻿
namespace iTin.Core.Hardware.Specification.Dmi
{
    using Property;

    using Smbios;
    using Smbios.Property;

    /// <summary>
    /// This class represents an element of the structure <see cref="DmiType014"/>.
    /// </summary>
    public class DmiGroupAssociationElement
    {
        #region private members
        private readonly SmbiosPropertiesTable _reference;
        #endregion

        #region constructor/s

        #region [internal] DmiGroupAssociationElement(SmbiosPropertiesTable): Initialize a new instance of the class specifying the structure information
        /// <summary>
        /// Initialize a new instance of the class <see cref="DmiGroupAssociationElement" /> specifying the information of the structure.
        /// </summary>
        /// <param name="reference"><c>SMBIOS</c> properties.</param>
        internal DmiGroupAssociationElement(SmbiosPropertiesTable reference)
        {
            _reference = reference;
        }
        #endregion

        #endregion

        #region public properties

        #region [public] (DmiClassPropertiesTable) Properties : 
        public DmiClassPropertiesTable Properties =>
            new DmiClassPropertiesTable
            {
                {DmiProperty.GroupAssociations.Items.Structure, _reference[SmbiosProperty.GroupAssociations.Items.Structure]},
                {DmiProperty.GroupAssociations.Items.Handle, _reference[SmbiosProperty.GroupAssociations.Items.Handle]}
            };
        #endregion

        #endregion
    }
}