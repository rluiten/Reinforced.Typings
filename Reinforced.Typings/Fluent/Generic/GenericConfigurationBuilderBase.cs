﻿using System;
using System.Collections.Generic;
using System.Reflection;
using Reinforced.Typings.Ast.TypeNames;
using Reinforced.Typings.Attributes;
using Reinforced.Typings.Fluent.Interfaces;

namespace Reinforced.Typings.Fluent.Generic
{
    abstract class GenericConfigurationBuilderBase : ITypeConfigurationBuilder
    {
        private readonly ICollection<TsAddTypeImportAttribute> _imports = new List<TsAddTypeImportAttribute>();

        private readonly Dictionary<MemberInfo, IExportConfiguration<TsAttributeBase>> _membersConfiguration =
            new Dictionary<MemberInfo, IExportConfiguration<TsAttributeBase>>();

        private readonly Dictionary<ParameterInfo, IExportConfiguration<TsParameterAttribute>> _parametersConfiguration
            = new Dictionary<ParameterInfo, IExportConfiguration<TsParameterAttribute>>();

        private readonly ICollection<TsAddTypeReferenceAttribute> _references = new List<TsAddTypeReferenceAttribute>();

        private readonly Type _type;

        protected GenericConfigurationBuilderBase(Type t)
        {
            _type = t;
            Substitutions = new Dictionary<Type, RtTypeName>();
        }

        private Dictionary<Type, RtTypeName> Substitutions { get; set; }

        Type ITypeConfigurationBuilder.Type
        {
            get { return _type; }
        }

        Dictionary<Type, RtTypeName> ITypeConfigurationBuilder.Substitutions
        {
            get { return Substitutions; }
        }

        Dictionary<ParameterInfo, IExportConfiguration<TsParameterAttribute>> ITypeConfigurationBuilder.
            ParametersConfiguration
        {
            get { return _parametersConfiguration; }
        }

        Dictionary<MemberInfo, IExportConfiguration<TsAttributeBase>> ITypeConfigurationBuilder.MembersConfiguration
        {
            get { return _membersConfiguration; }
        }

        ICollection<TsAddTypeReferenceAttribute> IReferenceConfigurationBuilder.References
        {
            get { return _references; }
        }

        ICollection<TsAddTypeImportAttribute> IReferenceConfigurationBuilder.Imports
        {
            get { return _imports; }
        }

        string IReferenceConfigurationBuilder.PathToFile { get; set; }
        public abstract double MemberOrder { get; set; }
    }
}