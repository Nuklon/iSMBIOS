﻿
namespace iTin.Core.Hardware.Specification.Smbios
{
    using System.Collections;
    using System.Diagnostics;

    using Dmi.Property;
    using Helpers;

    // Type 008: Port Connector Information
    // •———————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | Offset       Name            Length      deviceProperty       Description                             |
    // •———————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 00h          Type            BYTE        8           Connector Information Indicator                  |
    // •———————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 01h          Length          BYTE        9h                                                           |
    // •———————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 02h          Handle          WORD        Varies                                                       |
    // •———————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 04h          Internal        BYTE        STRING      String number for Internal Reference Designator, |
    // |              Reference                               that is, internal to the system enclosure        |
    // |              Designator                              EXAMPLE: ‘J101’, 0                               |
    // |                                                      Note: Please see, InternalReference              |
    // •———————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 05h          Internal        BYTE        ENUM        Tipo de conector interno.                        |
    // |              Connector                               Note: Please see, GetConnectorType(byte)         |
    // |              Type                                                                                     |
    // •———————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 06h          External        BYTE        STRING      String number for the External Reference         |
    // |              Reference                               Designation external to the system enclosure     |
    // |              Designator                              EXAMPLE: ‘COM A’, 0                              |
    // |                                                      Note: Please see, ExternalReference              |
    // •———————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 07h          External        BYTE        ENUM        Tipo de conector externo.                        |
    // |              Connector                               Note: Please see, GetConnectorType(byte)         |
    // |              type                                                                                     |
    // •———————————————————————————————————————————————————————————————————————————————————————————————————————•
    // | 08h          Port            BYTE        ENUM        Descripción de la función de este puerto.        |
    // |              Type                                    Note: Please see, GetPortType(byte)              |
    // •———————————————————————————————————————————————————————————————————————————————————————————————————————•

    /// <summary>
    /// Specialization of the <see cref = "T:iTin.Core.Hardware.Specification.Smbios.SmbiosBaseType" /> class that contains the logic to decode the  Port Connector Information (Type 8) structure.
    /// </summary>
    sealed class SmbiosType008 : SmbiosBaseType
    {
        #region constructor/s

        #region [public] SmbiosType008(SmbiosStructureHeaderInfo, int): Initializes a new instance of the class by specifying the structure information and the SMBIOS version.
        /// <summary>
        /// Initializes a new instance of the <see cref="SmbiosType008"/> class by specifying the structure information and the <see cref="SMBIOS" /> version.
        /// </summary>
        /// <param name="smbiosStructureHeaderInfo">Raw information of the current structure.</param>
        /// <param name="smbiosVersion">Current <see cref="SMBIOS" /> version.</param>
        public SmbiosType008(SmbiosStructureHeaderInfo smbiosStructureHeaderInfo, int smbiosVersion) : base(smbiosStructureHeaderInfo, smbiosVersion)
        {
        }
        #endregion

        #endregion

        #region private properties

        #region [private] (string) InternalReference: Gets a value representing the 'Internal Reference' field.
        /// <summary>
        /// Gets a value representing the <c>Internal Reference</c> field.
        /// </summary>
        /// <value>
        /// Property value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string InternalReference
        {
            get { return GetString(0x04); }
        }
        #endregion

        #region [private] (byte) InternalConnectorType: Gets a value representing the 'Internal Connector Type' field.
        /// <summary>
        /// Gets a value representing the <c>Internal Connector Type</c> field.
        /// </summary>
        /// <value>
        /// Property value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private byte InternalConnectorType
        {
            get { return GetByte(0x05); }
        }
        #endregion

        #region [private] (string) ExternalReference: Gets a value representing the 'External Reference' field.
        /// <summary>
        /// Gets a value representing the <c>External Reference</c> field.
        /// </summary>
        /// <value>
        /// Property value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string ExternalReference
        {
            get { return GetString(0x06); }
        }
        #endregion

        #region [private] (byte) ExternalConnectorType: Gets a value representing the 'External Connector Type' field.
        /// <summary>
        /// Gets a value representing the <c>External Connector Type</c> field.
        /// </summary>
        /// <value>
        /// Property value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private byte ExternalConnectorType
        {
            get { return GetByte(0x07); }
        }
        #endregion

        #region [private] (byte) PortType: Gets a value representing the 'Port Type' field.
        /// <summary>
        /// Gets a value representing the <c>Port Type</c> field.
        /// </summary>
        /// <value>
        /// Property value.
        /// </value>
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private byte PortType
        {
            get { return GetByte(0x08); }
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
            SmbiosType008Property propertyId = (SmbiosType008Property)propertyKey.PropertyId;

            switch (propertyId)
            {
                #region [0x04] - [Internal Reference] - [string]
                case SmbiosType008Property.InternalReferenceDesignator:
                    value = InternalReference;
                    break;
                #endregion

                #region [0x05] - [Internal Connector Type] - [string]
                case SmbiosType008Property.InternalConnectorType:
                    value = GetConnectorType(InternalConnectorType);
                    break;
                #endregion

                #region [0x06] - [External Reference] - [string]
                case SmbiosType008Property.ExternalReferenceDesignator:
                    value = ExternalReference;
                    break;
                #endregion

                #region [0x07] - [External Connector Type] - [string]
                case SmbiosType008Property.ExternalConnectorType:
                    value = GetConnectorType(ExternalConnectorType);
                    break;
                #endregion

                #region [0x08] - [Port Type] - [string]
                case SmbiosType008Property.PortType:
                    value = GetPortType(PortType);
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
            properties.Add(KnownDmiProperty.PortConnector.InternalReferenceDesignator, InternalReference);
            properties.Add(KnownDmiProperty.PortConnector.InternalConnectorType, GetConnectorType(InternalConnectorType));
            properties.Add(KnownDmiProperty.PortConnector.ExternalReferenceDesignator, ExternalReference);
            properties.Add(KnownDmiProperty.PortConnector.ExternalConnectorType, GetConnectorType(ExternalConnectorType));
            properties.Add(KnownDmiProperty.PortConnector.PortType, GetPortType(PortType));
            #endregion
        }
        #endregion

        #endregion

        #region BIOS Specification 3.2.0 (26/04/2018)

        #region [private] {static} (string) GetConnectorType(byte): Gets a string representing the type of connector on this port.
        /// <summary>
        /// Gets a string representing the type of connector on this port.
        /// </summary>
        /// <param name="code">Value to analyze</param>
        /// <returns>
        /// Type of connector on this port.
        /// </returns>
        private static string GetConnectorType(byte code)
        {
            string[] deviceProperty =
            {
                "None", // 0x00
                "Centronics",
                "Mini Centronics",
                "Proprietary",
                "DB-25 male",
                "DB-25 female",
                "DB-15 male",
                "DB-15 female",
                "DB-9 male",
                "DB-9 female",
                "RJ-11",
                "RJ-45",
                "50 Pin MiniSCSI",
                "Mini DIN",
                "Micro DIN",
                "PS/2",
                "Infrared",
                "HP-HIL",
                "Access Bus (USB)",
                "SSA SCSI",
                "Circular DIN-8 male",
                "Circular DIN-8 female",
                "On Board IDE",
                "On Board Floppy",
                "9 Pin Dual Inline (pin 10 cut)",
                "25 Pin Dual Inline (pin 26 cut)",
                "50 Pin Dual Inline",
                "68 Pin Dual Inline",
                "On Board Sound Input From CD-ROM",
                "Mini Centronics Type-14",
                "Mini Centronics Type-26",
                "Mini Jack (headphones)",
                "BNC",
                "IEEE 1394",
                "SAS/SATA Plug Receptacle", 
                "USB Type-C Receptacle" // 0x23
            };

            string[] deviceProperty1 =
            {
                "PC-98", // 0xA0
                "PC-98 Hireso",
                "PC-H98",
                "PC-98 Note",
                "PC-98 Full" // 0xA4
            };

            if (code <= 0x23)
            {
                return deviceProperty[code];
            }

            if (code >= 0xA0 && code <= 0xA4)
            {
                return deviceProperty1[code - 0xA0];
            }

            if (code == 0xFF)
            {
                return "Other";
            }

            return SmbiosHelper.OutOfSpec;
        }
        #endregion

        #region [private] {static} (string) GetPortType(byte): Gets a string representing the function of this port.
        /// <summary>
        /// Gets a string representing the function of this port.
        /// </summary>
        /// <param name="code">Value to analyze</param>
        /// <returns>
        /// The function of this port.
        /// </returns>
        private static string GetPortType(byte code)
        {
            string[] deviceProperty =
            {
                "None",                                    // 0x00
                "Parallel Port XT/AT Compatible",
                "Parallel Port PS/2",
                "Parallel Port ECP",
                "Parallel Port EPP",
                "Parallel Port ECP/EPP",
                "Serial Port XT/AT Compatible",
                "Serial Port 16450 Compatible",
                "Serial Port 16550 Compatible",
                "Serial Port 16550A Compatible",
                "SCSI Port",
                "MIDI Port",
                "Joystick Port",
                "Keyboard Port",
                "Mouse Port",
                "SSA SCSI",
                "USB",
                "Firewire (IEEE P1394)",
                "PCMCIA Type I",
                "PCMCIA Type II",
                "PCMCIA Type III",
                "Cardbus",
                "Access Bus Port",
                "SCSI II",
                "SCSI Wide",
                "PC-98",
                "PC-98 Hireso",
                "PC-H98",
                "Video Port",
                "Audio Port",
                "Modem Port",
                "Network Port",
                "SATA",
                "SAS",                                      
                "MFDP (Multi-Function Display Port)",
                "Thunderbolt" // 0x23
           };

            string[] deviceProperty1 =
            {
                "8251 Compatible", // 0xA0
                "8251 FIFO Compatible" // 0xA1
            };

            if (code <= 0x23)
            {
                return deviceProperty[code];
            }

            if (code >= 0xA0 && code <= 0xA1)
            {
                return deviceProperty1[code - 0xA0];
            }

            if (code == 0xFF)
            {
                return "Other";
            }

            return SmbiosHelper.OutOfSpec;
        }
        #endregion

        #endregion
    }
}
