// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Storage.Models
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Extensions;

    /// <summary>
    /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
    /// </summary>
    public partial class SkuCapability :
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuCapability,
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuCapabilityInternal
    {

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuCapabilityInternal.Name { get => this._name; set { {_name = value;} } }

        /// <summary>Internal Acessors for Value</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.ISkuCapabilityInternal.Value { get => this._value; set { {_value = value;} } }

        /// <summary>Backing field for <see cref="Name" /> property.</summary>
        private string _name;

        /// <summary>
        /// The name of capability, The capability information in the specified SKU, including file encryption, network ACLs, change
        /// notification, etc.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public string Name { get => this._name; }

        /// <summary>Backing field for <see cref="Value" /> property.</summary>
        private string _value;

        /// <summary>
        /// A string value to indicate states of given capability. Possibly 'true' or 'false'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Origin(Microsoft.Azure.PowerShell.Cmdlets.Storage.PropertyOrigin.Owned)]
        public string Value { get => this._value; }

        /// <summary>Creates an new <see cref="SkuCapability" /> instance.</summary>
        public SkuCapability()
        {

        }
    }
    /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
    public partial interface ISkuCapability :
        Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.IJsonSerializable
    {
        /// <summary>
        /// The name of capability, The capability information in the specified SKU, including file encryption, network ACLs, change
        /// notification, etc.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"The name of capability, The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.",
        SerializedName = @"name",
        PossibleTypes = new [] { typeof(string) })]
        string Name { get;  }
        /// <summary>
        /// A string value to indicate states of given capability. Possibly 'true' or 'false'.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Read = true,
        Create = false,
        Update = false,
        Description = @"A string value to indicate states of given capability. Possibly 'true' or 'false'.",
        SerializedName = @"value",
        PossibleTypes = new [] { typeof(string) })]
        string Value { get;  }

    }
    /// The capability information in the specified SKU, including file encryption, network ACLs, change notification, etc.
    internal partial interface ISkuCapabilityInternal

    {
        /// <summary>
        /// The name of capability, The capability information in the specified SKU, including file encryption, network ACLs, change
        /// notification, etc.
        /// </summary>
        string Name { get; set; }
        /// <summary>
        /// A string value to indicate states of given capability. Possibly 'true' or 'false'.
        /// </summary>
        string Value { get; set; }

    }
}