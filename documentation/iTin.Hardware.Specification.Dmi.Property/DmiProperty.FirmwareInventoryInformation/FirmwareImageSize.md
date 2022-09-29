# DmiProperty.FirmwareInventoryInformation.FirmwareImageSize property

Gets a value representing the key to retrieve the property value.

Size of the firmware image that is currently programmed in the device, in bytes. If the Firmware Image Size is unknown, the field is set to FFFFFFFFFFFFFFFFh

Key Composition

* Structure: FirmwareInventoryInformation
* Property: FirmwareImageSize
* Unit: Bytes

Return Value

Type: UInt64

Remarks

3.5

```csharp
public static IPropertyKey FirmwareImageSize { get; }
```

## See Also

* class [FirmwareInventoryInformation](../DmiProperty.FirmwareInventoryInformation.md)
* namespace [iTin.Hardware.Specification.Dmi.Property](../../iTin.Hardware.Specification.Dmi.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Hardware.Specification.Dmi.dll -->