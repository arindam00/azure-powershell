﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.VirtualNetworkRule.Cmdlet
{
    /// <summary>
    /// Defines the Remove-AzureRmSqlServerVirtualNetworkRule cmdlet
    /// </summary>
    [Cmdlet(VerbsCommon.Remove, "AzureRmSqlServerVirtualNetworkRule", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium),
        OutputType(typeof(Model.AzureSqlServerVirtualNetworkRuleModel))]
    public class RemoveAzureSqlServerVirtualNetworkRule : AzureSqlServerVirtualNetworkRuleCmdletBase
    {
        /// <summary>
        /// Gets or sets the name of the VirtualNetwork rule to remove
        /// </summary>
        [Parameter(Mandatory = true,
            HelpMessage = "Azure Sql Server Virtual Network Rule name")]
        [ValidateNotNullOrEmpty]
        public string VirtualNetworkRuleName { get; set; }

        /// <summary>
        /// Gets the entity to delete
        /// </summary>
        /// <returns>The entity going to be deleted</returns>
        protected override IEnumerable<Model.AzureSqlServerVirtualNetworkRuleModel> GetEntity()
        {
            return new List<Model.AzureSqlServerVirtualNetworkRuleModel>() {
                ModelAdapter.GetVirtualNetworkRule(this.ResourceGroupName, this.ServerName, this.VirtualNetworkRuleName)
            };
        }

        /// <summary>
        /// Apply user input.  Here nothing to apply
        /// </summary>
        /// <param name="model">The result of GetEntity</param>
        /// <returns>The input model</returns>
        protected override IEnumerable<Model.AzureSqlServerVirtualNetworkRuleModel> ApplyUserInputToModel(IEnumerable<Model.AzureSqlServerVirtualNetworkRuleModel> model)
        {
            return model;
        }

        /// <summary>
        /// Deletes the server.
        /// </summary>
        /// <param name="entity">The server being deleted</param>
        /// <returns>The server that was deleted</returns>
        protected override IEnumerable<Model.AzureSqlServerVirtualNetworkRuleModel> PersistChanges(IEnumerable<Model.AzureSqlServerVirtualNetworkRuleModel> entity)
        {
            ModelAdapter.RemoveVirtualNetworkRule(this.ResourceGroupName, this.ServerName, this.VirtualNetworkRuleName);
            return entity;
        }
    }
}
