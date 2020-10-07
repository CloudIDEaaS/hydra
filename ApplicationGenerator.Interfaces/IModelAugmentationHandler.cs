﻿// file:	IEntitiesModelGeneratorHandler.cs
//
// summary:	Declares the IEntitiesModelGeneratorHandler interface

using AbstraX.ServerInterfaces;
using AbstraX.TemplateObjects;
using CodeInterfaces;
using EntityProvider.Web.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstraX
{
    /// <summary>   Interface for entities model generator handler. </summary>
    ///
    /// <remarks>   Ken, 10/3/2020. </remarks>

    public interface IModelAugmentationHandler : IHandler
    {
        /// <summary>   Process this.  </summary>
        ///
        /// <param name="entityDomainModel">        The entity domain model. </param>
        /// <param name="businessModel">            The business model. </param>
        /// <param name="projectType">              Type of the project. </param>
        /// <param name="projectFolderRoot">        The project folder root. </param>
        /// <param name="entitiesProject"></param>
        /// <param name="generatorConfiguration">   The generator configuration. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>

        bool Process(EntityDomainModel entityDomainModel, BusinessModel businessModel, Guid projectType, string projectFolderRoot, IVSProject entitiesProject, IGeneratorConfiguration generatorConfiguration, out UIHierarchyNodeObject appHierarchyNodeObject);
    }
}