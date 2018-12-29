﻿
namespace iTin.Core.Hardware.Specification.Smbios
{
    using System.Collections;
    using System.Diagnostics;

    using Dmi.Property;
    using Helpers;

    // Type 027: Cooling Device.
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // |          Spec.                                                                                             |
    // | Offset   Version     Name                Length      Value       Description                               |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 00h      2.2+        Type                BYTE        27          Cooling Device indicator                  |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 01h      2.2+        Length              BYTE        Varies      Length of the structure, at least 0Ch     |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 02h      2.2+        Handle              WORD        Varies      The handle, or instance number, associated|
    // |                                                                  with the structure                        |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 04h      2.2+        Temperature         WORD        Varies      The handle, or instance number, of the    |
    // |                      Probe Handle                                temperature probe monitoring this cooling |
    // |                                                                  device.                                   |
    // |                                                                  A value of 0xFFFF indicates that no probe |
    // |                                                                  is provided.                              |
    // |                                                                  Note: Ver ProbeHandle                     |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 06h      2.2+        Device Type         BYTE        Bit Field   Identifies the cooling device type and    |
    // |                      and Status                                  the status of this cooling device.        |
    // |                                                                  Note: ver GetDeviceType(byte)             |
    // |                                                                  Note: Ver GetStatus(byte)                 |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 07h      2.2+        Cooling Unit        BYTE        Varies      Identifies the cooling unit group to which|
    // |                      Group                                       this cooling device is associated.        |
    // |                                                                  Having multiple cooling devices in the    |
    // |                                                                  same cooling unit implies a redundant     |
    // |                                                                  configuration.                            |
    // |                                                                  The value is 00h if the cooling device is |
    // |                                                                  not a member of a redundant cooling unit. |
    // |                                                                  Non-zero values imply redundancy and that |
    // |                                                                  at least one other cooling device will be |
    // |                                                                  enumerated with the same value.           |
    // |                                                                  Note: Ver UnitGroup                       |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 08h      2.2+        OEM-defined         DWORD       Varies      Contains OEM- or BIOS vendor-specific     |
    // |                                                                  information.                              |
    // |                                                                  Note: Ver OemDefined                      |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 0Ch      2.2+        Nominal             WORD        Varies      The nominal value for the cooling device’s|
    // |                      Speed                                       rotational speed, in revolutions-per-     |
    // |                                                                  minute (rpm).                             |
    // |                                                                  partition.                                |
    // |                                                                  If the value is unknown or the cooling    |
    // |                                                                  device is nonrotating, the field is set   |
    // |                                                                  to 0x8000.                                |
    // |                                                                  1 or 2.                                   |
    // |                                                                  This field is present in the structure    |
    // |                                                                  only if the structure’s Length is larger  |
    // |                                                                  than 0Ch.                                 |
    // |                                                                  Note: Ver NominalSpeed                    |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 0Eh      2.7+        Description         BYTE        STRING      The number of the string that contains    |
    // |                                                                  additional descriptive information about  |
    // |                                                                  the cooling device or its location.       |
    // |                                                                                                            |
    // |                                                                  This field is present in the structure    |
    // |                                                                  only if the structure’s Length is 0Fh or  |
    // |                                                                  larger.                                   |
    // |                                                                  Note: Ver Description                     |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•

    /// <summary>
    /// Specialization of the <see cref = "T:iTin.Core.Hardware.Specification.Smbios.SmbiosBaseType" /> class that contains the logic to decode the Cooling Device (Type 27) structure.
    /// </summary>
    sealed class SmbiosType027 : SmbiosBaseType
    {
        #region constructor/s

        #region [public] SmbiosType027(SmbiosStructureHeaderInfo, int): Initializes a new instance of the class by specifying the structure information and the SMBIOS version.
        /// <summary>
        /// Initializes a new instance of the <see cref="SmbiosType027"/> class by specifying the structure information and the <see cref="SMBIOS" /> version.
        /// </summary>
        /// <param name="smbiosStructureHeaderInfo">Raw information of the current structure.</param>
        /// <param name="smbiosVersion">Current <see cref="SMBIOS" /> version.</param>
        public SmbiosType027(SmbiosStructureHeaderInfo smbiosStructureHeaderInfo, int smbiosVersion) : base(smbiosStructureHeaderInfo, smbiosVersion)
        {
        }
        #endregion

        #endregion

        #region private properties

        #region Version 2.2+ fields

        #region [private] (int) TemperatureProbeHandle: Gets a value representing the 'Temperature Probe Handle' field.
        /// <summary>
        /// Gets a value representing the <c>Temperature Probe Handle</c> field.
        /// </summary>
        /// <value>
        /// Property value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int TemperatureProbeHandle
        {
            get { return GetWord(0x04); }
        }
        #endregion

        #region [private] (byte) DeviceTypeAndStatus: Gets a value representing the 'Device Type And Status' field.
        /// <summary>
        /// Gets a value representing the <c>Device Type And Status</c> field.
        /// </summary>
        /// <value>
        /// Property value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private byte DeviceTypeAndStatus
        {
            get { return GetByte(0x06); }
        }
        #endregion

        #region [private] (byte) DeviceType: Gets a value representing the 'Device Type' feature of the 'Device Type And Status' field.
        /// <summary>
        /// Gets a value representing the <c>Device Type</c> feature of the <c>Device Type And Status</c> field
        /// </summary>
        /// <value>
        /// Feature value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private byte DeviceType
        {
            get { return (byte) (DeviceTypeAndStatus & 0x1f); }
        }
        #endregion

        #region [private] (byte) Status: Gets a value representing the 'Status' feature of the 'Device Type And Status' field.
        /// <summary>
        /// Gets a value representing the <c>Status</c> feature of the <c>Device Type And Status</c> field
        /// </summary>
        /// <value>
        /// Feature value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private byte Status
        {
            get { return (byte) ((DeviceTypeAndStatus >> 5) & 0x07); }
        }
        #endregion

        #region [private] (byte) CoolingUnitGroup: Gets a value representing the 'Cooling Unit Group' field.
        /// <summary>
        /// Gets a value representing the <c>Cooling Unit Group</c> field.
        /// </summary>
        /// <value>
        /// Property value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private byte CoolingUnitGroup
        {
            get { return GetByte(0x07); }
        }
        #endregion

        #region [private] (long) OemDefined: Gets a value representing the 'Oem Defined' field.
        /// <summary>
        /// Gets a value representing the <c>Oem Defined</c> field.
        /// </summary>
        /// <value>
        /// Property value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private long OemDefined
        {
            get { return GetDoubleWord(0x08); }
        }
        #endregion

        #region [private] (int) NominalSpeed: Gets a value representing the 'Nominal Speed' field.
        /// <summary>
        /// Gets a value representing the <c>Nominal Speed</c> field.
        /// </summary>
        /// <value>
        /// Property value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private int NominalSpeed
        {
            get { return GetWord(0x0c); }
        }
        #endregion

        #endregion

        #region Version 2.7+ fields

        #region [private] (string) Description: Gets a value representing the 'Description' field.
        /// <summary>
        /// Gets a value representing the <c>Description</c> field.
        /// </summary>
        /// <value>
        /// Property value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string Description
        {
            get { return GetString(0x0e); }
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
            SmbiosType027Property propertyId = (SmbiosType027Property) propertyKey.PropertyId;

            switch (propertyId)
            {
                #region [0x04] - [Temperature Probe Handle] - [Int32?]
                case SmbiosType027Property.TemperatureProbeHandle:
                    if (TemperatureProbeHandle != 0xffff)
                    {
                        value = TemperatureProbeHandle;
                    }
                    break;
                #endregion

                #region [0x06] - [Device Type And Status]

                    #region [0x06] - [Device Type And Status -> Status] - [String]
                    case SmbiosType027Property.Status:
                        value = GetStatus(Status);
                        break;
                    #endregion

                    #region [0x06] - [Device Type And Status -> Location] - [String]
                    case SmbiosType027Property.DeviceType:
                        value = GetDeviceType(DeviceType);
                        break;
                    #endregion

                #endregion

                #region [0x07] - [Cooling Unit Group] - [Byte?]
                case SmbiosType027Property.CoolingUnitGroup:
                    if (CoolingUnitGroup != 0x00)
                    {
                        value = CoolingUnitGroup;
                    }
                    break;
                #endregion

                #region [0x08] - [OEM-defined] - [Int64]
                case SmbiosType027Property.OemDefined:
                    value = OemDefined;
                    break;
                #endregion

                #region [0x0c] - [Nominal Speed] - [Int32?]
                case SmbiosType027Property.NominalSpeed:
                    if (HeaderInfo.Lenght >= 0x0d)
                    {
                        if (NominalSpeed != 0x8000)
                        {
                            value = NominalSpeed;
                        }
                    }
                    break;
                #endregion

                #region [0x0e] - [Description] - [String]
                case SmbiosType027Property.Description:
                    if (HeaderInfo.Lenght >= 0x0f)
                    {
                        value = Description;
                    }
                    break;
                #endregion
            }

            return value;
        }
        #endregion

        #region [protected] {override} (void) Parse(Hashtable): Obtiene la colección de propiedades de esta estructura.
        /// <summary>
        /// Obtiene la colección de propiedades de esta estructura.
        /// </summary>
        /// <param name="properties">Colección de propiedades de esta estructura.</param>
        protected override void Parse(Hashtable properties)
        {
            #region validate parameter/s
            SentinelHelper.ArgumentNull(properties);
            #endregion

            #region values
            if (TemperatureProbeHandle != 0xffff)
            {
                properties.Add(KnownDmiProperty.CoolingDevice.TemperatureProbeHandle, TemperatureProbeHandle);
            }

            properties.Add(KnownDmiProperty.CoolingDevice.DeviceTypeAndStatus.Status, GetStatus(Status));
            properties.Add(KnownDmiProperty.CoolingDevice.DeviceTypeAndStatus.DeviceType, GetDeviceType(DeviceType));

            if (CoolingUnitGroup != 0x00)
            {
                properties.Add(KnownDmiProperty.CoolingDevice.CoolingUnitGroup, CoolingUnitGroup);
            }

            properties.Add(KnownDmiProperty.CoolingDevice.OemDefined, OemDefined);

            if (HeaderInfo.Lenght >= 0x0d)
            {
                if (NominalSpeed != 0x8000)
                {
                    properties.Add(KnownDmiProperty.CoolingDevice.NominalSpeed, NominalSpeed);
                }
            }

            if (HeaderInfo.Lenght >= 0x0f)
            {
                properties.Add(KnownDmiProperty.CoolingDevice.Description, Description);
            }
            #endregion
        }
        #endregion

        #endregion

        #region BIOS Specification 2.7.1 (26/01/2011)

        #region [private] {static} (string) GetDeviceType(byte): Gets a string representing the device type.
        /// <summary>
        /// Gets a string representing the device type.
        /// </summary>
        /// <param name="code">Value to analyze.</param>
        /// <returns>
        /// The device type.
        /// </returns>
        private static string GetDeviceType(byte code)
        {
            var value = new[]
            {
                "Other",                       // 0x01
                "Unknown",
                "Fan",
                "Centrifugal Blower",
                "Chip Fan",
                "Cabinet Fan",
                "Power Supply Fan",
                "Heat Pipe",
                "Integrated Refrigeration",
                "Active Cooling",
                "Passive Cooling"              // 0x0b
            };

            if (code >= 0x01 && code <= 0x0b)
            {
                return value[code - 0x01];
            }

            return SmbiosHelper.OutOfSpec;
        }
        #endregion

        #region [private] {static} (string) GetStatus(byte): Gets a string representing the state of the test.
        /// <summary>
        /// Gets a string representing the state of the test.
        /// </summary>
        /// <param name="code">Value to analyze.</param>
        /// <returns>
        /// The state of the test.
        /// </returns>
        private static string GetStatus(byte code)
        {
            var value = new[]
            {
                "Other",             // 0x01
                "Unknown",
                "Ok",
                "Non-critical",
                "Critical",
                "Non-recoverable"    // 0x06
            };

            if (code >= 0x01 && code <= 0x06)
            {
                return value[code - 0x01];
            }

            return SmbiosHelper.OutOfSpec;
        }
        #endregion

        #endregion
    }
}