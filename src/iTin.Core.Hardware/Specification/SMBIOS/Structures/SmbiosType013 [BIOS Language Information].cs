﻿
namespace iTin.Core.Hardware.Specification.Smbios
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;

    using Dmi.Property;
    using Helpers;
    using Helpers.Enumerations;

    // Type 013: BIOS Language Information.
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // |          Spec.                                                                                             |
    // | Offset   Version     Name                Length      Value       Description                               |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 00h      2.0+        Type                BYTE        13          Language Information Indicator            |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 01h      2.0+        Length              BYTE        16h                                                   |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 02h      2.0+        Handle              WORD        Varies                                                |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 04h      2.0+        Installable         BYTE        Varies      Número de lenguajes disponibles.          |
    // |                      Languages                                   Note: Ver GetValues(int)                  |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 05h      2.1+        Flags               BYTE        Bit Field   Bits 07:01 - Reservado                    |
    // |                                                                  Bit     00 - Formato                      |
    // |                                                                               0b - Lenguaje actual usa el  |
    // |                                                                                    formato largo.          |
    // |                                                                               1b - Lenguaje actual usa el  |
    // |                                                                                    formato abreviado.      |
    // |                                                                  Note: Ver IsCurrentAbbreviated            |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 06h      2.0+        Reserved            15 BYTEs    00h                                                   |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 015h     2.0+        Current             BYTE        STRING      Número de cadena (basado índice 0) del    |
    // |                      Language                                    lenguaje por defecto.                     |
    // |                                                                  Note: Ver Default                         |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•

    /// <summary>
    /// Specialization of the <see cref = "T:iTin.Core.Hardware.Specification.Smbios.SmbiosBaseType" /> class that contains the logic to decode the BIOS Language Information (Type 13) structure.
    /// </summary>
    sealed class SmbiosType013 : SmbiosBaseType
    {
        #region constructor/s

        #region [public] SmbiosType013(SmbiosStructureHeaderInfo, int): Initializes a new instance of the class by specifying the structure information and the SMBIOS version.
        /// <summary>
        /// Initializes a new instance of the <see cref="SmbiosType013"/> class by specifying the structure information and the <see cref="SMBIOS" /> version.
        /// </summary>
        /// <param name="smbiosStructureHeaderInfo">Raw information of the current structure.</param>
        /// <param name="smbiosVersion">Current <see cref="SMBIOS" /> version.</param>
        public SmbiosType013(SmbiosStructureHeaderInfo smbiosStructureHeaderInfo, int smbiosVersion) : base(smbiosStructureHeaderInfo, smbiosVersion)
        {
        }
        #endregion

        #endregion

        #region private properties

        #region Version 2.0+ fields

        #region [private] (int) Count: Gets a value representing the 'Count' field.
        /// <summary>
        /// Gets a value representing the <c>Count</c> field.
        /// </summary>
        /// <value>
        /// Property value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int Count
        {
            get { return GetByte(0x04); }
        }
        #endregion

        #region [private] (bool) IsCurrentAbbreviated: Gets a value representing the 'Is Current Abbreviated' field.
        /// <summary>
        /// Gets a value representing the <c>Is Current Abbreviated</c> field.
        /// </summary>
        /// <value>
        /// Property value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool IsCurrentAbbreviated
        {
            get { return GetByte(0x05).CheckBit(Bits.Bit00); }
        }
        #endregion

        #region [private] (string) Current: Gets a value representing the 'Current' field.
        /// <summary>
        /// Gets a value representing the <c>Current</c> field.
        /// </summary>
        /// <value>
        /// Property value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string Current
        {
            get { return GetString(0x015); }
        }
        #endregion

        #endregion

        #endregion

        #region protected override methods

        #region [protected] {override} (object) GetValueTypedProperty(PropertyKey): Gets a value that represents the value of the specified property.
        /// <summary>
        /// Gets a value that represents the value of the specified property.
        /// </summary>
        /// <param name="propertyKey">Property key to be obtained.</param>
        /// <returns>
        /// Property value
        /// </returns>
        protected override object GetValueTypedProperty(PropertyKey propertyKey)
        {
            object value = null;
            SmbiosType013Property propertyId = (SmbiosType013Property)propertyKey.PropertyId;

            switch (propertyId)
            {
                #region [0x04] - [v2.0] - [Installable Languages] - [ReadOnlyCollection<string>]
                case SmbiosType013Property.InstallableLanguages:
                    value = GetValues(Count);
                    break;
                #endregion

                #region [0x05] - [v2.1] - [Flags]

                #region [0x05] - [v2.1] - [Flags -> IsCurrentAbbreviated] - [bool]
                case SmbiosType013Property.IsCurrentAbbreviated:
                    value = IsCurrentAbbreviated;
                    break;
                #endregion

                #endregion

                #region [0x15] - [v2.0] - [Current Language] - [string]
                case SmbiosType013Property.Current:
                    value = Current;
                    break;
                #endregion
            }

            return value;
        }
        #endregion

        #region [protected] {override} (void) Parse(Hashtable): Gets the property collection for this structure.
        /// <summary>
        /// Gets the property collection for this structure.
        /// </summary>
        /// <param name="properties">Collection of properties of this structure.</param>
        protected override void Parse(Hashtable properties)
        {
            #region validate parameter/s
            SentinelHelper.ArgumentNull(properties);
            #endregion

            #region values
            properties.Add(KnownDmiProperty.BiosLanguage.InstallableLanguages, GetValues(Count));
            properties.Add(KnownDmiProperty.BiosLanguage.IsCurrentAbbreviated, IsCurrentAbbreviated);
            properties.Add(KnownDmiProperty.BiosLanguage.Current, Current);
            #endregion
        }
        #endregion

        #endregion

        #region private methods

        #region [private] (ReadOnlyCollection<string>) GetValues(int): Gets a collection with system information.
        /// <summary>
        /// Gets a collection with system information.
        /// </summary>
        /// <param name="count">Counter.</param>
        /// <returns>
        /// Colección con la información del sistema.
        /// </returns>
        private ReadOnlyCollection<string> GetValues(int count)
        {
            List<string> items = new List<string>();

            for (int i = 1; i <= count; i++)
            {
                items.Add(Strings[i]);
            }

            return items.AsReadOnly();
        }
        #endregion

        #endregion
    }
}