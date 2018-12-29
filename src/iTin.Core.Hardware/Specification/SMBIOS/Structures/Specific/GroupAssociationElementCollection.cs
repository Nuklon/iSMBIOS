﻿
namespace iTin.Core.Hardware.Specification.Smbios
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// Representa una colección de objetos <see cref="GroupAssociationElement"/>.
    /// </summary>
    sealed class GroupAssociationElementCollection : ReadOnlyCollection<GroupAssociationElement>
    {
        #region constructor/s

            #region [internal] GroupAssociationElementCollection(IEnumerable<GroupAssociationElement>): Inicializa una nueva instancia de la clase.
            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="GroupAssociationElementCollection"/>.
            /// </summary>
            /// <param name="elements">Lista de elementos.</param>
            internal GroupAssociationElementCollection(IEnumerable<GroupAssociationElement> elements) : base(elements.ToList())
            {
            }
            #endregion

        #endregion

        #region public override methods

            #region [public] {override} (string) ToString(): Devuelve una clase string que representa al objeto actual.
            /// <summary>
            /// Devuelve una clase <see cref="T:System.String"/> que representa al objeto actual. 
            /// </summary>
            /// <returns>
            ///   <para>Tipo: <see cref="T:System.String"/></para>
            ///   <para>Objeto <see cref="T:System.String"/> que representa la clase <see cref="GroupAssociationElementCollection"/> actual.</para>
            /// </returns>
            /// <remarks>
            ///   <para>Este método devuelve una cadena que incluye el número de elementos disponibles.</para>
            /// </remarks>                                    
            public override string ToString()
            {
                return string.Format(CultureInfo.InvariantCulture, "Elements = {0}", Items.Count);
            }
            #endregion

        #endregion              
    }
}
