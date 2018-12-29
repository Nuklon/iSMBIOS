﻿
namespace iTin.Core.Hardware.Specification.Smbios
{
    using System.Collections;
    using System.Diagnostics;

    using Dmi.Property;
    using Helpers;

    // Type 033: 64-Bit Memory Error Information.
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | Offset       Name            Length      Value       Description                                           |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 00h          Type            BYTE        33          64-bit Memory Error Information type                  |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 01h          Length          BYTE        1Fh         Length of the structure.                              |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 02h          Handle          WORD        Varies      The handle, or instance number, associated with the   |
    // |                                                      structure                                             |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 04h          Error Type      BYTE        ENUM        The type of error that is associated with the current |
    // |                                                      status reported for the memory array or device.       |
    // |                                                      Note: Ver GetErrorType(byte)                          |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 05h          Error           BYTE        ENUM        Identifies the granularity (for example, device versus|
    // |              Granularity                             Partition) to which the  error can be resolved.       |
    // |                                                      Note: Ver GetErrorGranularity(byte)                   |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 06h          Error           BYTE        ENUM        The memory access operation that caused the error.    |
    // |              Operation                               Note: Ver GetErrorOperation(byte)                     |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 07h          Vendor          DWORD       Varies      The vendor-specific ECC syndrome or CRC data          |
    // |              Syndrome                                associated with the erroneous access.                 |
    // |                                                      If the value is unknown, this field                   |
    // |                                                      contains 0000 0000h.                                  |
    // |                                                      Note: Ver CrcData                                     |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 0Bh          Memory Array    QWORD       Varies      The 64-bit physical address of the error based on the |
    // |              Error Address                           addressing of the bus to which the memory array is.   |
    // |                                                      connected.                                            |
    // |                                                      If the address is unknown, this field contains        |
    // |                                                      8000 0000 0000 0000h.                                 |
    // |                                                      Note: Ver BusErrorAddress                             |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 13h          Device Error    QWORD       Varies      The 64-bit physical address of the error relative to  |
    // |              Address                                 the start of the failing memory device, in bytes.     |
    // |                                                      If the address is unknown, this field contains        |
    // |                                                      8000 0000 0000 0000h.                                 |
    // |                                                      Note: Ver DeviceErrorAddress                          |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 1Bh          Error           DWORD       Varies      The range, in bytes, within which the error can be    |
    // |              Resolution                              determined, when an error address is given.           |
    // |                                                      If the address is unknown, this field contains        |
    // |                                                      8000 0000h.                                           |
    // |                                                      Note: Ver ErrorResolution                             |
    // •————————————————————————————————————————————————————————————————————————————————————————————————————————————•

    /// <summary>
    /// Specialization of the <see cref = "T:iTin.Core.Hardware.Specification.Smbios.SmbiosBaseType" /> class that contains the logic to decode the 64-Bit Memory Error Information (Type 33) structure.
    /// </summary>
    sealed class SmbiosType033 : SmbiosType018
    {
        #region Constructor/es

        #region [public] SmbiosType033(SmbiosStructureHeaderInfo, int): Initializes a new instance of the class by specifying the structure information and the SMBIOS version.
        /// <summary>
        /// Initializes a new instance of the <see cref="SmbiosType033"/> class by specifying the structure information and the <see cref="SMBIOS" /> version.
        /// </summary>
        /// <param name="smbiosStructureHeaderInfo">Raw information of the current structure.</param>
        /// <param name="smbiosVersion">Current <see cref="SMBIOS" /> version.</param>
        public SmbiosType033(SmbiosStructureHeaderInfo smbiosStructureHeaderInfo, int smbiosVersion) : base(smbiosStructureHeaderInfo, smbiosVersion)
        {
        }
        #endregion

        #endregion

        #region private properties

        #region [private] (ulong) MemoryArrayErrorAddress: Gets a value representing the 'Memory Array Error Address' field.
        /// <summary>
        /// Gets a value representing the <c>Memory Array Error Address</c> field.
        /// </summary>
        /// <value>
        /// Property value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ulong MemoryArrayErrorAddress
        {
            get { return (ulong)GetQuadrupleWord(0x0b); }
        }
        #endregion

        #region [private] (ulong) DeviceErrorAddress: Gets a value representing the 'Device Error Address' field.
        /// <summary>
        /// Gets a value representing the <c>Device Error Address</c> field.
        /// </summary>
        /// <value>
        /// Property value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ulong DeviceErrorAddress
        {
            get { return (ulong)GetQuadrupleWord(0x13); }
        }
        #endregion

        #region [private] (long) ErrorResolution: Gets a value representing the 'Error Resolution' field.
        /// <summary>
        /// Gets a value representing the <c>Error Resolution</c> field.
        /// </summary>
        /// <value>
        /// Property value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private long ErrorResolution
        {
            get { return GetDoubleWord(0x1b); }
        }
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
            SmbiosType033Property propertyId = (SmbiosType033Property)propertyKey.PropertyId;

            switch (propertyId)
            {
                #region [0x04] - [Error Type] - [String]
                case SmbiosType033Property.ErrorType:
                    value = GetErrorType(ErrorType);
                    break;
                #endregion

                #region [0x05] - [Error Granularity] - [String]
                case SmbiosType033Property.ErrorGranularity:
                    value = GetErrorGranularity(ErrorGranularity);
                    break;
                #endregion

                #region [0x06] - [Error Operation] - [String]
                case SmbiosType033Property.ErrorOperation:
                    value = GetErrorOperation(ErrorOperation);
                    break;
                #endregion

                #region [0x07] - [Vendor Syndrome] - [Int64?]
                case SmbiosType033Property.VendorSyndrome:
                    if (CrcData != 0x00000000)
                    {
                        value = (long?)CrcData;
                    }
                    break;
                #endregion

                #region [0x0b] - [Memory Array Error Address] - [Int64?]
                case SmbiosType033Property.MemoryArrayErrorAddress:
                    if (MemoryArrayErrorAddress != 0x8000000000000000)
                    {
                        value = (ulong?)MemoryArrayErrorAddress;
                    }
                    break;
                #endregion

                #region [0x13] - [Device Error Address] - [Int64?]
                case SmbiosType033Property.DeviceErrorAddress:
                    if (DeviceErrorAddress != 0x8000000000000000)
                    {
                        value = (ulong?) DeviceErrorAddress;
                    }
                    break;
                #endregion

                #region [0x1b] - [Error Resolution] - [Int64?]
                case SmbiosType033Property.ErrorResolution:
                    if (ErrorResolution != 0x80000000)
                    {
                        value = (long?) ErrorResolution;
                    }
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
            properties.Add(KnownDmiProperty.BitMemoryErrorInformation64.ErrorType, GetErrorType(ErrorType));
            properties.Add(KnownDmiProperty.BitMemoryErrorInformation64.ErrorGranularity, GetErrorGranularity(ErrorGranularity));
            properties.Add(KnownDmiProperty.BitMemoryErrorInformation64.ErrorOperation, GetErrorOperation(ErrorOperation));

            if (CrcData != 0x00000000)
            {
                properties.Add(KnownDmiProperty.BitMemoryErrorInformation64.VendorSyndrome, CrcData);
            }

            if (MemoryArrayErrorAddress != 0x8000000000000000)
            {
                properties.Add(KnownDmiProperty.BitMemoryErrorInformation64.BusErrorAddress, MemoryArrayErrorAddress);
            }

            if (DeviceErrorAddress != 0x8000000000000000)
            {
                properties.Add(KnownDmiProperty.BitMemoryErrorInformation64.DeviceErrorAddress, DeviceErrorAddress);
            }

            if (ErrorResolution != 0x80000000)
            {
                properties.Add(KnownDmiProperty.BitMemoryErrorInformation64.ErrorResolution, ErrorResolution);
            }
            #endregion
        }
        #endregion

        #endregion
    }
}