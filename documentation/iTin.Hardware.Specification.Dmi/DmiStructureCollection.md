# DmiStructureCollection class

Represents a collection of [`DmiStructure`](./DmiStructure.md) objects implemented in [`DMI`](../iTin.Hardware.Specification/DMI.md).

```csharp
public sealed class DmiStructureCollection : ReadOnlyCollection<DmiStructure>
```

## Public Members

| name | description |
| --- | --- |
| [Item](DmiStructureCollection/Item.md) { get; } | Gets the element with the specified key. |
| [Contains](DmiStructureCollection/Contains.md)(…) | Determines whether the element with the specified key is in the collection. |
| [GetProperties](DmiStructureCollection/GetProperties.md)(…) | Returns a Result that contains the result of the operation. |
| [GetProperty](DmiStructureCollection/GetProperty.md)(…) | Returns a Result that contains the result of the operation. Always returns the first appearance of the property |
| [IndexOf](DmiStructureCollection/IndexOf.md)(…) | Returns the index of the object with the key specified in the collection |

## See Also

* class [DmiStructure](./DmiStructure.md)
* namespace [iTin.Hardware.Specification.Dmi](../iTin.Hardware.Specification.Dmi.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Hardware.Specification.Dmi.dll -->
