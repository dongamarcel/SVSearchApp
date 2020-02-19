using SimonsVoss.Infra.Interfaces;
using System;

namespace Repositories.Model
{
    public class SearchWeightConfiguration : ISearchWeightConfiguration
    {
        public SearchWeightConfiguration(Type type, string fieldName, int weight)
        {
            Type = type;
            FieldName = fieldName;
            Weight = weight;
        }

        public SearchWeightConfiguration(Type type, string fieldName, int weight, int crossReferencedWeight = 0, Type crossReferencedType = null) : this(type, fieldName, weight)
        {
            CrossReferencedType = crossReferencedType;
            CrossReferencedWeight = crossReferencedWeight;
        }

        public Type Type { get; private set; }

        public string FieldName { get; private set; }

        public int Weight { get; private set; }
        public Type CrossReferencedType { get; private set; }
        public int CrossReferencedWeight { get; private set; }
    }
}
