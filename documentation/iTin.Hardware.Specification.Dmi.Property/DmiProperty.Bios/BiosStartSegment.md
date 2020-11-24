# DmiProperty.Bios.BiosStartSegment property

Gets a value representing the key to retrieve the property value.

Segment location of BIOS starting address. This value is a free-form string that may contain core and OEM version information. The size of the runtime BIOS image can be computed by subtracting the Starting Address Segment from 10000h and multiplying the result by 16.

Key Composition

* Structure: Bios
* Property: BiosStartSegment
* Unit: None

Return Value

Type: String

Remarks

2.0+

```csharp
public static IPropertyKey BiosStartSegment { get; }
```

## See Also

* class [Bios](../DmiProperty.Bios.md)
* namespace [iTin.Hardware.Specification.Dmi.Property](../../iTin.Hardware.Specification.Dmi.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Hardware.Specification.Dmi.dll -->